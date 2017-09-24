using JustDogStuffShop.Models;
using JustDogStuffShop.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace JustDogStuffShop.Components
{
	public class ShoppingCartCount : ViewComponent
    {
		private readonly ShoppingCart _cart;

		public ShoppingCartCount(ShoppingCart shoppingCart)
		{
			_cart = shoppingCart;
		}

		public IViewComponentResult Invoke()
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
    }
}
