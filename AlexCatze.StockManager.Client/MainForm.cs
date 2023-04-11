using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace AlexCatze.StockManager.Client
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void things_types_Click(object sender, EventArgs e)
        {
            ThingTypesForm form = new ThingTypesForm();
            form.Show();
        }
    }
}