namespace JustDogStuffShop.Models
{
	public class ShoppingCartItem
    {//for each product that gets added to the cart, we will create an instance of this class
		public int ShoppingCartItemId { get; set; }
		public Product Product { get; set; }
		public int Amount { get; set; }
		public string ShoppingCartId { get; set; }
	}
}
