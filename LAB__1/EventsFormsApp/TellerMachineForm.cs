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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;

namespace EventsFormsApp
{
    public partial class TellerMachineForm : Form
    {
        private Bank bank2;
        private double userLatitude;
        private double userLongitude;

        public TellerMachineForm()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        public TellerMachineForm(Bank bank1, double USERLatitude, double USERLongitude) : this()
        {
            this.userLatitude = USERLatitude;
            this.userLongitude = USERLongitude;
            this.bank2 = bank1;
        }


        private void TellerMachineForm_Load(object sender, EventArgs e)
        {

            // Добавьте столбцы к DataGridView
            dataGridViewATMs.Columns.Add("Id", "ID");
            dataGridViewATMs.Columns.Add("Location", "Розташування");
            dataGridViewATMs.Columns.Add("Latitude", "Широта");
            dataGridViewATMs.Columns.Add("Longitude", "Довгота");
            dataGridViewATMs.Columns.Add("CashBalance", "Баланс");

            AutomatedTellerMachine nearestATM = bank2.FindNearestATM(userLatitude, userLongitude);

            // Очистите предыдущие данные в DataGridView
            dataGridViewATMs.Rows.Clear();

            // Отобразите данные о ближайшем банкомате
            if (nearestATM != null)
            {
                // Добавьте строку с данными о ближайшем банкомате
                dataGridViewATMs.Rows.Add(nearestATM.Id, nearestATM.Location, nearestATM.Latitude, nearestATM.Longitude, nearestATM.CashBalance);
            }
            else
            {
                MessageBox.Show("Найближчий банкомат не знайдено.");
            }
        }
    }
}