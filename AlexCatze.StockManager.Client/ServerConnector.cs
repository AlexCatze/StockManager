using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;
using System.Net;
using System.IO;

namespace AlexCatze.StockManager.Client
{
    class ServerConnector
    {
        public static string server_address = "http://192.168.0.126:5135/";
        private static string Request(string endpoint)
        {
            try
            {
                WebRequest request = WebRequest.Create(server_address + endpoint);
                request.Method = "POST";
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
                return null;//TODO Throw Error
            }
        }

        public static List<ThingType> GetThingTypes()
        {
            string res = Request("Api/GetThings");
            if (res == null) return null;
            return JsonConvert.DeserializeObject<List<ThingType>>(res);
            //return null;
        }
    }
}
