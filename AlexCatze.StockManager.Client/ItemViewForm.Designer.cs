namespace AlexCatze.StockManager.Client
{
    partial class ItemViewForm
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
            this.name_label = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGrid1 = new System.Windows.Forms.DataGrid();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // name_label
            // 
            this.name_label.Location = new System.Drawing.Point(3, 0);
            this.name_label.Name = "name_label";
            this.name_label.Size = new System.Drawing.Size(235, 20);
            this.name_label.Text = "label1";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(3, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 20);
            this.label1.Text = "Історія";
            // 
            // dataGrid1
            // 
            this.dataGrid1.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.dataGrid1.Location = new System.Drawing.Point(3, 43);
            this.dataGrid1.Name = "dataGrid1";
            this.dataGrid1.Size = new System.Drawing.Size(232, 175);
            this.dataGrid1.TabIndex = 2;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(163, 232);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(72, 20);
            this.button1.TabIndex = 3;
            this.button1.Text = "Скасувати";
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(3, 232);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(99, 20);
            this.button2.TabIndex = 4;
            this.button2.Text = "button2";
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // ItemViewForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(238, 255);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dataGrid1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.name_label);
            this.Name = "ItemViewForm";
            this.Text = "Перегляд товару";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label name_label;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGrid dataGrid1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}