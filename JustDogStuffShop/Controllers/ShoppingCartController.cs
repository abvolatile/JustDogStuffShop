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
    public class ShoppingCartController : Controller
    {
		private readonly IProductRepository _productRepository;
		private readonly ShoppingCart _cart;

		public ShoppingCartController(IProductRepository productRepository, ShoppingCart shoppingCart)
		{
			_productRepository = productRepository;
			_cart = shoppingCart;
		}

		public ViewResult Index()
		{
			var items = _cart.GetShoppingCartItems();
			_cart.ShoppingCartItems = items;

			var shoppingCartViewModel = new ShoppingCartViewModel
			{
				ShoppingCart = _cart,
				ShoppingCartTotal = _cart.GetShoppingCartTotal()
			};

			return View(shoppingCartViewModel);
		}

		public RedirectToActionResult AddToShoppingCart(int productId)
		{
			var selectedProduct = _productRepository.Products
				.FirstOrDefault(p => p.ProductId == productId);

			if (selectedProduct != null)
			{
				_cart.AddToCart(selectedProduct, 1);
			}

			return RedirectToAction("Index");
		}
    }
}
