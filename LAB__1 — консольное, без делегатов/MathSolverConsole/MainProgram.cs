using System;
using System.Collections.Generic;
using System.Linq;

public class Transaction
{
    public DateTime Date { get; set; }
    public string Type { get; set; }
    public decimal Amount { get; set; }
}

public class Account
{
    public string CardNumber { get; private set; }
    public string OwnerName { get; private set; }
    public int Pin { get; private set; }
    public decimal Balance { get; private set; }

    private List<Transaction> transactionHistory;

    public event Action<Transaction> TransactionPerformed;
    public event Action<decimal> Withdrawn;


    public Account(string cardNumber, string ownerName, int pin, decimal initialBalance)
    {
        CardNumber = cardNumber;
        OwnerName = ownerName;
        Pin = pin;
        Balance = initialBalance;
        transactionHistory = new List<Transaction>();
    }

    public bool Withdraw(decimal amount)
    {
        if (amount > 0 && Balance >= amount)
        {
            Balance -= amount;
            RecordTransaction("Withdraw", amount);
            //Console.Clear();
            //Withdrawn?.Invoke(amount); // Вызываем событие
            //Console.ReadKey();
            return true;
        }
        return false;
    }


    public void Deposit(decimal amount)
    {
        if (amount > 0)
        {
            Balance += amount;
            RecordTransaction("Deposit", amount);
        }
    }

    public void Transfer(Account recipient, decimal amount)
    {
        if (Withdraw(amount))
        {
            recipient.Deposit(amount);
            RecordTransaction("Transfer", amount);
            recipient.RecordTransaction("Received from " + OwnerName, amount);
        }
    }

    public List<Transaction> GetTransactionHistory()
    {
        return transactionHistory;
    }

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

public class Bank
{
    private List<Account> accounts = new List<Account>();
    private List<AutomatedTellerMachine> atms = new List<AutomatedTellerMachine>();

    public string Name { get; private set; }

    public Bank(string name)
    {
        Name = name;
    }

    public void AddAccount(Account account)
    {
        accounts.Add(account);
    }

    public void AddATM(AutomatedTellerMachine atm)
    {
        atms.Add(atm);
    }

    public Account FindAccountByCardNumber(string cardNumber)
    {
        return accounts.FirstOrDefault(account => account.CardNumber == cardNumber);
    }
}

public class AutomatedTellerMachine
{
    public int Id { get; private set; }
    public string Location { get; private set; }
    public decimal CashBalance { get; private set; }
    private Bank bank;

    public AutomatedTellerMachine(int id, string location, decimal cashBalance, Bank bank)
    {
        Id = id;
        Location = location;
        CashBalance = cashBalance;
        this.bank = bank;
    }

    public bool Authenticate(string cardNumber, int pin)
    {
        Account account = bank.FindAccountByCardNumber(cardNumber);
        return account != null && account.Pin == pin;
    }
}

class Program
{
    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        Bank bank = new Bank("MyBank");

        AutomatedTellerMachine atm1 = new AutomatedTellerMachine(1, "Location1", 10000, bank);
        AutomatedTellerMachine atm2 = new AutomatedTellerMachine(2, "Location2", 8000, bank);
        bank.AddATM(atm1);
        bank.AddATM(atm2);

        Account account1 = new Account("123", "Борис Олександрович", 1111, 1500);
        Account account2 = new Account("321", "Олена Володимирівна", 2222, 2000);
        bank.AddAccount(account1);
        bank.AddAccount(account2);

        account1.TransactionPerformed += transaction => Console.WriteLine($"Транзакція: {transaction.Type}, Сума: {transaction.Amount:C}");
        //account1.Withdrawn += amount => Console.WriteLine($"Снято {amount:C} со счета {account1.OwnerName}");


        while (true)
        {
            Console.WriteLine("Ласкаво просимо в банківську систему - JK.Corp!");

            Console.Write("\nБудь ласка, введіть номер картки -> ");
            string cardNumber = Console.ReadLine();

            Console.Write("Введіть пін-код -> ");
            int pin = int.Parse(Console.ReadLine());

            Console.Clear();

            Account userAccount = bank.FindAccountByCardNumber(cardNumber);

            if (userAccount != null && atm1.Authenticate(cardNumber, pin))
            {
                Console.WriteLine($"Ви успішно автентифікувалися, {userAccount.OwnerName}!");
                bool loggedIn = true;

                while (loggedIn)
                {
                    Console.WriteLine("|                                   Меню                                  |");
                    Console.WriteLine("|-------------------------------------------------------------------------|");
                    Console.WriteLine("| 1 – Переглянути баланс             | 4 - Перерахування коштів на картку |");
                    Console.WriteLine("| 2 - Зняти кошти                    | 5 - Переглянути історію транзакцій |");
                    Console.WriteLine("| 3 - Зарахувати кошти               | 6 - Перегляд найближчих банкоматів |");
                    Console.WriteLine("|-------------------------------------------------------------------------|");
                    Console.WriteLine("| 7 - Вихід з облікового запису      | 8 - Вихід з застосунку             |");
                    Console.WriteLine("|-------------------------------------------------------------------------|");
                    Console.Write("Ваш вибір -> ");

                    string choice = Console.ReadLine();
                    switch (choice)
                    {
                        case "1":
                            Console.Clear();
                            Console.WriteLine($"Баланс на рахунку: {userAccount.Balance:C}");
                            Console.Write("\nДля повернення на головне меню, натисніть будь-яку клавішу...");
                            Console.ReadKey();
                            break;
                        case "2":
                            Console.Clear();
                            Console.WriteLine($"Баланс на рахунку: {userAccount.Balance:C}");
                            Console.Write("\nВведіть суму для зняття -> ");
                            if (decimal.TryParse(Console.ReadLine(), out decimal withdrawAmount))
                            {
                                bool withdrawalSuccess = userAccount.Withdraw(withdrawAmount); // Вызываем метод и сохраняем результат

                                if (withdrawalSuccess)
                                {
                                    Console.Clear();
                                    Console.WriteLine("Операція успішно виконана.");
                                    Console.Write("\nДля повернення на головне меню, натисніть будь-яку клавішу...");
                                    Console.ReadKey();
                                }
                                else
                                {
                                    Console.Clear();
                                    Console.WriteLine("Неможливо виконати операцію.");
                                    Console.Write("\nДля повернення на головне меню, натисніть будь-яку клавішу...");
                                    Console.ReadKey();
                                }
                            }

                            break;
                        case "3":
                            Console.Clear();
                            Console.WriteLine($"Баланс на рахунку: {userAccount.Balance:C}");
                            Console.Write("\nВведіть суму для зарахування -> ");
                            if (decimal.TryParse(Console.ReadLine(), out decimal depositAmount))
                            {
                                Console.Clear();
                                userAccount.Deposit(depositAmount);
                                Console.WriteLine("Операція успішно виконана.");
                                Console.Write("\nДля повернення на головне меню, натисніть будь-яку клавішу...");
                                Console.ReadKey();
                            }
                            else
                            {
                                Console.Clear();
                                Console.WriteLine("Невірний формат суми.");
                                Console.Write("\nДля повернення на головне меню, натисніть будь-яку клавішу...");
                                Console.ReadKey();
                            }
                            break;
                        case "4":
                            Console.Clear();
                            Console.WriteLine($"Баланс на рахунку: {userAccount.Balance:C}");
                            Console.Write("\nВведіть номер картки для перерахування -> ");
                            string recipientCardNumber = Console.ReadLine();
                            Account recipientAccount = bank.FindAccountByCardNumber(recipientCardNumber);

                            if (recipientAccount != null)
                            {
                                Console.Write("Введіть суму для перерахування -> ");
                                if (decimal.TryParse(Console.ReadLine(), out decimal transferAmount))
                                {
                                    userAccount.Transfer(recipientAccount, transferAmount);
                                    Console.Clear();
                                    Console.WriteLine("Операція успішно виконана.");
                                    Console.Write("\nДля повернення на головне меню, натисніть будь-яку клавішу...");
                                    Console.ReadKey();
                                }
                                else
                                {
                                    Console.Clear();
                                    Console.WriteLine("Невірний формат суми.");
                                    Console.Write("\nДля повернення на головне меню, натисніть будь-яку клавішу...");
                                    Console.ReadKey();
                                }
                            }
                            else
                            {
                                Console.Clear();
                                Console.WriteLine("Рахунок з вказаним номером картки не знайдений.");
                                Console.Write("\nДля повернення на головне меню, натисніть будь-яку клавішу...");
                                Console.ReadKey();
                            }
                            break;

                        case "5":
                            Console.Clear();
                            Console.WriteLine("Виберіть фільтр для перегляду історії транзакцій:");
                            Console.WriteLine("1 - За поточний день");
                            Console.WriteLine("2 - За поточний тиждень");
                            Console.WriteLine("3 - За поточний місяць");
                            Console.WriteLine("4 - Показати всі транзакції");
                            Console.Write("Ваш вибір -> ");

                            string filterChoice = Console.ReadLine();

                            switch (filterChoice)
                            {
                                case "1":
                                    DateTime currentDate = DateTime.Now.Date;
                                    List<Transaction> dailyTransactions = userAccount.GetTransactionHistory()
                                        .Where(transaction => transaction.Date.Date == currentDate)
                                        .ToList();

                                    Console.Clear();
                                    Console.WriteLine("Історія транзакцій за поточний день:");
                                    foreach (Transaction transaction in dailyTransactions)
                                    {
                                        Console.WriteLine($"{transaction.Date}: {transaction.Type} - {transaction.Amount:C}");
                                    }
                                    break;
                                case "2":
                                    DateTime currentWeekStart = DateTime.Now.Date.AddDays(-(int)DateTime.Now.DayOfWeek);
                                    DateTime currentWeekEnd = currentWeekStart.AddDays(7);

                                    List<Transaction> weeklyTransactions = userAccount.GetTransactionHistory()
                                        .Where(transaction => transaction.Date.Date >= currentWeekStart && transaction.Date.Date < currentWeekEnd)
                                        .ToList();

                                    Console.Clear();
                                    Console.WriteLine("Історія транзакцій за поточний тиждень:");
                                    foreach (Transaction transaction in weeklyTransactions)
                                    {
                                        Console.WriteLine($"{transaction.Date}: {transaction.Type} - {transaction.Amount:C}");
                                    }
                                    break;
                                case "3":
                                    DateTime currentMonthStart = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
                                    DateTime nextMonthStart = currentMonthStart.AddMonths(1);

                                    List<Transaction> monthlyTransactions = userAccount.GetTransactionHistory()
                                        .Where(transaction => transaction.Date.Date >= currentMonthStart && transaction.Date.Date < nextMonthStart)
                                        .ToList();

                                    Console.Clear();
                                    Console.WriteLine("Історія транзакцій за поточний місяць:");
                                    foreach (Transaction transaction in monthlyTransactions)
                                    {
                                        Console.WriteLine($"{transaction.Date}: {transaction.Type} - {transaction.Amount:C}");
                                    }
                                    break;
                                case "4":
                                    List<Transaction> allTransactions = userAccount.GetTransactionHistory();

                                    Console.Clear();
                                    Console.WriteLine("Історія всіх транзакцій:");
                                    foreach (Transaction transaction in allTransactions)
                                    {
                                        Console.WriteLine($"{transaction.Date}: {transaction.Type} - {transaction.Amount:C}");
                                    }
                                    break;
                                default:
                                    Console.Clear();
                                    Console.WriteLine("Невірний вибір фільтра. Спробуйте ще раз.");
                                    break;
                            }

                            Console.Write("\nДля повернення на головне меню, натисніть будь-яку клавішу...");
                            Console.ReadKey();
                            break;

                        case "7":
                            Console.Clear();
                            Console.WriteLine($"До побачення, {userAccount.OwnerName}!");
                            Console.Write("\nДля повернення на сторінку авторизації, натисніть будь-яку клавішу...");
                            Console.ReadKey();
                            loggedIn = false;
                            break;
                        case "8":
                            return;
                            break;
                        default:
                            Console.WriteLine("Невірний вибір. Спробуйте ще раз.");
                            break;
                    }

                    Console.Clear();
                }
            }
            else
            {
                Console.WriteLine("Невірна картка або пін-код. Спробуйте ще раз.");
                Console.Write("Для продовження, натисніть будь-яку клавішу...");
                Console.ReadKey();
                Console.Clear();
            }
        }
    }
}
