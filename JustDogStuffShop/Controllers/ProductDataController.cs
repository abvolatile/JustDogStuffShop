using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using JustDogStuffShop.Models;
using JustDogStuffShop.ViewModels;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace JustDogStuffShop.Controllers
{
	[Route("api/[controller]")]
    public class ProductDataController : Controller
    {
		private readonly IProductRepository _productRepos;

		public ProductDataController(IProductRepository productRepository)
		{
			_productRepos = productRepository;
		}

		[HttpGet] //a GET request to this controller will invoke the below and return an IEnumerable of type ProductViewModel (in JSON format)
		public IEnumerable<ProductViewModel> LoadMoreProducts()
		{
			IEnumerable<Product> dbProducts = null;

			//load 19 (all) products from the database
			//**if we only load 10, it will only display the same 10 over and over...**
			dbProducts = _productRepos.Products.OrderBy(p => p.ProductId).Take(19);

			List<ProductViewModel> products = new List<ProductViewModel>();
			//create a list of ProductViewModels
			foreach (var dbProduct in dbProducts)
			{
				products.Add(MapDbProductToProductViewModel(dbProduct));
			}

			return products;
			//returning an enumerable of ProductViewModels
		}

		private ProductViewModel MapDbProductToProductViewModel(Product dbProduct)
		{
			//converting the product returned from the database into a ProductViewModel
			return new ProductViewModel()
			{
				ProductId = dbProduct.ProductId,
				Name = dbProduct.Name,
				Price = dbProduct.Price,
				ShortDescription = dbProduct.ShortDescription,
				ImageThumbnailUrl = dbProduct.ImageThumbnailUrl
			};
		}
    }
}
