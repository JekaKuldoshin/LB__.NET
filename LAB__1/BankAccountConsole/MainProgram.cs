using System;
using System.Collections.Generic;
using System.Linq;
using static BankClassLibrary.CoordinateGenerator;
using BankClassLibrary;

class Program
{
    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        // Создаем банк
        Bank bank = new Bank("MyBank");

        // Создаем несколько банкоматов и добавляем их в банк
        AutomatedTellerMachine atm1 = new AutomatedTellerMachine(1, "пр. Науки 14", 3000, bank, 50.0045, 36.2275); // Центр
        AutomatedTellerMachine atm2 = new AutomatedTellerMachine(2, "пр. Московский 199", 4500, bank, 50.0112, 36.2267); // Северо-восток
        AutomatedTellerMachine atm3 = new AutomatedTellerMachine(3, "пр. Гагарина 175", 3800, bank, 49.9808, 36.2536); // Юго-запад
        AutomatedTellerMachine atm4 = new AutomatedTellerMachine(4, "пр. Ленина 40", 4200, bank, 50.0128, 36.2301); // Северо-запад

        bank.AddATM(atm1);
        bank.AddATM(atm2);
        bank.AddATM(atm3);
        bank.AddATM(atm4);

        // Создаем два банковских счета и добавляем их в банк
        Account account1 = new Account("123", "Борис Олександрович", 1111, 1500);
        Account account2 = new Account("321", "Олена Володимирівна", 2222, 2000);
        bank.AddAccount(account1);
        bank.AddAccount(account2);


        // Подписываем обработчик события для всех аккаунтов в банке
        foreach (var account in bank.Accounts)
        {
            account.TransactionPerformed += transaction =>
            {
                Console.WriteLine($"Транзакція: {transaction.Type}, Сума: {transaction.Amount:C}");
            };
        }



        while (true)
        {
            CoordinateGenerator coordinateGenerator = new CoordinateGenerator();

            double userLatitude = coordinateGenerator.GenerateLatitude();
            double userLongitude = coordinateGenerator.GenerateLongitude();

            Console.WriteLine("Ласкаво просимо в банківську систему - JK.Corp!");

            Console.Write("\nБудь ласка, введіть номер картки -> ");
            string cardNumber = Console.ReadLine();

            Console.Write("Введіть пін-код -> ");
            int pin = int.Parse(Console.ReadLine());

            Console.Clear();

            // Ищем аккаунт пользователя по номеру карты
            Account userAccount = bank.FindAccountByCardNumber(cardNumber);

            // Проверяем аутентификацию пользователя
            if (userAccount != null && atm1.Authenticate(cardNumber, pin))
            {
                Console.WriteLine($"Ви успішно автентифікувалися, {userAccount.OwnerName}!");
                bool loggedIn = true;

                AutomatedTellerMachine randomATM = bank.GetRandomATM();

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
                            Console.WriteLine($"Доступно для зняття в банкоматі ({randomATM.Location}): {randomATM.CashBalance:C}");
                            Console.Write("\nВведіть суму для зняття -> ");

                            if (decimal.TryParse(Console.ReadLine(), out decimal withdrawAmount))
                            {
                                if (withdrawAmount <= randomATM.CashBalance) // Проверка доступных средств в банкомате
                                {
                                    Console.Clear();
                                    bool withdrawalSuccess = userAccount.Withdraw(withdrawAmount, true);

                                    if (withdrawalSuccess)
                                    {
                                        // Уменьшаем доступные средства в банкомате
                                        randomATM.CashBalance -= withdrawAmount;

                                        Console.WriteLine("\nОперація успішно виконана.");
                                        Console.Write("\nДля повернення на головне меню, натисніть будь-яку клавішу...");
                                        Console.ReadKey();
                                    }
                                    else
                                    {
                                        Console.Clear();
                                        Console.WriteLine("Недостатньо коштів на рахунку для здійснення операції.");
                                        Console.Write("\nДля повернення на головне меню, натисніть будь-яку клавішу...");
                                        Console.ReadKey();
                                    }
                                }
                                else
                                {
                                    Console.Clear();
                                    Console.WriteLine("Недостатньо коштів в банкоматі для здійснення операції.");
                                    Console.Write("\nДля повернення на головне меню, натисніть будь-яку клавішу...");
                                    Console.ReadKey();
                                }
                            }
                            else
                            {
                                Console.Clear();
                                Console.WriteLine("Невірний формат суми.");
                                Console.Write("\nДля повернення на головне меню, натисніть будь-яку клавішу...");
                                Console.ReadKey();
                            }
                            break;
                        case "3":
                            Console.Clear();
                            Console.WriteLine($"Баланс на рахунку: {userAccount.Balance:C}");
                            Console.Write("\nВведіть суму для зарахування -> ");
                            if (decimal.TryParse(Console.ReadLine(), out decimal depositAmount))
                            {
                                Console.Clear();
                                userAccount.Deposit(depositAmount, true);
                                // Добавляем доступные средства в банкомате
                                randomATM.CashBalance += depositAmount;
                                Console.WriteLine("\nОперація успішно виконана.");
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
                                // Проверяем, что получатель не является отправителем
                                if (userAccount.CardNumber == recipientAccount.CardNumber)
                                {
                                    Console.Clear();
                                    Console.WriteLine("Помилка: Неможливо перерахувати кошти на свій власний рахунок.");
                                    Console.Write("\nДля повернення на головне меню, натисніть будь-яку клавішу...");
                                    Console.ReadKey();
                                }
                                else
                                {
                                    Console.Write("Введіть суму для перерахування -> ");
                                    if (decimal.TryParse(Console.ReadLine(), out decimal transferAmount))
                                    {
                                        if (transferAmount > userAccount.Balance)
                                        {
                                            Console.Clear();
                                            Console.WriteLine("Помилка: Недостатньо коштів на рахунку для здійснення переводу.");
                                            Console.Write("\nДля повернення на головне меню, натисніть будь-яку клавішу...");
                                            Console.ReadKey();
                                        }
                                        else
                                        {
                                            Console.Clear();
                                            userAccount.Transfer(recipientAccount, transferAmount);

                                            Console.WriteLine("\nОперація успішно виконана.");
                                            Console.Write("\nДля повернення на головне меню, натисніть будь-яку клавішу...");
                                            Console.ReadKey();
                                        }
                                    }
                                    else
                                    {
                                        Console.Clear();
                                        Console.WriteLine("Невірний формат суми.");
                                        Console.Write("\nДля повернення на головне меню, натисніть будь-яку клавішу...");
                                        Console.ReadKey();
                                    }
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

                        case "6":
                            Console.Clear();
                            AutomatedTellerMachine nearestATM = bank.FindNearestATM(userLatitude, userLongitude);
                            if (nearestATM != null)
                            {
                                Console.WriteLine($"Найближчий банкомат: {nearestATM.Location}");
                                Console.WriteLine($"Розташування: {nearestATM.Latitude}, {nearestATM.Longitude}");

                                Console.WriteLine($"Ваше розташування: {userLatitude}, {userLongitude}");
                            }
                            else
                            {
                                Console.WriteLine("Не вдалося знайти найближчий банкомат.");
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
                Console.Write("\nДля продовження, натисніть будь-яку клавішу...");
                Console.ReadKey();
                Console.Clear();
            }
        }
    }
}
