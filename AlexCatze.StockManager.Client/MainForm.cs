using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using AlexCatze.StockManager.Client.Models;
using IT_3100_CsLib;

namespace AlexCatze.StockManager.Client
{
    public partial class MainForm : Form
    {
        public static Stock MyStock;
        public static ConnectForm connForm;

        public MainForm()
        {
            InitializeComponent();
            try
            {
                CheckStatus(PrinterLib.PRNOpen());
                
            }
            catch (Exception e) { }
        }

        public static void CheckStatus(PrinterLib.PRNStatus status)
        {
            if (status != PrinterLib.PRNStatus.PRN_NORMAL) MessageBox.Show("Printer error: " + status.ToString());
        }

        private void things_types_Click(object sender, EventArgs e)
        {
            ThingTypesForm form = new ThingTypesForm();
            form.Show();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            new ConnectForm(this).Show();
            this.Hide();
        }

        private void ThingTypesForm_GotFocus(object sender, EventArgs e)
        {
            if (MyStock == null)
                return;

            stock_label.Text = MyStock.Name;

            DataTable table = new DataTable();
            table.Columns.Add("Тип");
            table.Columns.Add("Кількість");

            Dictionary<long, int> counts = new Dictionary<long, int>();

            List<Item> items = ServerConnector.GetItemsOnStock(MyStock);
            if (items != null)
                foreach (Item i in items)
                {
                    if (counts.ContainsKey(i.TypeId))
                        counts[i.TypeId]++;
                    else
                        counts.Add(i.TypeId,1);
                }

            Dictionary<long,ThingType> types = new Dictionary<long,ThingType>() ;

            foreach (ThingType t in ServerConnector.GetThingTypes())
                types.Add(t.Id, t);

            foreach (KeyValuePair<long, int> kv in counts)
            {
                table.Rows.Add(types[kv.Key].Name, kv.Value);
            }

            dataGrid1.DataSource = table;
        }

        private void new_item_button_Click(object sender, EventArgs e)
        {
            new AddThingForm().Show();
        }

        private void MainForm_Closing(object sender, CancelEventArgs e)
        {
            try
            {
                CheckStatus(PrinterLib.PRNClose());

            }
            catch (Exception ex) { }
        }

        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            MessageBox.Show(e.KeyCode.ToString());
        }

        private void MainForm_KeyDown(object sender, KeyPressEventArgs e)
        {
            MessageBox.Show(e.KeyChar.ToString());
        }
    }
}