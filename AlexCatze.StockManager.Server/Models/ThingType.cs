using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace AlexCatze.StockManager.Server.Models
{
    [Table("ThingTypes")]
    [PrimaryKey(nameof(Id))]
    public class ThingType
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [NotNull]
        [Required(AllowEmptyStrings = false)]
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;

        public string Image { get; set; } = null!;
    }
}
