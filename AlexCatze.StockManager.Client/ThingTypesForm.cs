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

            WebRequest request = WebRequest.Create(Program.server_address + "Api/GetThings");
            request.Method = "POST";
            using (WebResponse response = request.GetResponse())//TODO catch network error
            using (Stream dataStream = response.GetResponseStream())
            using (StreamReader reader = new StreamReader(dataStream))
            {
                string responseFromServer = reader.ReadToEnd();
                // Display the content.
                Console.WriteLine(responseFromServer);
            }

            dataGrid1.DataSource = table;
        }

        private void back_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}