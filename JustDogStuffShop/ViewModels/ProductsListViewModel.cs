using JustDogStuffShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JustDogStuffShop.ViewModels
{
    public class ProductsListViewModel
    {
		public IEnumerable<Product> Products { get; set; }
		public string CurrentCategory { get; set; }
	}
}
