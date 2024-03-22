namespace MVC.Helpers
{
    public static class ApiEndpoints
    {
        public const string BaseEndpoint = "https://localhost:44360/";

        public const string PastaEndpoint = BaseEndpoint + "Pasta/";
        public const string PastaGetAllEndpoint = PastaEndpoint + "getAll/";
        
        public const string BeverageEndpoint = BaseEndpoint + "Beverage/";
        public const string BeverageGetAllEndpoint = BeverageEndpoint + "getAll/";
        
        public const string ExtraIngredientEndpoint = BaseEndpoint + "ExtraIngredient/";
        public const string ExtraIngredientGetAllEndpoint = ExtraIngredientEndpoint + "getAll/";
    }
}
