using System;
using System.Collections.Generic;
using System.Text;

namespace AlexCatze.StockManager.Client.Models
{
    public class Stock
    {
        public long Id = 0;

        public string Name = "";

        public override string ToString()
        {
            return Name;
        }
    }
}
