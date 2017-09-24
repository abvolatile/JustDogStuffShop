using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JustDogStuffShop.Models
{
    public class MockCategoryRepository : ICategoryRepository
    {
		public IEnumerable<Category> Categories
		{
			get
			{
				return new List<Category>
				{
					new Category{CategoryId=1, CategoryName="Accessories", Description="Collars, Leashes, Dog Beds and other necessities"},
					new Category{CategoryId=2, CategoryName="Toys", Description="Chew Toys, Fluffy Buddies, Things to Throw"},
					new Category{CategoryId=3, CategoryName="Clothing", Description="Costumes as well as more practical attire for your pup"}
				};
			}
		}
	}
}
