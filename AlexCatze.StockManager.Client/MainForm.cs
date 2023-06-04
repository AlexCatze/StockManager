using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using AlexCatze.StockManager.Client.Models;
using IT_3100_CsLib;
using System.Runtime.InteropServices;
using System.Threading;

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
                CheckStatus(CMOSLib.IMGInit());
                CheckStatus(CMOSLib.IMGConnect());
                CheckStatus(CMOSLib.IMGSetCode128(true,10,14));
            }
            catch (Exception e) { }
        }

        public static void CheckStatus(PrinterLib.PRNStatus status)
        {
            if (status != PrinterLib.PRNStatus.PRN_NORMAL) MessageBox.Show("Printer error: " + status.ToString());
        }

        public static void CheckStatus(CMOSLib.CMOSStatus status)
        {
            if (status != CMOSLib.CMOSStatus.IMG_SUCCESS) MessageBox.Show("CMOS imager error: " + status.ToString());
        }

        public static void CheckStatus(int status)
        {
            if (status != 0) MessageBox.Show("Error: " + status.ToString());
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
                CheckStatus(CMOSLib.IMGDisconnect());
                CheckStatus(CMOSLib.IMGDeinit());
            }
            catch (Exception ex) { }
        }

        public delegate Int32 ScanerCallbackDelegate();

        public Int32 ScanerCallback()
        {
            return 1;
        }

        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            if(MyStock==null)return;
            if (e.KeyCode == Keys.F21 || e.KeyCode == Keys.F24)
            {
                string pMessage, pCodeID, pAimID, pSymModifier;
                int pLength;
                byte[] data;
                ScanerCallbackDelegate del = new ScanerCallbackDelegate(ScanerCallback);
                CheckStatus(CMOSLib.IMGGetImage(out data, 640, 480, CMOSLib.ImageFormat.IMAGE_256MONO, 0));
                int res = CMOSLib.IMGWaitForDecode(1000, out pMessage, out pCodeID, out pAimID, out pSymModifier, out pLength, Marshal.GetFunctionPointerForDelegate(del));
                if (res == 10) return;
                CheckStatus(res);
                if (res != 0) return;

                Item item = ServerConnector.GetItem(new Item { Id = int.Parse(pMessage) });

                if (item == null)
                {
                    MessageBox.Show("Не вдалося знайти запис № " + pMessage);
                    return;
                }
                else
                {
                    new ItemViewForm(item).Show();

                }
            }
        }
    }
}