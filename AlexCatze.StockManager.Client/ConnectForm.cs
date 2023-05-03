using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using AlexCatze.StockManager.Client.Models;

namespace AlexCatze.StockManager.Client
{
    public partial class ConnectForm : Form
    {
        public ConnectForm()
        {
            InitializeComponent();
            if(File.Exists("\\server.dat"))
            {
                StringBuilder sb = new StringBuilder();
                using (StreamReader sr = new StreamReader("\\server.dat"))
                {
                    //String line;
                    // Read and display lines from the file until the end of 
                    // the file is reached.
                    //while ((line = sr.ReadLine()) != null)
                    //{
                    //    sb.AppendLine(line);
                    //}
                    textBox1.Text = sr.ReadLine();
                }
                //textBox1.Text = sb.ToString();
            }
        }

        private void check_connect_button_Click(object sender, EventArgs e)
        {
            ServerConnector.server_address = textBox1.Text;

            List<Stock> stocks = ServerConnector.GetStocks();

            if (stocks == null)
            {
                MessageBox.Show("Помилка мережі!");
                return; 
            }

            using (StreamWriter sw = new StreamWriter("\\server.dat"))
            {
                sw.WriteLine(textBox1.Text);
            }

            for (int i = 0; i < stocks.Count; i++)
            {
                listBox1.Items.Insert(i,stocks[i]);
            }
            check_connect_button.Enabled = false;
            listBox1.Enabled = true;
            login_button.Enabled = true;
        }

        private void ConnectForm_LostFocus(object sender, EventArgs e)
        {
            this.Activate();
        }

        private void login_button_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem == null) return;
            MainForm.MyStock = (Stock)listBox1.SelectedItem;
            this.Close();
        }
    }
}