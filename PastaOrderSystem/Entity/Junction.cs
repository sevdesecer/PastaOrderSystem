using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Entity
{
    public class Junction
    {
        [Key]
        public Guid Id { get; set; }

        [ForeignKey("Pasta")]
        public Guid? PastaId { get; set; }

        [ForeignKey("Beverage")]
        public Guid? BeverageId { get; set; }

        [ForeignKey("Order")]
        public Guid? OrderId { get; set; }

        [ForeignKey("ExtraIngredient")]
        public Guid? ExtraIngredientId { get; set; }

        public int? PastaNumber { get; set; }

        // Navigation properties
        public Pasta? Pasta { get; set; }

        public Beverage? Beverage { get; set; }
        public Order? Order { get; set; }
        public ExtraIngredient? ExtraIngredient { get; set; }
    }
}