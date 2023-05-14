namespace AlexCatze.StockManager.Client
{
    partial class MainForm
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
            this.things_types = new System.Windows.Forms.Button();
            this.dataGrid1 = new System.Windows.Forms.DataGrid();
            this.stock_label = new System.Windows.Forms.Label();
            this.new_item_button = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // things_types
            // 
            this.things_types.Location = new System.Drawing.Point(137, 232);
            this.things_types.Name = "things_types";
            this.things_types.Size = new System.Drawing.Size(98, 20);
            this.things_types.TabIndex = 0;
            this.things_types.Text = "Типи товарів";
            this.things_types.Click += new System.EventHandler(this.things_types_Click);
            // 
            // dataGrid1
            // 
            this.dataGrid1.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.dataGrid1.Location = new System.Drawing.Point(3, 3);
            this.dataGrid1.Name = "dataGrid1";
            this.dataGrid1.Size = new System.Drawing.Size(232, 200);
            this.dataGrid1.TabIndex = 1;
            // 
            // stock_label
            // 
            this.stock_label.Location = new System.Drawing.Point(3, 235);
            this.stock_label.Name = "stock_label";
            this.stock_label.Size = new System.Drawing.Size(100, 20);
            this.stock_label.Text = "label1";
            // 
            // new_item_button
            // 
            this.new_item_button.Location = new System.Drawing.Point(3, 209);
            this.new_item_button.Name = "new_item_button";
            this.new_item_button.Size = new System.Drawing.Size(72, 20);
            this.new_item_button.TabIndex = 2;
            this.new_item_button.Text = "New item";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(238, 255);
            this.Controls.Add(this.new_item_button);
            this.Controls.Add(this.stock_label);
            this.Controls.Add(this.dataGrid1);
            this.Controls.Add(this.things_types);
            this.Menu = this.mainMenu1;
            this.Name = "MainForm";
            this.Text = "Головне меню";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.GotFocus += new System.EventHandler(this.ThingTypesForm_GotFocus);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button things_types;
        private System.Windows.Forms.DataGrid dataGrid1;
        private System.Windows.Forms.Label stock_label;
        private System.Windows.Forms.Button new_item_button;
    }
}

