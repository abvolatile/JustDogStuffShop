using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JustDogStuffShop.Models
{
    public class ProductRepository : IProductRepository
    {
		private readonly AppDbContext _context;

		public ProductRepository(AppDbContext appDbContext)
		{
			_context = appDbContext;
		}

		public IEnumerable<Product> Products
		{
			get
			{
				//loads in all the products and related categories
				return _context.Products.Include(c => c.Category);
			}
		}

		public IEnumerable<Product> ProductsOfTheWeek
		{
			get
			{
				//loads in all the products and related categories IF IsProductOfTheWeek is set to true
				return _context.Products.Include(c => c.Category).Where(p => p.IsProductOfTheWeek);
			}
		}

		public Product GetProductById(int productId)
		{
			//loads in only the product that matches the productId passed in
			return _context.Products.FirstOrDefault(p => p.ProductId == productId);
		}
    }
}
