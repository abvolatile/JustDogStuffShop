using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JustDogStuffShop.Models
{
    public class CategoryRepository : ICategoryRepository
    {
		private readonly AppDbContext _context;

		public CategoryRepository(AppDbContext appDbContext)
		{
			_context = appDbContext;
		}

		//one-liner return shortcut!
		public IEnumerable<Category> Categories => _context.Categories;
    }
}
