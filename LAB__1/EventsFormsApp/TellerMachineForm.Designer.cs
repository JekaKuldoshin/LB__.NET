namespace EventsFormsApp
{
    partial class TellerMachineForm
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
            dataGridViewATMs = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dataGridViewATMs).BeginInit();
            SuspendLayout();
            // 
            // dataGridViewATMs
            // 
            dataGridViewATMs.AllowUserToAddRows = false;
            dataGridViewATMs.AllowUserToDeleteRows = false;
            dataGridViewATMs.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewATMs.Location = new Point(12, 21);
            dataGridViewATMs.Name = "dataGridViewATMs";
            dataGridViewATMs.ReadOnly = true;
            dataGridViewATMs.RowHeadersWidth = 82;
            dataGridViewATMs.RowTemplate.Height = 41;
            dataGridViewATMs.Size = new Size(1276, 661);
            dataGridViewATMs.TabIndex = 0;
            // 
            // TellerMachineForm
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1300, 694);
            Controls.Add(dataGridViewATMs);
            Name = "TellerMachineForm";
            Text = "Найближчі банкомати";
            Load += TellerMachineForm_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridViewATMs).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dataGridViewATMs;
    }
}