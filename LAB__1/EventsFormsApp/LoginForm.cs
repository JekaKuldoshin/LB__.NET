using System;
using System.Windows.Forms;
using BankClassLibrary;

namespace EventsFormsApp
{
    public partial class LoginForm : Form
    {
        private Bank bank;

        public LoginForm()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;

            // Создаем банк
            this.bank = new Bank("MyBank");

            // Создаем несколько банкоматов и добавляем их в банк
            AutomatedTellerMachine atm1 = new AutomatedTellerMachine(5, "пр. Науки 14", 3000, bank, 50.0045, 36.2275); // Центр
            AutomatedTellerMachine atm2 = new AutomatedTellerMachine(6, "пр. Московский 199", 4500, bank, 50.0112, 36.2267); // Северо-восток
            AutomatedTellerMachine atm3 = new AutomatedTellerMachine(7, "пр. Гагарина 175", 3800, bank, 49.9808, 36.2536); // Юго-запад
            AutomatedTellerMachine atm4 = new AutomatedTellerMachine(8, "пр. Науки 40", 4200, bank, 50.0128, 36.2301); // Северо-запад

            bank.AddATM(atm1);
            bank.AddATM(atm2);
            bank.AddATM(atm3);
            bank.AddATM(atm4);

            // Создаем два банковских счета и добавляем их в банк
            Account account1 = new Account("123", "Борис Олександрович", 1111, 15000);
            Account account2 = new Account("321", "Олена Володимирівна", 2222, 2000);
            bank.AddAccount(account1);
            bank.AddAccount(account2);



           

            

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }


        private void button_login_Click(object sender, EventArgs e)
        {
            CoordinateGenerator coordinateGenerator = new CoordinateGenerator();
            double userLatitude = coordinateGenerator.GenerateLatitude();
            double userLongitude = coordinateGenerator.GenerateLongitude();

            string cardNumber = txtCardNumber.Text;
            int pin;
            if (int.TryParse(txtPIN.Text, out pin))
            {
                Account account = bank.FindAccountByCardNumber(cardNumber);
                if (account != null && account.Pin == pin)
                {
                    // Аутентификация прошла успешно
                    MessageBox.Show($"Ласкаво просимо, {account.OwnerName}!");

                    AutomatedTellerMachine randomATM = bank.GetRandomATM();

                    // Создаем новую форму
                    MenuForm menuForm = new MenuForm(account, bank, randomATM, userLatitude, userLongitude); // Передаем данные в конструктор новой формы
                    //this.Close(); // Закрываем текущую форму
                    menuForm.Show(); // Открываем новую форму




                }
                else
                {
                    // Неверный номер карты или пин-код
                    MessageBox.Show("Невірний номер картки або пін-код.");
                }
            }
            else
            {
                // Неверный формат пин-кода
                MessageBox.Show("Некоректний ввод пін-кода.");
            }
        }

    }
}
