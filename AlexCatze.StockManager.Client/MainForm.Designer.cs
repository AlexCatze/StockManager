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
            this.SuspendLayout();
            // 
            // things_types
            // 
            this.things_types.Location = new System.Drawing.Point(3, 3);
            this.things_types.Name = "things_types";
            this.things_types.Size = new System.Drawing.Size(110, 40);
            this.things_types.TabIndex = 0;
            this.things_types.Text = "Типи товарів";
            this.things_types.Click += new System.EventHandler(this.things_types_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(238, 295);
            this.Controls.Add(this.things_types);
            this.Menu = this.mainMenu1;
            this.Name = "MainForm";
            this.Text = "Головне меню";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button things_types;
    }
}

