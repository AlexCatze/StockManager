using System;
using System.Collections.Generic;
using System.Text;

namespace AlexCatze.StockManager.Client
{
    class ServerConnector
    {
        public static string server_address = "http://192.168.0.126:5135/";
        private static string Request(string endpoint)
        {
            try
            {
                WebRequest request = WebRequest.Create(Program.server_address + endpoint);
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
                return null;
            }
        }

        public static List<ThingType> GetThingTypes()
        {

        }
    }
}
