namespace PastaOrderSystem.DTO
{
    public class ExtraIngredientDto
    {
        public Guid Id { get; set; }
        public required string Name { get; set; }
        public required string Description { get; set; }
        public int Price { get; set; }
    }
}
