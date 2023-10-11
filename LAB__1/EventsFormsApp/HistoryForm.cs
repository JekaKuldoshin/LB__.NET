using BankClassLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EventsFormsApp
{
    public partial class HistoryForm : Form
    {
        private Account userAccount;
        private Bank userBank;
        private AutomatedTellerMachine userrandomATM;

        public HistoryForm()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        // Конструктор, принимающий Account
        public HistoryForm(Account account, Bank bank, AutomatedTellerMachine randomATM) : this()
        {
            this.userAccount = account;
            this.userBank = bank;
            this.userrandomATM = randomATM;
        }

        private void btnViewTransactions_Click(object sender, EventArgs e)
        {
            DateTime startDate = startDatePicker.Value.Date;
            DateTime endDate = endDatePicker.Value.Date.AddDays(1).AddSeconds(-1); // Встановлюємо кінець дня

            List<Transaction> transactions = userAccount.GetTransactionsByPeriod(startDate, endDate);

            // Тепер ви можете відобразити transactions у вашому інтерфейсі (наприклад, у DataGridView або ListView)
            // Наприклад, якщо у вас є dataGridViewTransactions для відображення транзакцій:
            dataGridViewTransactions.DataSource = transactions;
        }

        private void HistoryForm_Load(object sender, EventArgs e)
        {

        }
    }
}
