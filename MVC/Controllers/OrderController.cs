using Microsoft.AspNetCore.Mvc;
using MVC.Helpers;
using MVC.Models.Order;

namespace MVC.Controllers
{
    public class OrderController(IApiRequestHelper requestHelper) : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

       [HttpPost]
       public async Task<IActionResult> Create([FromBody] Order model)
        {
            await requestHelper.PostAsync(ApiEndpoints.OrderAddEndpoint, model).ConfigureAwait(false);
            return RedirectToAction("Index");
        }

    }
}