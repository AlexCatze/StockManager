using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace AlexCatze.StockManager.Server.Models
{
    [Table("Stocks")]
    [PrimaryKey(nameof(Id))]
    public class Stock
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [NotNull]
        [Required(AllowEmptyStrings = false)]
        public string Name { get; set; } = null!;
    }
}
