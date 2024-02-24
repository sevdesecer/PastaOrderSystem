using System.ComponentModel.DataAnnotations;

namespace PastaOrderSystem.Entity
{
    public class Beverage
    {
        public Guid Id { get; set; }
        public required string Name { get; set; }
        public required string Description { get; set; }
        public int Price { get; set; }
    }
}
