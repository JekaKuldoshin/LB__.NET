namespace EventsFormsApp
{
    partial class HistoryForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            startDatePicker = new DateTimePicker();
            endDatePicker = new DateTimePicker();
            btnViewTransactions = new Button();
            dataGridViewTransactions = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dataGridViewTransactions).BeginInit();
            SuspendLayout();
            // 
            // startDatePicker
            // 
            startDatePicker.Location = new Point(12, 26);
            startDatePicker.Name = "startDatePicker";
            startDatePicker.Size = new Size(255, 39);
            startDatePicker.TabIndex = 0;
            // 
            // endDatePicker
            // 
            endDatePicker.Location = new Point(300, 26);
            endDatePicker.Name = "endDatePicker";
            endDatePicker.Size = new Size(253, 39);
            endDatePicker.TabIndex = 1;
            // 
            // btnViewTransactions
            // 
            btnViewTransactions.Location = new Point(600, 23);
            btnViewTransactions.Name = "btnViewTransactions";
            btnViewTransactions.Size = new Size(184, 48);
            btnViewTransactions.TabIndex = 2;
            btnViewTransactions.Text = "Оновити";
            btnViewTransactions.UseVisualStyleBackColor = true;
            btnViewTransactions.Click += btnViewTransactions_Click;
            // 
            // dataGridViewTransactions
            // 
            dataGridViewTransactions.AllowUserToAddRows = false;
            dataGridViewTransactions.AllowUserToDeleteRows = false;
            dataGridViewTransactions.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewTransactions.Location = new Point(12, 94);
            dataGridViewTransactions.Name = "dataGridViewTransactions";
            dataGridViewTransactions.ReadOnly = true;
            dataGridViewTransactions.RowHeadersWidth = 82;
            dataGridViewTransactions.RowTemplate.Height = 41;
            dataGridViewTransactions.Size = new Size(679, 595);
            dataGridViewTransactions.TabIndex = 3;
            // 
            // HistoryForm
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1178, 701);
            Controls.Add(dataGridViewTransactions);
            Controls.Add(btnViewTransactions);
            Controls.Add(endDatePicker);
            Controls.Add(startDatePicker);
            Name = "HistoryForm";
            Text = "Історія транзакцій";
            ((System.ComponentModel.ISupportInitialize)dataGridViewTransactions).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DateTimePicker startDatePicker;
        private DateTimePicker endDatePicker;
        private Button btnViewTransactions;
        private DataGridView dataGridViewTransactions;
    }
}