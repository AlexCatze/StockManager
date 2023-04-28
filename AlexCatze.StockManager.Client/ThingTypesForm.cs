using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.IO;

namespace AlexCatze.StockManager.Client
{
    public partial class ThingTypesForm : Form
    {
        public ThingTypesForm()
        {
            InitializeComponent();
            DataTable table = new DataTable();
            table.Columns.Add("ID");
            table.Columns.Add("Назва");
            table.Columns.Add("Опис");

            List<ThingType> types = ServerConnector.GetThingTypes();
            if(types != null)
                foreach(ThingType t in types)
                    table.Rows.Add(t.Id,t.Name,t.Description);

            dataGrid1.DataSource = table;
        }

        private void back_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}