using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JustDogStuffShop.Models
{
    public interface IProductRepository
    {
		IEnumerable<Product> Products { get; }
		IEnumerable<Product> ProductsOfTheWeek { get; }

		Product GetProductById(int productId);
	}
}
