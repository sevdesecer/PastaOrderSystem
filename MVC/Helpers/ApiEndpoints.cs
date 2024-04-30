namespace MVC.Helpers
{
    public static class ApiEndpoints
    {
        private const string BaseEndpoint = "https://localhost:44360/";
        
        private const string PastaEndpoint = BaseEndpoint + "Pasta/";
        public const string PastaGetAllEndpoint = PastaEndpoint + "getAll/";

        private const string BeverageEndpoint = BaseEndpoint + "Beverage/";
        public const string BeverageGetAllEndpoint = BeverageEndpoint + "getAll/";

        private const string ExtraIngredientEndpoint = BaseEndpoint + "ExtraIngredient/";
        public const string ExtraIngredientGetAllEndpoint = ExtraIngredientEndpoint + "getAll/";

        private const string OrderEndpoint = BaseEndpoint + "Order/";
        public const string OrderAddEndpoint = OrderEndpoint + "add/";
    }
}