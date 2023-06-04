using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using AlexCatze.StockManager.Client.Models;
using IT_3100_CsLib;
using System.IO;
using System.Reflection;

namespace AlexCatze.StockManager.Client
{
    public partial class AddThingForm : Form
    {
        List<ThingType> types;

        public AddThingForm()
        {
            InitializeComponent();
            types = ServerConnector.GetThingTypes();
            foreach (ThingType type in types)
                comboBox1.Items.Add(type.Name);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex < 0) return;
            Item item = ServerConnector.CreateItem(new Item { TypeId = types[comboBox1.SelectedIndex].Id, StockId = MainForm.MyStock.Id });
            if(item != null)
            {
                MainForm.CheckStatus(PrinterLib.PRNTextOut("Товар: " + types[comboBox1.SelectedIndex].Name));
                MainForm.CheckStatus(PrinterLib.PRNTextOut("Склад прийняття: " + MainForm.MyStock.Name));

                string barcode = item.Id.ToString();
                while (barcode.Length < 12)
                    barcode = "0"+barcode;
                MainForm.CheckStatus(PrinterLib.PRNBarcodeOut(PrinterLib.codeType.Code128, 20, true, PrinterLib.fontType.ANK8x16, 0, PrinterLib.direction.VERTICAL, barcode));

                string path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().GetName().CodeBase), "logo.bin");

                if (File.Exists(path))
                {
                    FileStream file = File.OpenRead(path);
                    byte[] data = new byte[(int)file.Length];
                    file.Read(data, 0, (int)file.Length);
                    file.Close();
                    if (data.Length % 72 == 0)
                        MainForm.CheckStatus(PrinterLib.PRNImageOut(72, (uint)(data.Length / 72), 10, data));
                }

                MainForm.CheckStatus(PrinterLib.SkipLines(3));
            }
            else
            {
                MessageBox.Show("Сталася помилка!");
            }
            this.Close();
        }
    }
}