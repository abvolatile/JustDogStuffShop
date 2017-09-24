using Microsoft.AspNetCore.Mvc;
using JustDogStuffShop.Models;
using JustDogStuffShop.ViewModels;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace JustDogStuffShop.Controllers
{
	public class HomeController : Controller
    {
		private readonly IProductRepository _productRepository;

		public HomeController(IProductRepository productRepository)
		{
			_productRepository = productRepository;
		}

        public ViewResult Index()
        {
			var homeViewModel = new HomeViewModel
			{
				ProductsOfTheWeek = _productRepository.ProductsOfTheWeek
			};

            return View(homeViewModel);
        }

		public IActionResult Contact()
		{
			return View();
		}
	}
}
