namespace MathSolverClassLibrary
{
    public class Account
    {
        public string CardNumber { get; }
        public string OwnerName { get; }
        public decimal Balance { get; private set; }
        public int Pin { get; } // Добавляем свойство для хранения пин-кода

        private List<Transaction> TransactionHistory { get; set; } = new List<Transaction>(); // Історія транзакцій для рахунку

        public Account(string cardNumber, string ownerName, int pin, decimal initialBalance)
        {
            CardNumber = cardNumber;
            OwnerName = ownerName;   
            Pin = pin;
            Balance = initialBalance;
            TransactionHistory = new List<Transaction>();
        }

        public bool Withdraw(decimal amount)
        {
            if (amount > 0 && Balance >= amount)
            {
                Balance -= amount;
                TransactionHistory.Add(new Transaction("Зняття коштів", amount));
                return true;
            }
            return false;
        }

        public bool Transfer_Withdraw(decimal amount)
        {
            if (amount > 0 && Balance >= amount)
            {
                Balance -= amount;
                TransactionHistory.Add(new Transaction("Перевод коштів на картку (Зняття коштів)", amount));
                return true;
            }
            return false;
        }

        public void Deposit(decimal amount)
        {
            if (amount > 0)
            {
                Balance += amount;
                TransactionHistory.Add(new Transaction("Зарахування коштів", amount));
            }
        }

        public void Transfer_Deposit(decimal amount)
        {
            if (amount > 0)
            {
                Balance += amount;
                TransactionHistory.Add(new Transaction("Перевод коштів на картку (Зарахування коштів)", amount));
            }
        }

        // Метод для додавання транзакції до історії
        private void AddTransaction(string type, decimal amount)
        {
            TransactionHistory.Add(new Transaction(type, amount));
        }

        // Метод для отримання історії транзакцій
        public List<Transaction> GetTransactionHistory()
        {
            return TransactionHistory;
        }
    }

    // Клас для зберігання інформації про транзакції
    public class Transaction
    {
        public string Type { get; }
        public decimal Amount { get; }
        public DateTime Date { get; }

        public Transaction(string type, decimal amount)
        {
            Type = type;
            Amount = amount;
            Date = DateTime.Now;
        }
    }



    // Клас, що представляє банкомат
    public class AutomatedTellerMachine
    {
        public int ATMId { get; }
        public string Location { get; }
        private decimal MoneyInATM { get; set; }

        private Bank bank; // поле для хранения экземпляра банка

        public AutomatedTellerMachine(int id, string location, decimal cashBalance, Bank bank)
        {
            ATMId = id;
            Location = location;
            MoneyInATM = cashBalance;
            this.bank = bank;
        }

        public bool Authenticate(string cardNumber, int pin)
        {
            Account account = bank.FindAccountByCardNumber(cardNumber);
            return account != null && account.Pin == pin;
        }



        public bool WithdrawMoney(string cardNumber, decimal amount)
        {
            if (MoneyInATM >= amount)
            {
                MoneyInATM -= amount;
                return true;
            }
            return false;
        }
    }

    // Клас, що представляє банк
    public class Bank
    {
        public string Name { get; }
        public List<AutomatedTellerMachine> ATMs { get; }
        private List<Account> Accounts { get; }

        public Bank(string name)
        {
            Name = name;
            ATMs = new List<AutomatedTellerMachine>();
            Accounts = new List<Account>();
        }

        public void AddATM(AutomatedTellerMachine atm)
        {
            ATMs.Add(atm);
        }

        public void AddAccount(Account account)
        {
            Accounts.Add(account);
        }

        public Account FindAccountByCardNumber(string cardNumber)
        {
            return Accounts.FirstOrDefault(account => account.CardNumber == cardNumber);
        }

        public List<AutomatedTellerMachine> GetNearestATMs(string location)
        {
            return ATMs.Where(atm => atm.Location == location).ToList();
        }
    }

}

//using System;
//using System.Collections.Generic;
//using System.Linq;

//namespace MathSolverClassLibrary
//{
//    // Делегат для події, пов'язаної зі зняттям коштів
//    public delegate void MoneyWithdrawnEventHandler(object sender, MoneyWithdrawnEventArgs e);

//    // Аргументи події для зняття коштів
//    public class MoneyWithdrawnEventArgs : EventArgs
//    {
//        public decimal Amount { get; }

//        public MoneyWithdrawnEventArgs(decimal amount)
//        {
//            Amount = amount;
//        }
//    }

//    public class Account
//    {
//        public string CardNumber { get; }
//        public string OwnerName { get; }
//        public decimal Balance { get; private set; }
//        public int Pin { get; }

//        private List<Transaction> TransactionHistory { get; set; } = new List<Transaction>();

//        // Подія для сповіщення про зняття коштів
//        public event MoneyWithdrawnEventHandler MoneyWithdrawn;

//        public Account(string cardNumber, string ownerName, int pin, decimal initialBalance)
//        {
//            CardNumber = cardNumber;
//            OwnerName = ownerName;
//            Pin = pin;
//            Balance = initialBalance;
//            TransactionHistory = new List<Transaction>();
//        }

//        public bool Withdraw(decimal amount)
//        {
//            if (amount > 0 && Balance >= amount)
//            {
//                Balance -= amount;
//                TransactionHistory.Add(new Transaction("Зняття коштів", amount));

//                // Сповістимо про подію MoneyWithdrawn
//                OnMoneyWithdrawn(new MoneyWithdrawnEventArgs(amount));

//                return true;
//            }
//            return false;
//        }

//        // Метод для сповіщення про подію MoneyWithdrawn
//        protected virtual void OnMoneyWithdrawn(MoneyWithdrawnEventArgs e)
//        {
//            MoneyWithdrawn?.Invoke(this, e);
//        }

//        // Лямбда-вираз для отримання балансу в форматі рядка
//        public Func<string> GetBalanceAsString => () => $"Баланс: {Balance:C2}";
//    }

//    // Клас для зберігання інформації про транзакції
//    public class Transaction
//    {
//        public string Type { get; }
//        public decimal Amount { get; }
//        public DateTime Date { get; }

//        public Transaction(string type, decimal amount)
//        {
//            Type = type;
//            Amount = amount;
//            Date = DateTime.Now;
//        }
//    }

//    // Клас, що представляє банкомат
//    public class AutomatedTellerMachine
//    {
//        public int ATMId { get; }
//        public string Location { get; }
//        private decimal MoneyInATM { get; set; }

//        private Bank bank;

//        public AutomatedTellerMachine(int atmId, string location, decimal initialMoney, Bank bank)
//        {
//            ATMId = atmId;
//            Location = location;
//            MoneyInATM = initialMoney;
//            this.bank = bank;
//        }

//        public bool Authenticate(string cardNumber, int enteredPin)
//        {
//            Account userAccount = bank.FindAccountByCardNumber(cardNumber);

//            if (userAccount != null && userAccount.Pin == enteredPin)
//            {
//                return true;
//            }

//            return false;
//        }

//        public bool WithdrawMoney(string cardNumber, decimal amount)
//        {
//            if (MoneyInATM >= amount)
//            {
//                MoneyInATM -= amount;
//                return true;
//            }
//            return false;
//        }
//    }

//    public class Bank
//    {
//        public string Name { get; }
//        public List<AutomatedTellerMachine> ATMs { get; }
//        private List<Account> Accounts { get; }

//        public Bank(string name)
//        {
//            Name = name;
//            ATMs = new List<AutomatedTellerMachine>();
//            Accounts = new List<Account>();
//        }

//        public void AddATM(AutomatedTellerMachine atm)
//        {
//            ATMs.Add(atm);
//        }

//        public void AddAccount(Account account)
//        {
//            Accounts.Add(account);
//        }

//        public Account FindAccountByCardNumber(string cardNumber)
//        {
//            return Accounts.FirstOrDefault(account => account.CardNumber == cardNumber);
//        }

//        public List<AutomatedTellerMachine> GetNearestATMs(string location)
//        {
//            return ATMs.Where(atm => atm.Location == location).ToList();
//        }
//    }
//}
