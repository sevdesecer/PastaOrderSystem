namespace MVC.Models.Menu
{
    public class MenuViewModel
    {
        public List<Pasta.Pasta>? Pastas { get; set; }
        public List<Beverage.Beverage>? Beverages { get; set; }
        public List<ExtraIngredient.ExtraIngredient>? ExtraIngredients { get; set; }
    }
}
