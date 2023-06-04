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
    public partial class ReportForm : Form
    {
        public ReportForm(ThingType type)
        {
            InitializeComponent();

            DataTable table = new DataTable();
            table.Columns.Add("ID товару");
            table.Columns.Add("Дата та час");
            table.Columns.Add("Дія");

            List<ItemTransaction> types = ServerConnector.GetTypeStockTransactions(new StockType {Stock = MainForm.MyStock, ThingType = type });
            if (types != null)
                foreach (ItemTransaction t in types)
                    table.Rows.Add(t.ItemId, t.Timestamp.ToString("dd/MM/yyyy HH:mm:ss"), t.Count > 0 ? "Прийнято" : "Відпущено");

            dataGrid1.DataSource = table;
        }

        private void back_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}