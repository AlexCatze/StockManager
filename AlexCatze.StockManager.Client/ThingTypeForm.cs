using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace AlexCatze.StockManager.Client
{
    public partial class ThingTypeForm : Form
    {
        private ThingType type;
        public ThingTypeForm(ThingType _type)
        {
            type = _type;
            InitializeComponent();
            label_box.Text = type.Name;
            description_box.Text = type.Description;//TODO Image support
        }

        private void back_button_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void save_button_Click(object sender, EventArgs e)
        {
            type.Name = label_box.Text;
            type.Description = description_box.Text;
            ServerConnector.AddThingType(type);
            this.Close();
        }
    }
}