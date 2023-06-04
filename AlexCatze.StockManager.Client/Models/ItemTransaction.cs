using System;
using System.Collections.Generic;
using System.Text;

namespace AlexCatze.StockManager.Client.Models
{
    class ItemTransaction
    {
        public long Id;

        public long ItemId;

        public long StockId;

        public int Count;

        public DateTime Timestamp;
    }
}
