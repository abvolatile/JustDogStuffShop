using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using JustDogStuffShop.Models;
using Microsoft.AspNetCore.Authorization;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace JustDogStuffShop.Controllers
{
    public class OrderController : Controller
    {
		private readonly IOrderRepository _orderRepos;
		private readonly ShoppingCart _cart;

		public OrderController(IOrderRepository orderRepository, ShoppingCart shoppingCart)
		{
			_orderRepos = orderRepository;
			_cart = shoppingCart;
		}

		//GET
		[Authorize]
        public IActionResult Checkout()
        {
            return View();
        }

		//POST
		[HttpPost]
		[Authorize]
		public IActionResult Checkout(Order order)
		{
			var items = _cart.GetShoppingCartItems();
			_cart.ShoppingCartItems = items;

			if (_cart.ShoppingCartItems.Count == 0)
			{
				//check to see if cart is empty, and if so display error
				ModelState.AddModelError("", "Your cart is empty, add some items first!");
			}

			if (ModelState.IsValid)
			{
				//create the order based on the values created by model binder
				_orderRepos.CreateOrder(order);
				_cart.ClearCart(); //then clear the cart
				return RedirectToAction("CheckoutComplete"); //and send to completed page!
			}

			//if there are validation errors, return the same view with validation errors displayed
			return View(order);
		}

		public IActionResult CheckoutComplete()
		{
			ViewBag.CheckoutCompleteMessage = "Thanks for ordering with Just Dog Stuff Shop! We will send you an email when your purchases ship.";

			return View();
		}
    }
}
