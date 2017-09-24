using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JustDogStuffShop.Models
{
    public class OrderRepository : IOrderRepository
    {
		private readonly AppDbContext _context;
		private readonly ShoppingCart _cart;

		public OrderRepository(AppDbContext appDbContext, ShoppingCart shoppingCart)
		{
			_context = appDbContext;
			_cart = shoppingCart;
		}

		public void CreateOrder(Order order)
		{
			//create the OrderDate and add the order to Orders table in Db
			order.OrderDate = DateTime.Now; 
			_context.Orders.Add(order);

			var cartItems = _cart.ShoppingCartItems; //get all the items from the shopping cart

			//iterate through the items in the cart and create OrderDetails for each
			foreach(var item in cartItems)
			{
				var orderDetail = new OrderDetail()
				{
					Amount = item.Amount,
					ProuctId = item.Product.ProductId,
					OrderId = order.OrderId,
					Price = item.Product.Price
				};

				//save each OrderDetail
				_context.OrderDetails.Add(orderDetail);
			}

			//save changes to the database
			_context.SaveChanges();
		}
	}
}
