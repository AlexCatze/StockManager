namespace AlexCatze.StockManager.Client
{
    partial class ConnectForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.MainMenu mainMenu1;

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
            this.mainMenu1 = new System.Windows.Forms.MainMenu();
            this.check_connect_button = new System.Windows.Forms.Button();
            this.login_button = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // check_connect_button
            // 
            this.check_connect_button.Location = new System.Drawing.Point(163, 56);
            this.check_connect_button.Name = "check_connect_button";
            this.check_connect_button.Size = new System.Drawing.Size(72, 20);
            this.check_connect_button.TabIndex = 0;
            this.check_connect_button.Text = "З`єднати";
            this.check_connect_button.Click += new System.EventHandler(this.check_connect_button_Click);
            // 
            // login_button
            // 
            this.login_button.Enabled = false;
            this.login_button.Location = new System.Drawing.Point(122, 232);
            this.login_button.Name = "login_button";
            this.login_button.Size = new System.Drawing.Size(113, 20);
            this.login_button.TabIndex = 1;
            this.login_button.Text = "Увійти в систему";
            this.login_button.Click += new System.EventHandler(this.login_button_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(0, 27);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(235, 23);
            this.textBox1.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(3, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(109, 20);
            this.label1.Text = "Адреса серверу: ";
            // 
            // listBox1
            // 
            this.listBox1.Enabled = false;
            this.listBox1.Location = new System.Drawing.Point(0, 98);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(235, 130);
            this.listBox1.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(0, 75);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 20);
            this.label2.Text = "Склад:";
            // 
            // ConnectForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(238, 255);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.login_button);
            this.Controls.Add(this.check_connect_button);
            this.Menu = this.mainMenu1;
            this.Name = "ConnectForm";
            this.Text = "Вхід в систему";
            this.Deactivate += new System.EventHandler(this.ConnectForm_LostFocus);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button check_connect_button;
        private System.Windows.Forms.Button login_button;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Label label2;
    }
}