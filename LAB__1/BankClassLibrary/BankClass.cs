namespace BankClassLibrary
{

    // Класс, представляющий транзакцию
    public class Transaction
    {
        public DateTime Date { get; set; }    // Дата транзакции
        public string Type { get; set; }       // Тип транзакции (например, "Withdraw", "Deposit", "Transfer")
        public decimal Amount { get; set; }    // Сумма транзакции
    }
    
    // Класс, представляющий банковский счет
    public class Account
    {
        public string CardNumber { get; private set; }  // Номер карты счета
        public string OwnerName { get; private set; }   // Имя владельца счета
        public int Pin { get; private set; }            // Пин-код счета
        public decimal Balance { get; private set; }    // Баланс счета

        private List<Transaction> transactionHistory;   // История транзакций

        public event Action<Transaction> TransactionPerformed;  // Событие при выполнении транзакции
        public event Action<decimal> Withdrawn;                // Событие при снятии средств

        // Конструктор класса Account
        public Account(string cardNumber, string ownerName, int pin, decimal initialBalance)
        {
            CardNumber = cardNumber;
            OwnerName = ownerName;
            Pin = pin;
            Balance = initialBalance;
            transactionHistory = new List<Transaction>();
        }

        // Метод для снятия средств с счета
        public bool Withdraw(decimal amount, bool without_transfer)
        {
            if (amount > 0 && Balance >= amount)
            {
                Balance -= amount;
                if (without_transfer == true)
                {
                    RecordTransaction("Withdraw", amount);
                }
                return true;
            }
            return false;
        }

        // Метод для внесения средств на счет
        public void Deposit(decimal amount, bool without_transfer)
        {
            if (amount > 0)
            {
                Balance += amount;
                if (without_transfer == true)
                {
                    RecordTransaction("Deposit", amount);
                }
            }
        }

        // Метод для осуществления перевода средств на другой счет
        public void Transfer(Account recipient, decimal amount)
        {
            if (Withdraw(amount, false))
            {
                recipient.Deposit(amount, false);
                RecordTransaction("Transfer", amount);
                recipient.RecordTransaction("Received from " + OwnerName, amount);
            }
        }

        // Метод для получения истории транзакций
        public List<Transaction> GetTransactionHistory()
        {
            return transactionHistory;
        }

        public List<Transaction> GetTransactionsByPeriod(DateTime startDate, DateTime endDate)
        {
            return transactionHistory
                .Where(transaction => transaction.Date >= startDate && transaction.Date <= endDate)
                .ToList();
        }

        // Приватный метод для записи транзакции в историю
        private void RecordTransaction(string type, decimal amount)
        {
            var transaction = new Transaction
            {
                Date = DateTime.Now,
                Type = type,
                Amount = amount
            };
            transactionHistory.Add(transaction);
            TransactionPerformed?.Invoke(transaction);
        }
    }

    // Класс, представляющий банк
    public class Bank
    {
        private List<Account> accounts = new List<Account>();  // Список банковских счетов
        private List<AutomatedTellerMachine> atms = new List<AutomatedTellerMachine>();  // Список банкоматов

        public string Name { get; private set; }  // Название банка

        // Создаем публичное свойство для доступа к списку аккаунтов
        public List<Account> Accounts
        {
            get { return accounts; }
        }

        // Конструктор класса Bank
        public Bank(string name)
        {
            Name = name;
        }

        // Метод для добавления нового счета в банк
        public void AddAccount(Account account)
        {
            accounts.Add(account);
        }

        // Метод для добавления банкомата в банк
        public void AddATM(AutomatedTellerMachine atm)
        {
            atms.Add(atm);
        }

        // Метод для поиска счета по номеру карты
        public Account FindAccountByCardNumber(string cardNumber)
        {
            return accounts.FirstOrDefault(account => account.CardNumber == cardNumber);
        }

        // Метод для получения случайного банкомата
        public AutomatedTellerMachine GetRandomATM()
        {
            Random random = new Random();
            int randomIndex = random.Next(0, atms.Count);
            return atms[randomIndex];
        }

        public AutomatedTellerMachine FindNearestATM(double userLatitude, double userLongitude)
        {
            AutomatedTellerMachine nearestATM = null;
            double minDistance = double.MaxValue;

            foreach (var atm in atms)
            {
                // Вычислите расстояние между пользователем и банкоматом atm
                double distance = CalculateDistance(userLatitude, userLongitude, atm.Latitude, atm.Longitude);

                // Если текущий банкомат ближе, обновите ближайший банкомат
                if (distance < minDistance)
                {
                    minDistance = distance;
                    nearestATM = atm;
                }
            }

            return nearestATM;
        }

        private double CalculateDistance(double lat1, double lon1, double lat2, double lon2)
        {
            const double EarthRadius = 6371; // Радиус Земли в километрах

            // Переводим широту и долготу из градусов в радианы
            double lat1Rad = Math.PI * lat1 / 180;
            double lon1Rad = Math.PI * lon1 / 180;
            double lat2Rad = Math.PI * lat2 / 180;
            double lon2Rad = Math.PI * lon2 / 180;

            // Разницы координат
            double deltaLat = lat2Rad - lat1Rad;
            double deltaLon = lon2Rad - lon1Rad;

            // Вычисляем расстояние с использованием формулы гаверсинусов
            double a = Math.Sin(deltaLat / 2) * Math.Sin(deltaLat / 2) +
                       Math.Cos(lat1Rad) * Math.Cos(lat2Rad) *
                       Math.Sin(deltaLon / 2) * Math.Sin(deltaLon / 2);

            double c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));

            // Вычисляем расстояние
            double distance = EarthRadius * c;

            return distance; // Расстояние в километрах
        }

    }

    // Класс, представляющий банкомат
    public class AutomatedTellerMachine
    {
        public int Id { get; private set; }       // Идентификатор банкомата
        public string Location { get; private set; }  // Местоположение банкомата
        public decimal CashBalance { get; set; }      // Доступный баланс банкомата
        private Bank bank;

        public double Latitude { get; private set; }
        public double Longitude { get; private set; }

        // Конструктор класса AutomatedTellerMachine
        public AutomatedTellerMachine(int id, string location, decimal cashBalance, Bank bank, double latitude, double longitude)
        {
            Id = id;
            Location = location;
            CashBalance = cashBalance;
            this.bank = bank;
            Latitude = latitude;
            Longitude = longitude;
        }

        // Метод для аутентификации с помощью номера карты и PIN-кода
        public bool Authenticate(string cardNumber, int pin)
        {
            Account account = bank.FindAccountByCardNumber(cardNumber);
            return account != null && account.Pin == pin;
        }
    }

    public class CoordinateGenerator
    {
        private readonly Random random = new Random();

        public double GenerateLatitude()
        {
            // Широта Харькова находится в пределах 49.9 и 50.1 градусов
            return 49.9 + random.NextDouble() * 0.2;
        }

        public double GenerateLongitude()
        {
            // Долгота Харькова находится в пределах 35.05 и 36.55 градусов
            return 35.05 + random.NextDouble() * 1.5;
        }
    }
}