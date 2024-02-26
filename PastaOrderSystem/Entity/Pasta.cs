using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PastaOrderSystem.Entity
{
    public class Pasta
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public required string Name { get; set; }
        public required string Description { get; set; } 
        public int Price { get; set; }
    }
}
