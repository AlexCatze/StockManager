using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AlexCatze.StockManager.Server.Models
{
    [Table("Items")]
    [PrimaryKey(nameof(Id))]
    public class Item
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        public long TypeId { get; set; }

        public long StockId { get; set; }
    }
}
