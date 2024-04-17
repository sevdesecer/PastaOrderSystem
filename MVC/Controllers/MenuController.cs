using Microsoft.AspNetCore.Mvc;
using MVC.Helpers;
using MVC.Models.Beverage;
using MVC.Models.ExtraIngredient;
using MVC.Models.Menu;
using MVC.Models.Pasta;

namespace MVC.Controllers
{
    public class MenuController(IApiRequestHelper requestHelper) : Controller
    {
        public async Task<IActionResult> Index()
        {
            var pastas = await requestHelper.GetAsync<List<Pasta>>(ApiEndpoints.PastaGetAllEndpoint).ConfigureAwait(false);

            pastas.ForEach(p => p.ImagePath = @"Images\PastaImage\" + Path.GetFileName(p.ImagePath));

            var beverages = await requestHelper.GetAsync<List<Beverage>>(ApiEndpoints.BeverageGetAllEndpoint).ConfigureAwait(false);

            beverages.ForEach(p => p.ImagePath = @"Images\BeverageImage\" + Path.GetFileName(p.ImagePath));

            var extraIngredients = await requestHelper.GetAsync<List<ExtraIngredient>>(ApiEndpoints.ExtraIngredientGetAllEndpoint).ConfigureAwait(false);

            var menu = new MenuViewModel
            {
                Pastas = pastas,
                Beverages = beverages,
                ExtraIngredients = extraIngredients
            };
            return View(menu);
        }
    }
}