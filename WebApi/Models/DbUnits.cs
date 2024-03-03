using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Models
{
    public class DbUnits
    {
        [Key]
        public int Id { get; set; }

        [Column(TypeName = "varchar(255)")]
        public string? Name { get; set; }
    }
}
