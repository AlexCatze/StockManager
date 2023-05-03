using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AlexCatze.StockManager.Server.Models
{
    [Table("Transactions")]
    [PrimaryKey(nameof(Id))]
    public class StockTransaction
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        public long ItemId { get; set; }

        public long StockId { get; set; }

        public int Count { get; set; }

        public DateTime Timestamp { get; set; }
    }
}
