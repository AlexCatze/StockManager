namespace AlexCatze.StockManager.Client
{
    partial class ThingTypeForm
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
            this.back_button = new System.Windows.Forms.Button();
            this.save_button = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label_box = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.description_box = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // back_button
            // 
            this.back_button.Location = new System.Drawing.Point(163, 232);
            this.back_button.Name = "back_button";
            this.back_button.Size = new System.Drawing.Size(72, 20);
            this.back_button.TabIndex = 0;
            this.back_button.Text = "Назад";
            this.back_button.Click += new System.EventHandler(this.back_button_Click);
            // 
            // save_button
            // 
            this.save_button.Location = new System.Drawing.Point(3, 232);
            this.save_button.Name = "save_button";
            this.save_button.Size = new System.Drawing.Size(72, 20);
            this.save_button.TabIndex = 1;
            this.save_button.Text = "Зберегти";
            this.save_button.Click += new System.EventHandler(this.save_button_Click);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(3, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 20);
            this.label1.Text = "Назва: ";
            // 
            // label_box
            // 
            this.label_box.Location = new System.Drawing.Point(50, 3);
            this.label_box.Name = "label_box";
            this.label_box.Size = new System.Drawing.Size(185, 23);
            this.label_box.TabIndex = 3;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(50, 106);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(160, 120);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(3, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 20);
            this.label2.Text = "Опис: ";
            // 
            // description_box
            // 
            this.description_box.Location = new System.Drawing.Point(50, 29);
            this.description_box.Multiline = true;
            this.description_box.Name = "description_box";
            this.description_box.Size = new System.Drawing.Size(185, 71);
            this.description_box.TabIndex = 6;
            // 
            // ThingTypeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(238, 255);
            this.Controls.Add(this.description_box);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label_box);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.save_button);
            this.Controls.Add(this.back_button);
            this.Menu = this.mainMenu1;
            this.Name = "ThingTypeForm";
            this.Text = "ThingTypeForm";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button back_button;
        private System.Windows.Forms.Button save_button;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox label_box;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox description_box;
    }
}