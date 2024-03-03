using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Models
{
    public class DbItemsUnits
    {
        [Key]
        public int Id { get; set; }
        
        public int IdItem { get; set; }
        public DbItems? DbItems { get; set; }

        public int IdUnit { get; set; }
        public DbUnits? DbUnits { get; set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal Price { get; set; }
    }
}
