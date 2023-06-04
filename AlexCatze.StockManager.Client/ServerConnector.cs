using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;
using System.Net;
using System.IO;
using System.Windows.Forms;
using AlexCatze.StockManager.Client.Models;

namespace AlexCatze.StockManager.Client
{
    class ServerConnector
    {
        public static string server_address = "";

        private static void ShowWebError(Exception ex)
        {
            MessageBox.Show("Помилка мережі: "+ex.Message);
        }

        private static string Request(string endpoint, string body)
        {
            try
            {
                if(!server_address.EndsWith("/")) server_address+="/";
                WebRequest request = WebRequest.Create(server_address + endpoint);
                request.Method = "POST";

                if (body != null)
                {
                    UTF8Encoding encoding = new UTF8Encoding();
                    byte[] data = encoding.GetBytes(body);
                    request.ContentLength = data.Length;
                    using (var stream = request.GetRequestStream())
                        stream.Write(data,0,data.Length);
                }

                using (WebResponse response = request.GetResponse())
                using (Stream dataStream = response.GetResponseStream())
                using (StreamReader reader = new StreamReader(dataStream))
                {
                    string responseFromServer = reader.ReadToEnd();
                    return responseFromServer;
                }
            }
            catch (Exception ex)
            {
                ShowWebError(ex);
                return null;
            }
        }

        public static List<ThingType> GetThingTypes()
        {
            string res = Request("Api/GetThings",null);
            if (res == null) return null;
            return JsonConvert.DeserializeObject<List<ThingType>>(res);
        }

        public static ThingType GetThingType(ThingType pattern)
        {
            string res = Request("Api/GetThing", JsonConvert.SerializeObject(pattern));
            if (res == null) return null;
            return JsonConvert.DeserializeObject<ThingType>(res);
        }

        public static void AddThingType(ThingType type)
        {
            Request("Api/AddThing",JsonConvert.SerializeObject(type));
        }

        public static void DeleteThingType(ThingType type)
        {
            Request("Api/DeleteThing", JsonConvert.SerializeObject(type));
        }
        
        public static List<Stock> GetStocks()
        {
            string res = Request("Api/GetStocks", null);
            if (res == null) return null;
            return JsonConvert.DeserializeObject<List<Stock>>(res);
        }

        public static List<Item> GetItemsOnStock(Stock stock)
        {
            string res = Request("Api/GetItemsOnStock", JsonConvert.SerializeObject(stock));
            if (res == null) return null;
            return JsonConvert.DeserializeObject<List<Item>>(res);
        }

        public static Item CreateItem(Item type)
        {
            string res = Request("Api/CreateItem", JsonConvert.SerializeObject(type));
            if (res == null) return null;
            return JsonConvert.DeserializeObject<Item>(res);
        }

        public static Item GetItem(Item type)
        {
            string res = Request("Api/GetItem", JsonConvert.SerializeObject(type));
            if (res == null) return null;
            return JsonConvert.DeserializeObject<Item>(res);
        }

        public static List<ItemTransaction> GetItemTransactions(Item item)
        {
            string res = Request("Api/GetItemTransactions", JsonConvert.SerializeObject(item));
            if (res == null) return null;
            return JsonConvert.DeserializeObject<List<ItemTransaction>>(res);
        }

        public static void DeleteItem(Item type)
        {
            Request("Api/DeleteItem", JsonConvert.SerializeObject(type));
        }

        public static Stock GetStock(Stock type)
        {
            string res = Request("Api/GetStock", JsonConvert.SerializeObject(type));
            if (res == null) return null;
            return JsonConvert.DeserializeObject<Stock>(res);
        }

        public static List<ItemTransaction> GetTypeStockTransactions(StockType item)
        {
            string res = Request("Api/GetTypeStockTransactions", JsonConvert.SerializeObject(item));
            if (res == null) return null;
            return JsonConvert.DeserializeObject<List<ItemTransaction>>(res);
        }
    }
}
