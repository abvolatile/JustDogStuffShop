using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JustDogStuffShop.Models
{
    public class MockProductRepository /*: IProductRepository*/
    {
		private readonly ICategoryRepository _categoryRepository = new MockCategoryRepository();

		public IEnumerable<Product> Products
		{
			get
			{
				return new List<Product>
				{
					new Product {ProductId=1, Name="Spiked Collar", Price=5.95M, ShortDescription="Adjustable collar with spikes", LongDescription="Cras ac facilisis velit, non auctor neque. Morbi et tortor eleifend, ornare leo eu, tempor nunc. Phasellus eu lectus fringilla, molestie nibh accumsan, aliquam mi.", AdditionalInformation="S, M, L", ImageUrl="../../images/spikycollar.jpg", ImageThumbnailUrl="../../images/spikycollar.jpg", InStock=true, IsProductOfTheWeek=false, Category = _categoryRepository.Categories.ToList()[0]},
					new Product {ProductId=2, Name="Cozy Cocoon", Price=39.95M, ShortDescription="The cosiest dog bed ever", LongDescription="Cras ac facilisis velit, non auctor neque. Morbi et tortor eleifend, ornare leo eu, tempor nunc. Phasellus eu lectus fringilla, molestie nibh accumsan, aliquam mi.", AdditionalInformation="Beige, Blue, Red", ImageUrl="../../images/dogcocoon.jpg", ImageThumbnailUrl="../../images/dogcocoon.jpg", InStock=true, IsProductOfTheWeek=false, Category = _categoryRepository.Categories.ToList()[0]},
					new Product {ProductId=3, Name="Clifford Plush Toy", Price=24.95M, ShortDescription="Your dog's best bud", LongDescription="Cras ac facilisis velit, non auctor neque. Morbi et tortor eleifend, ornare leo eu, tempor nunc. Phasellus eu lectus fringilla, molestie nibh accumsan, aliquam mi.", AdditionalInformation="One size", ImageUrl="../../images/clifford.jpg", ImageThumbnailUrl="../../images/clifford.jpg", InStock=true, IsProductOfTheWeek=false, Category = _categoryRepository.Categories.ToList()[1]},
					new Product {ProductId=4, Name="Rope Chew Toy", Price=3.95M, ShortDescription="Fun for playing and good for your pup", LongDescription="Cras ac facilisis velit, non auctor neque. Morbi et tortor eleifend, ornare leo eu, tempor nunc. Phasellus eu lectus fringilla, molestie nibh accumsan, aliquam mi.", AdditionalInformation="Choose from 8 colors", ImageUrl="../../images/ropetoy.jpg", ImageThumbnailUrl="../../images/ropetoy.jpg", InStock=true, IsProductOfTheWeek=false, Category = _categoryRepository.Categories.ToList()[1]},
					new Product {ProductId=5, Name="Mohawk Hat", Price=14.95M, ShortDescription="The coolest hat your dog will ever wear", LongDescription="Cras ac facilisis velit, non auctor neque. Morbi et tortor eleifend, ornare leo eu, tempor nunc. Phasellus eu lectus fringilla, molestie nibh accumsan, aliquam mi.", AdditionalInformation="S, M, L", ImageUrl="../../images/mohawkdoghat.jpg", ImageThumbnailUrl="../../images/mohawkdoghat.jpg", InStock=true, IsProductOfTheWeek=false, Category = _categoryRepository.Categories.ToList()[2]},
					new Product {ProductId=6, Name="Winter/Rain Coat", Price=29.95M, ShortDescription="For those really cold or wet days", LongDescription="Cras ac facilisis velit, non auctor neque. Morbi et tortor eleifend, ornare leo eu, tempor nunc. Phasellus eu lectus fringilla, molestie nibh accumsan, aliquam mi.", AdditionalInformation="XS, S, M, L", ImageUrl="../../images/winterdogcoat.jpg", ImageThumbnailUrl="../../images/winterdogcoatTN.jpg", InStock=true, IsProductOfTheWeek=false, Category = _categoryRepository.Categories.ToList()[2]}
				};
			}
		}

		public IEnumerable<Product> ProductOfTheWeek { get; }
		public Product GetProductById(int productId)
		{
			throw new NotImplementedException();
		}
	}
}
