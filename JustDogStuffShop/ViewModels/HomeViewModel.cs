using JustDogStuffShop.Models;
using System.Collections.Generic;

namespace JustDogStuffShop.ViewModels
{
	public class HomeViewModel
    {
		public IEnumerable<Product> ProductsOfTheWeek { get; set; }
	}
}
