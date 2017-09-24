using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JustDogStuffShop.Models
{
    public interface ICategoryRepository
    {
		IEnumerable<Category> Categories { get; }
    }
}
