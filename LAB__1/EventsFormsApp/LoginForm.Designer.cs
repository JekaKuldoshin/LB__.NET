namespace EventsFormsApp
{
    partial class LoginForm
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
            button_login = new Button();
            txtCardNumber = new TextBox();
            label2 = new Label();
            txtPIN = new TextBox();
            label3 = new Label();
            groupBox1 = new GroupBox();
            groupBox2 = new GroupBox();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(20, 35);
            label1.Margin = new Padding(6, 0, 6, 0);
            label1.Name = "label1";
            label1.Size = new Size(149, 32);
            label1.TabIndex = 0;
            label1.Text = "Авторизація";
            // 
            // button_login
            // 
            button_login.Location = new Point(189, 546);
            button_login.Margin = new Padding(6);
            button_login.Name = "button_login";
            button_login.Size = new Size(139, 49);
            button_login.TabIndex = 1;
            button_login.Text = "Вхід";
            button_login.UseVisualStyleBackColor = true;
            button_login.Click += button_login_Click;
            // 
            // txtCardNumber
            // 
            txtCardNumber.Location = new Point(20, 95);
            txtCardNumber.Margin = new Padding(6);
            txtCardNumber.Name = "txtCardNumber";
            txtCardNumber.Size = new Size(182, 39);
            txtCardNumber.TabIndex = 2;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(20, 35);
            label2.Margin = new Padding(6, 0, 6, 0);
            label2.Name = "label2";
            label2.Size = new Size(170, 32);
            label2.TabIndex = 3;
            label2.Text = "Номер картки";
            // 
            // txtPIN
            // 
            txtPIN.Location = new Point(20, 225);
            txtPIN.Margin = new Padding(6);
            txtPIN.Name = "txtPIN";
            txtPIN.Size = new Size(182, 39);
            txtPIN.TabIndex = 4;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(20, 168);
            label3.Margin = new Padding(6, 0, 6, 0);
            label3.Name = "label3";
            label3.Size = new Size(96, 32);
            label3.TabIndex = 5;
            label3.Text = "Пароль";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(label1);
            groupBox1.Location = new Point(165, 75);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(182, 87);
            groupBox1.TabIndex = 6;
            groupBox1.TabStop = false;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(label2);
            groupBox2.Controls.Add(txtCardNumber);
            groupBox2.Controls.Add(label3);
            groupBox2.Controls.Add(txtPIN);
            groupBox2.Location = new Point(12, 204);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(400, 293);
            groupBox2.TabIndex = 7;
            groupBox2.TabStop = false;
            // 
            // LoginForm
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            ClientSize = new Size(526, 672);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Controls.Add(button_login);
            ForeColor = SystemColors.ControlText;
            Margin = new Padding(4, 2, 4, 2);
            Name = "LoginForm";
            Text = "Авторизація";
            Load += Form1_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Label label1;
        private Button button_login;
        private TextBox txtCardNumber;
        private Label label2;
        private TextBox txtPIN;
        private Label label3;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
    }
}