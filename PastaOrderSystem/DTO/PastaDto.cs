namespace PastaOrderSystem.DTO
{
    public class PastaDto
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public int? Price { get; set; }
        public List<ExtraIngredientDto>? ExtraIngredients { get; set;}
    }
}
