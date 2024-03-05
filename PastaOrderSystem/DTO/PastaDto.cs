namespace PastaOrderSystem.DTO
{
    public class PastaDto
    {
        public Guid Id { get; set; }
        public required string Name { get; set; }
        public required string Description { get; set; }
        public int Price { get; set; }
        public List<ExtraIngredientDto>? ExtraIngredients { get; set;}
    }
}
