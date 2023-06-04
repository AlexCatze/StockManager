namespace AlexCatze.StockManager.Client
{
    partial class ThingTypesForm
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
            this.back = new System.Windows.Forms.Button();
            this.dataGrid1 = new System.Windows.Forms.DataGrid();
            this.delete_button = new System.Windows.Forms.Button();
            this.about_button = new System.Windows.Forms.Button();
            this.new_button = new System.Windows.Forms.Button();
            this.report_button = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // back
            // 
            this.back.Location = new System.Drawing.Point(163, 234);
            this.back.Name = "back";
            this.back.Size = new System.Drawing.Size(72, 20);
            this.back.TabIndex = 0;
            this.back.Text = "Назад";
            this.back.Click += new System.EventHandler(this.back_Click);
            // 
            // dataGrid1
            // 
            this.dataGrid1.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.dataGrid1.Location = new System.Drawing.Point(3, 3);
            this.dataGrid1.Name = "dataGrid1";
            this.dataGrid1.Size = new System.Drawing.Size(232, 200);
            this.dataGrid1.TabIndex = 1;
            // 
            // delete_button
            // 
            this.delete_button.Location = new System.Drawing.Point(163, 208);
            this.delete_button.Name = "delete_button";
            this.delete_button.Size = new System.Drawing.Size(72, 20);
            this.delete_button.TabIndex = 2;
            this.delete_button.Text = "Видалити";
            this.delete_button.Click += new System.EventHandler(this.delete_button_Click);
            // 
            // about_button
            // 
            this.about_button.Location = new System.Drawing.Point(85, 208);
            this.about_button.Name = "about_button";
            this.about_button.Size = new System.Drawing.Size(72, 20);
            this.about_button.TabIndex = 3;
            this.about_button.Text = "Деталі";
            this.about_button.Click += new System.EventHandler(this.about_button_Click);
            // 
            // new_button
            // 
            this.new_button.Location = new System.Drawing.Point(3, 208);
            this.new_button.Name = "new_button";
            this.new_button.Size = new System.Drawing.Size(72, 20);
            this.new_button.TabIndex = 4;
            this.new_button.Text = "Новий";
            this.new_button.Click += new System.EventHandler(this.new_button_Click);
            // 
            // report_button
            // 
            this.report_button.Location = new System.Drawing.Point(85, 234);
            this.report_button.Name = "report_button";
            this.report_button.Size = new System.Drawing.Size(72, 20);
            this.report_button.TabIndex = 5;
            this.report_button.Text = "Звіт";
            this.report_button.Click += new System.EventHandler(this.report_button_Click);
            // 
            // ThingTypesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(238, 258);
            this.Controls.Add(this.report_button);
            this.Controls.Add(this.new_button);
            this.Controls.Add(this.about_button);
            this.Controls.Add(this.delete_button);
            this.Controls.Add(this.dataGrid1);
            this.Controls.Add(this.back);
            this.Name = "ThingTypesForm";
            this.Text = "Типи товару";
            this.GotFocus += new System.EventHandler(this.ThingTypesForm_GotFocus);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button back;
        private System.Windows.Forms.DataGrid dataGrid1;
        private System.Windows.Forms.Button delete_button;
        private System.Windows.Forms.Button about_button;
        private System.Windows.Forms.Button new_button;
        private System.Windows.Forms.Button report_button;
    }
}