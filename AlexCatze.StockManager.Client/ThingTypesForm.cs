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
        List<ThingType> types;
        public ThingTypesForm()
        {
            InitializeComponent();
            Refresh();
        }

        private void Refresh()
        {
            DataTable table = new DataTable();
            table.Columns.Add("ID");
            table.Columns.Add("Назва");
            table.Columns.Add("Опис");

            types = ServerConnector.GetThingTypes();
            if (types != null)
                foreach (ThingType t in types)
                    table.Rows.Add(t.Id, t.Name, t.Description);

            dataGrid1.DataSource = table;
        }

        private void back_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void delete_button_Click(object sender, EventArgs e)
        {
            ThingType type = types[dataGrid1.CurrentCell.RowNumber];
            DialogResult res = MessageBox.Show("Видалити тип товару \""+type.Name+"\"?","",MessageBoxButtons.YesNo,MessageBoxIcon.Question,MessageBoxDefaultButton.Button2);
            if (res == DialogResult.Yes)
            {
                ServerConnector.DeleteThingType(type);
            }
            Refresh();
        }

        private void about_button_Click(object sender, EventArgs e)
        {
            new ThingTypeForm(types[dataGrid1.CurrentCell.RowNumber]).Show();
            Refresh();
        }

        private void new_button_Click(object sender, EventArgs e)
        {
            new ThingTypeForm(new ThingType()).Show();
            Refresh();
        }

        private void ThingTypesForm_GotFocus(object sender, EventArgs e)
        {
            Refresh();
        }
    }
}