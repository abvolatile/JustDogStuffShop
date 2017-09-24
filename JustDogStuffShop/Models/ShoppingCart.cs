using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;

namespace JustDogStuffShop.Models
{
	public class ShoppingCart
    {
		private readonly AppDbContext _context;

		private ShoppingCart(AppDbContext appDbContext)
		{
			_context = appDbContext;
		}

		public string ShoppingCartId { get; set; }
		public List<ShoppingCartItem> ShoppingCartItems { get; set; }

		public static ShoppingCart GetCart(IServiceProvider services)
		{
			ISession session = services.GetRequiredService<IHttpContextAccessor>()?
				.HttpContext.Session; //this is how we get the Session Id

			var context = services.GetService<AppDbContext>(); //local AppDbContext instance

			//check to see if there is already a CartId on the session, if so save that to cartId, if not create a new Guid and save as the cartId
			string cartId = session.GetString("CartId") ?? Guid.NewGuid().ToString();

			//add a stored value of the cartId in the session
			session.SetString("CartId", cartId);

			//then return a new ShoppingCart with the AppDbContext and the ShoppingCartId
			return new ShoppingCart(context) { ShoppingCartId = cartId };
		}

		public void AddToCart(Product product, int amount)
		{
			//if the product exists in the cart save it in shoppingCartItem
			var shoppingCartItem = _context.ShoppingCartItems
				.SingleOrDefault(s => s.Product.ProductId == product.ProductId 
				&& s.ShoppingCartId == ShoppingCartId);

			//we're not storing Shopping Carts directly to the DB, just the ShoppingCartItems, which we create here:
			if (shoppingCartItem == null)
			{//if there aren't any of that item currently in the cart, make a new one
				shoppingCartItem = new ShoppingCartItem
				{
					ShoppingCartId = ShoppingCartId,
					Product = product,
					Amount = 1
				};

				//and add it to the database
				_context.ShoppingCartItems.Add(shoppingCartItem);
			}
			else
			{//if one or more of the same item already there, increase amount by one
				shoppingCartItem.Amount++;
			}

			_context.SaveChanges();
		}

		public int RemoveFromCart(Product product)
		{
			//if the product exists in the cart save it in shoppingCartItem
			var shoppingCartItem = _context.ShoppingCartItems.SingleOrDefault(
				s => s.Product.ProductId == product.ProductId && s.ShoppingCartId == ShoppingCartId);

			var localAmount = 0;

			if (shoppingCartItem != null)
			{ //if it exists and there's more than one in the cart, remove one
				if (shoppingCartItem.Amount > 1)
				{
					shoppingCartItem.Amount--;
					localAmount = shoppingCartItem.Amount;
				}
				else
				{ //otherwise remove the item from the cart
					_context.ShoppingCartItems.Remove(shoppingCartItem);
				}
			}

			_context.SaveChanges();

			return localAmount; //return the # of that item left in the cart
		}

		public List<ShoppingCartItem> GetShoppingCartItems()
		{
			//shortcut syntax!
			return ShoppingCartItems ??
				(ShoppingCartItems = _context.ShoppingCartItems
					.Where(c => c.ShoppingCartId == ShoppingCartId)
					.Include(s => s.Product)
					.ToList());
		}

		public void ClearCart()
		{
			var cartItems = _context.ShoppingCartItems
				.Where(cart => cart.ShoppingCartId == ShoppingCartId);

			_context.ShoppingCartItems.RemoveRange(cartItems);
			_context.SaveChanges();
		}

		public decimal GetShoppingCartTotal()
		{
			var total = _context.ShoppingCartItems
				.Where(c => c.ShoppingCartId == ShoppingCartId)
				.Select(c => c.Product.Price * c.Amount).Sum();

			return total;
		}
	}
}
