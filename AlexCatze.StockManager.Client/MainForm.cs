using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using AlexCatze.StockManager.Client.Models;

namespace AlexCatze.StockManager.Client
{
    public partial class MainForm : Form
    {
        public static Stock MyStock;

        public MainForm()
        {
            InitializeComponent();
            
        }

        private void things_types_Click(object sender, EventArgs e)
        {
            ThingTypesForm form = new ThingTypesForm();
            form.Show();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            new ConnectForm().Show();
        }
    }
}