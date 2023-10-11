using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BankClassLibrary;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;

namespace EventsFormsApp
{ 
    public partial class MenuForm : Form
    {
        private Account userAccount;
        private Bank userBank;
        private AutomatedTellerMachine userrandomATM;
        private double USERLatitude;
        private double USERLongitude;

        public MenuForm()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        // Конструктор, принимающий Account
        public MenuForm(Account account, Bank bank, AutomatedTellerMachine randomATM, double userLatitude, double userLongitude) : this()
        {
            this.userAccount = account;
            this.userBank = bank;
            this.userrandomATM = randomATM;
            this.USERLatitude = userLatitude;
            this.USERLongitude = userLongitude;
        }

        private void MenuForm_Load(object sender, EventArgs e)
        {

            textBox1.Text = userAccount.Balance.ToString(); // Предполагается, что Balance - это свойство баланса в объекте Account
            textBox_CheckAmount.Text = userrandomATM.CashBalance.ToString();
            textBox_location.Text = userrandomATM.Location.ToString();
        }

        private void bttnAmount_Click(object sender, EventArgs e)
        {
            decimal withdrawAmount;
            if (decimal.TryParse(txtAmount.Text, out withdrawAmount))
            {
                // Получаем выбранный счет
                //Account account = bank.FindAccountByCardNumber(txtCardNumber.Text);
                if (userAccount != null)
                {
                    if (withdrawAmount <= userrandomATM.CashBalance) // Проверка доступных средств в банкомате
                    {
                        // Снимаем средства со счета
                        if (userAccount.Withdraw(withdrawAmount, true))
                        {
                            Refresh();
                            // Уменьшаем доступные средства в банкомате
                            userrandomATM.CashBalance -= withdrawAmount;
                            MessageBox.Show($"Кошти в сумі {withdrawAmount} успішно знято з рахунку.");
                            textBox1.Text = userAccount.Balance.ToString(); // Предполагается, что Balance - это свойство баланса в объекте Account
                            textBox_CheckAmount.Text = userrandomATM.CashBalance.ToString();

                        }
                        else
                        {
                            MessageBox.Show("Недостатньо коштів на рахунку.");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Недостатньо коштів у банкоматі для здійснення операції.");
                    }
                }
                else
                {
                    MessageBox.Show("Рахунок не знайдено.");
                }
            }
            else
            {
                // Неверный формат суммы
                MessageBox.Show("Неправильний формат суми.");
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            // Устанавливаем текст в textBox1 равным балансу пользователя
            textBox1.Text = userAccount.Balance.ToString(); // Предполагается, что Balance - это свойство баланса в объекте Account
        }

        private void bttn_depositAmount_Click(object sender, EventArgs e)
        {
            decimal depositAmount;
            if (decimal.TryParse(textBox_deposit.Text, out depositAmount))
            {
                // Проверяем, что пользовательский аккаунт был установлен
                if (userAccount != null)
                {

                    // Уменьшаем доступные средства в банкомате
                    userrandomATM.CashBalance += depositAmount;

                    // Зачисляем средства на счет
                    userAccount.Deposit(depositAmount, true);

                    // Обновляем данные на форме
                    Refresh();

                    // Показываем сообщение об успешной операции
                    MessageBox.Show($"Кошти в сумі {depositAmount} успішно зараховані на рахунок.");

                    // Обновляем текст в textBox1 с балансом пользователя
                    textBox1.Text = userAccount.Balance.ToString();

                    textBox_CheckAmount.Text = userrandomATM.CashBalance.ToString();

                }
                else
                {
                    MessageBox.Show("Рахунок не знайдено.");
                }
            }
            else
            {
                // Неверный формат суммы
                MessageBox.Show("Неправильний розмір суми.");
            }
        }

        private void bttntransfer_Click(object sender, EventArgs e)
        {
            decimal amount;
            string recipientCardNumber = txtRecipientCardNumber.Text;

            if (decimal.TryParse(txtAmount_transfer.Text, out amount) && !string.IsNullOrEmpty(recipientCardNumber))
            {
                // Проверяем, что пользовательский аккаунт был установлен
                if (userAccount != null)
                {
                    // Получаем аккаунт получателя по номеру карты
                    Account recipientAccount = userBank.FindAccountByCardNumber(recipientCardNumber);
                    if (recipientAccount != null)
                    {
                        if (userAccount.CardNumber != recipientCardNumber)
                        {
                            // Осуществляем перевод средств со счета пользователя на счет получателя
                            if (userAccount.Withdraw(amount, false))
                            {
                                userAccount.Transfer(recipientAccount, amount);
                                //recipientAccount.Deposit(amount, false);

                                // Обновляем данные на форме
                                Refresh();

                                // Показываем сообщение об успешной операции
                                MessageBox.Show($"Кошти в сумі {amount} успішно перераховані на рахунок картки {recipientCardNumber}.");

                                // Обновляем текст в textBox1 с балансом пользователя
                                textBox1.Text = userAccount.Balance.ToString();
                            }
                            else
                            {
                                MessageBox.Show("Недостатньо коштів на рахунку.");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Помилка! Ви не можете надсилати кошти на свою карту. Перевірте введені дані.");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Карта одержувача не знайдено.");
                    }
                }
                else
                {
                    MessageBox.Show("Рахунок відправника не знайдено.");
                }
            }
            else
            {
                // Неверный формат суммы или пустой номер карты получателя
                MessageBox.Show("Будь ласка, введіть коректну суму та номер картки одержувача.");
            }
        }

        private void textBox_location_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            HistoryForm historyForm = new HistoryForm(userAccount, userBank, userrandomATM); // Передаем данные в конструктор новой формы
                                                                                             //this.Close(); // Закрываем текущую форму
            historyForm.Show(); // Открываем новую форму
        }

        private void button2_Click(object sender, EventArgs e)
        {
            TellerMachineForm atmForm = new TellerMachineForm(userBank, USERLatitude, USERLongitude); // Передаем данные в конструктор новой формы
                                                                                                          //this.Close(); // Закрываем текущую форму
            atmForm.Show(); // Открываем новую форму
        }
    }
}
