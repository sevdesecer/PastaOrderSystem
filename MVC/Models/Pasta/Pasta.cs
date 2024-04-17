namespace MVC.Models.Pasta
{
    public class Pasta
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public int Price { get; set; }
        public List<ExtraIngredient.ExtraIngredient>? ExtraIngredients { get; set; }
        public int Number { get; set; }
        public string ImagePath { get; set; }
    }
}