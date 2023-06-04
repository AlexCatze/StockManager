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
    public partial class ItemViewForm : Form
    {
        Item item;
        ThingType type;

        bool IsOnMyStock
        {
            get {
                return item.StockId == MainForm.MyStock.Id;
            }
        }
        
        public ItemViewForm(Item _item)
        {
            item = _item;
            InitializeComponent();
            type = ServerConnector.GetThingType(new ThingType { Id = item.TypeId });
            name_label.Text = type.Name + " №" + item.Id;

            DataTable table = new DataTable();
            table.Columns.Add("Дата та час");
            table.Columns.Add("Склад");
            table.Columns.Add("Дія");
            List<ItemTransaction> transactions = ServerConnector.GetItemTransactions(item);

            if (transactions != null)
            {
                Dictionary<long, Stock> stocksCache = new Dictionary<long, Stock>();
                foreach (ItemTransaction trans in transactions)
                {
                    if (!stocksCache.ContainsKey(trans.StockId))
                        stocksCache.Add(trans.StockId,ServerConnector.GetStock(new Stock{Id=trans.StockId}));

                    table.Rows.Add(trans.Timestamp.ToString("dd/MM/yyyy HH:mm:ss"), stocksCache[trans.StockId].Name, trans.Count > 0 ? "Прийнято" : "Відпущено");
                }
            }

            dataGrid1.DataSource = table;

            button2.Text = IsOnMyStock ? "Відпустити" : "Прийняти";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (IsOnMyStock)
            {
                ServerConnector.DeleteItem(item);
            }
            else
            {
                item.StockId = MainForm.MyStock.Id;
                ServerConnector.CreateItem(item);
            }

            Close();
        }
    }
}