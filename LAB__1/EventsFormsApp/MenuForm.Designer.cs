namespace EventsFormsApp
{
    partial class MenuForm
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
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            txtAmount = new TextBox();
            bttnAmount = new Button();
            textBox1 = new TextBox();
            textBox_deposit = new TextBox();
            groupBox1 = new GroupBox();
            groupBox2 = new GroupBox();
            groupBox3 = new GroupBox();
            bttn_depositAmount = new Button();
            groupBox4 = new GroupBox();
            label9 = new Label();
            label7 = new Label();
            txtAmount_transfer = new TextBox();
            bttn_transfer = new Button();
            txtRecipientCardNumber = new TextBox();
            label10 = new Label();
            textBox_CheckAmount = new TextBox();
            textBox_location = new TextBox();
            groupBox5 = new GroupBox();
            label12 = new Label();
            label11 = new Label();
            groupBox6 = new GroupBox();
            bttn_history = new Button();
            groupBox7 = new GroupBox();
            bttn_atm = new Button();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox3.SuspendLayout();
            groupBox4.SuspendLayout();
            groupBox5.SuspendLayout();
            groupBox6.SuspendLayout();
            groupBox7.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(70, 38);
            label1.Name = "label1";
            label1.Size = new Size(90, 32);
            label1.TabIndex = 0;
            label1.Text = "Баланс";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(36, 35);
            label2.Name = "label2";
            label2.Size = new Size(153, 32);
            label2.TabIndex = 1;
            label2.Text = "Зняти кошти";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(42, 35);
            label3.Name = "label3";
            label3.Size = new Size(213, 32);
            label3.TabIndex = 2;
            label3.Text = "Зарахувати кошти";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(75, 35);
            label4.Name = "label4";
            label4.Size = new Size(378, 32);
            label4.TabIndex = 3;
            label4.Text = "Перерахування коштів на картку";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(15, 35);
            label5.Name = "label5";
            label5.Size = new Size(369, 32);
            label5.TabIndex = 4;
            label5.Text = "Переглянути історію транзакцій";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(6, 35);
            label6.Name = "label6";
            label6.Size = new Size(394, 32);
            label6.TabIndex = 5;
            label6.Text = "Перегляд найближчих банкоматів";
            // 
            // txtAmount
            // 
            txtAmount.Location = new Point(18, 88);
            txtAmount.Name = "txtAmount";
            txtAmount.Size = new Size(184, 39);
            txtAmount.TabIndex = 8;
            // 
            // bttnAmount
            // 
            bttnAmount.Location = new Point(18, 148);
            bttnAmount.Name = "bttnAmount";
            bttnAmount.Size = new Size(186, 46);
            bttnAmount.TabIndex = 9;
            bttnAmount.Text = "Зняти кошти";
            bttnAmount.UseVisualStyleBackColor = true;
            bttnAmount.Click += bttnAmount_Click;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(20, 82);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(186, 39);
            textBox1.TabIndex = 10;
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // textBox_deposit
            // 
            textBox_deposit.Location = new Point(43, 85);
            textBox_deposit.Name = "textBox_deposit";
            textBox_deposit.Size = new Size(186, 39);
            textBox_deposit.TabIndex = 11;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(textBox1);
            groupBox1.Location = new Point(73, 40);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(224, 156);
            groupBox1.TabIndex = 12;
            groupBox1.TabStop = false;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(label2);
            groupBox2.Controls.Add(txtAmount);
            groupBox2.Controls.Add(bttnAmount);
            groupBox2.Location = new Point(73, 238);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(224, 211);
            groupBox2.TabIndex = 13;
            groupBox2.TabStop = false;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(bttn_depositAmount);
            groupBox3.Controls.Add(label3);
            groupBox3.Controls.Add(textBox_deposit);
            groupBox3.Location = new Point(46, 495);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(280, 200);
            groupBox3.TabIndex = 14;
            groupBox3.TabStop = false;
            // 
            // bttn_depositAmount
            // 
            bttn_depositAmount.Location = new Point(25, 140);
            bttn_depositAmount.Name = "bttn_depositAmount";
            bttn_depositAmount.Size = new Size(230, 46);
            bttn_depositAmount.TabIndex = 12;
            bttn_depositAmount.Text = "Зарахувати кошти";
            bttn_depositAmount.UseVisualStyleBackColor = true;
            bttn_depositAmount.Click += bttn_depositAmount_Click;
            // 
            // groupBox4
            // 
            groupBox4.Controls.Add(label9);
            groupBox4.Controls.Add(label7);
            groupBox4.Controls.Add(txtAmount_transfer);
            groupBox4.Controls.Add(bttn_transfer);
            groupBox4.Controls.Add(txtRecipientCardNumber);
            groupBox4.Controls.Add(label4);
            groupBox4.Location = new Point(450, 40);
            groupBox4.Name = "groupBox4";
            groupBox4.Size = new Size(488, 335);
            groupBox4.TabIndex = 15;
            groupBox4.TabStop = false;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 7.875F, FontStyle.Regular, GraphicsUnit.Point);
            label9.Location = new Point(25, 172);
            label9.Name = "label9";
            label9.Size = new Size(142, 60);
            label9.TabIndex = 8;
            label9.Text = "Сума\r\nдля переводу";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 7.875F, FontStyle.Regular, GraphicsUnit.Point);
            label7.Location = new Point(25, 98);
            label7.Name = "label7";
            label7.Size = new Size(78, 60);
            label7.TabIndex = 7;
            label7.Text = "Номер\r\nкартки";
            // 
            // txtAmount_transfer
            // 
            txtAmount_transfer.Location = new Point(187, 193);
            txtAmount_transfer.Name = "txtAmount_transfer";
            txtAmount_transfer.Size = new Size(200, 39);
            txtAmount_transfer.TabIndex = 6;
            // 
            // bttn_transfer
            // 
            bttn_transfer.Location = new Point(135, 270);
            bttn_transfer.Name = "bttn_transfer";
            bttn_transfer.Size = new Size(239, 46);
            bttn_transfer.TabIndex = 5;
            bttn_transfer.Text = "Перерахувати";
            bttn_transfer.UseVisualStyleBackColor = true;
            bttn_transfer.Click += bttntransfer_Click;
            // 
            // txtRecipientCardNumber
            // 
            txtRecipientCardNumber.Location = new Point(187, 101);
            txtRecipientCardNumber.Name = "txtRecipientCardNumber";
            txtRecipientCardNumber.Size = new Size(200, 39);
            txtRecipientCardNumber.TabIndex = 4;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(19, 35);
            label10.Name = "label10";
            label10.Size = new Size(379, 32);
            label10.TabIndex = 16;
            label10.Text = "Доступно для зняття в банкоматі";
            // 
            // textBox_CheckAmount
            // 
            textBox_CheckAmount.Location = new Point(127, 144);
            textBox_CheckAmount.Name = "textBox_CheckAmount";
            textBox_CheckAmount.ReadOnly = true;
            textBox_CheckAmount.Size = new Size(271, 39);
            textBox_CheckAmount.TabIndex = 17;
            // 
            // textBox_location
            // 
            textBox_location.Location = new Point(127, 82);
            textBox_location.Name = "textBox_location";
            textBox_location.ReadOnly = true;
            textBox_location.Size = new Size(271, 39);
            textBox_location.TabIndex = 18;
            textBox_location.TextChanged += textBox_location_TextChanged;
            // 
            // groupBox5
            // 
            groupBox5.Controls.Add(label12);
            groupBox5.Controls.Add(label11);
            groupBox5.Controls.Add(label10);
            groupBox5.Controls.Add(textBox_CheckAmount);
            groupBox5.Controls.Add(textBox_location);
            groupBox5.Location = new Point(1083, 40);
            groupBox5.Name = "groupBox5";
            groupBox5.Size = new Size(422, 200);
            groupBox5.TabIndex = 19;
            groupBox5.TabStop = false;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(19, 147);
            label12.Name = "label12";
            label12.Size = new Size(78, 32);
            label12.TabIndex = 20;
            label12.Text = "Гроші";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Segoe UI", 7.875F, FontStyle.Regular, GraphicsUnit.Point);
            label11.Location = new Point(19, 87);
            label11.Name = "label11";
            label11.Size = new Size(82, 30);
            label11.TabIndex = 19;
            label11.Text = "Адреса";
            // 
            // groupBox6
            // 
            groupBox6.Controls.Add(bttn_history);
            groupBox6.Controls.Add(label5);
            groupBox6.Location = new Point(503, 419);
            groupBox6.Name = "groupBox6";
            groupBox6.Size = new Size(400, 200);
            groupBox6.TabIndex = 20;
            groupBox6.TabStop = false;
            // 
            // bttn_history
            // 
            bttn_history.Location = new Point(74, 111);
            bttn_history.Name = "bttn_history";
            bttn_history.Size = new Size(252, 64);
            bttn_history.TabIndex = 5;
            bttn_history.Text = "Історія транзакцій";
            bttn_history.UseVisualStyleBackColor = true;
            bttn_history.Click += button1_Click;
            // 
            // groupBox7
            // 
            groupBox7.Controls.Add(bttn_atm);
            groupBox7.Controls.Add(label6);
            groupBox7.Location = new Point(1092, 419);
            groupBox7.Name = "groupBox7";
            groupBox7.Size = new Size(400, 200);
            groupBox7.TabIndex = 21;
            groupBox7.TabStop = false;
            // 
            // bttn_atm
            // 
            bttn_atm.Location = new Point(74, 111);
            bttn_atm.Name = "bttn_atm";
            bttn_atm.Size = new Size(282, 64);
            bttn_atm.TabIndex = 6;
            bttn_atm.Text = "Найближчий банкомат";
            bttn_atm.UseVisualStyleBackColor = true;
            bttn_atm.Click += button2_Click;
            // 
            // MenuForm
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            ClientSize = new Size(1589, 960);
            Controls.Add(groupBox7);
            Controls.Add(groupBox6);
            Controls.Add(groupBox5);
            Controls.Add(groupBox4);
            Controls.Add(groupBox3);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Margin = new Padding(6);
            Name = "MenuForm";
            Text = "Меню";
            Load += MenuForm_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            groupBox4.ResumeLayout(false);
            groupBox4.PerformLayout();
            groupBox5.ResumeLayout(false);
            groupBox5.PerformLayout();
            groupBox6.ResumeLayout(false);
            groupBox6.PerformLayout();
            groupBox7.ResumeLayout(false);
            groupBox7.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private TextBox txtAmount;
        private Button bttnAmount;
        private TextBox textBox1;
        private TextBox textBox_deposit;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private GroupBox groupBox3;
        private Button bttn_depositAmount;
        private GroupBox groupBox4;
        private Label label7;
        private TextBox txtAmount_transfer;
        private Button bttn_transfer;
        private TextBox txtRecipientCardNumber;
        private Label label9;
        private Label label10;
        private TextBox textBox_CheckAmount;
        private TextBox textBox_location;
        private GroupBox groupBox5;
        private Label label12;
        private Label label11;
        private GroupBox groupBox6;
        private Button bttn_history;
        private GroupBox groupBox7;
        private Button bttn_atm;
    }
}