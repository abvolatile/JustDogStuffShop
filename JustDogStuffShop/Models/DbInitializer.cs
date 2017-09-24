using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JustDogStuffShop.Models
{
    public class DbInitializer
    {
		public static void Seed(IApplicationBuilder applicationBuilder)
		{
			AppDbContext context = applicationBuilder.ApplicationServices.GetRequiredService<AppDbContext>();

			if (!context.Categories.Any())
			{
				context.Categories.AddRange(Categories.Select(c => c.Value));
											//this Categories comes from further down
			}

			if (!context.Products.Any())
			{
				context.AddRange(
					new Product { Name = "Spiked Collar", Price = 7.95M, ShortDescription = "Adjustable collar with spikes", LongDescription = "There's no way your pup will get pushed around on the playground wearing this collar! Even the tiniest dog will be looking tough as nails. *spikes are plastic for safety!*", AdditionalInformation = "S, M, L", ImageUrl = "../../images/spikycollar.jpg", ImageThumbnailUrl = "../../images/spikycollar.jpg", InStock = true, IsProductOfTheWeek = true, Category = Categories["Accessories"] },
					new Product { Name = "Cozy Cocoon", Price = 39.95M, ShortDescription = "The cosiest dog bed ever", LongDescription = "Your dog won't even want to sleep in bed with you this thing is so comfy. Seriously, they should make these human-sized...", AdditionalInformation = "Beige, Blue, Red", ImageUrl = "../../images/dogcocoon.jpg", ImageThumbnailUrl = "../../images/dogcocoon.jpg", InStock = true, IsProductOfTheWeek = false, Category = Categories["Accessories"] },
					new Product { Name = "Bone Collar", Price = 5.95M, ShortDescription = "Great all around collar", LongDescription = "This collar isn't boring, it's practical. Like your neutral handbag that goes with everything.", AdditionalInformation = "", ImageUrl = "../../images/bonecollar.jpg", ImageThumbnailUrl = "../../images/bonecollar.jpg", InStock = true, IsProductOfTheWeek = false, Category = Categories["Accessories"] },
					new Product { Name = "Standard Dog Bed", Price = 34.95M, ShortDescription = "A very cozy bed", LongDescription = "Standard as in 'GOLD Standard'. Hope your dog is ready to share this with the cat, kids, and visiting friends. Maybe you should get two!", AdditionalInformation = "", ImageUrl = "../../images/dogbed.jpg", ImageThumbnailUrl = "../../images/dogbed.jpg", InStock = true, IsProductOfTheWeek = false, Category = Categories["Accessories"] },
					new Product { Name = "Food/Water Dish", Price = 4.95M, ShortDescription = "Sturdy dog dish for water or food", LongDescription = "This may look like a typical dog dish, and it is! It's also pretty rad, and it can survive no matter where your dog drags it around on the floor.", AdditionalInformation = "", ImageUrl = "../../images/dogbowl.jpg", ImageThumbnailUrl = "../../images/dogbowl.jpg", InStock = true, IsProductOfTheWeek = false, Category = Categories["Accessories"] },
					new Product { Name = "Glitter Leash", Price = 19.95M, ShortDescription = "Sparkly retractible leash", LongDescription = "Just because you've got a huge intimidating dog doesn't mean they can't feel like a big princess. As sturdy as it is sparkly, this thing could rein in a stampeding horse!", AdditionalInformation = "", ImageUrl = "../../images/glitterleash.jpg", ImageThumbnailUrl = "../../images/glitterleash.jpg", InStock = true, IsProductOfTheWeek = false, Category = Categories["Accessories"] },
					new Product { Name = "Rope Leash", Price = 8.95M, ShortDescription = "A very dependable, strong leash", LongDescription = "Seriously, this is a pretty boring leash. It's made out of climbing rope, no frills. What else do you need to know?", AdditionalInformation = "6 foot, 8 foot", ImageUrl = "../../images/ropeleash.jpg", ImageThumbnailUrl = "../../images/ropeleashTN.jpg", InStock = true, IsProductOfTheWeek = false, Category = Categories["Accessories"] },
					new Product { Name = "Clifford Plush Toy", Price = 24.95M, ShortDescription = "Your dog's best bud", LongDescription = "Is your dog lonely all day while you're at work? Well, not anymore!!", AdditionalInformation = "One size", ImageUrl = "../../images/clifford.jpg", ImageThumbnailUrl = "../../images/clifford.jpg", InStock = true, IsProductOfTheWeek = true, Category = Categories["Toys"] },
					new Product { Name = "Rope Chew Toy", Price = 3.95M, ShortDescription = "Fun for playing and good for your pup", LongDescription = "Want to play tug-of-war ALLLL the time?? Comes in 8 different colors, so you can get one for each of your pups!", AdditionalInformation = "Choose from 8 colors", ImageUrl = "../../images/ropetoy.jpg", ImageThumbnailUrl = "../../images/ropetoy.jpg", InStock = true, IsProductOfTheWeek = false, Category = Categories["Toys"] },
					new Product { Name = "Rubber Chew Toy", Price = 4.95M, ShortDescription = "Give 'em something to chew on", LongDescription = "Great for dogs who really want to chew on your leather shoes or the couch. Plus, it makes that really annoying squeaky sound of teeth rubbing against rubber. Your dog will love it!", AdditionalInformation = "choose from 3 colors", ImageUrl = "../../images/chewy.jpg", ImageThumbnailUrl = "../../images/chewy.jpg", InStock = true, IsProductOfTheWeek = false, Category = Categories["Toys"] },
					new Product { Name = "Donut Plush Toy", Price = 3.95M, ShortDescription = "All the fun without the calories", LongDescription = "Try not to mistake this for a real donut, because it probably won't taste that good to you. Fortunately, your dog probably doesn't know what donuts taste like, so they'll think they're getting a real treat!", AdditionalInformation = "Pink, Chocolate", ImageUrl = "../../images/donuts.jpg", ImageThumbnailUrl = "../../images/donuts.jpg", InStock = true, IsProductOfTheWeek = false, Category = Categories["Toys"] },
					new Product { Name = "Ball & Thrower", Price = 6.95M, ShortDescription = "Play fetch for hours without the drool slime", LongDescription = "Tired of throwing out your shoulder or getting slimed by an insane amount of dog drool when you lay fetch with your dog? Then this would be for you.", AdditionalInformation = "", ImageUrl = "../../images/throwstick.jpg", ImageThumbnailUrl = "../../images/throwstickTN.jpg", InStock = true, IsProductOfTheWeek = false, Category = Categories["Toys"] },
					new Product { Name = "Mohawk Hat", Price = 14.95M, ShortDescription = "The coolest hat your dog will ever wear", LongDescription = "Not all of us can be as cool as this hat will make your dog look. If you get a large one, you might be able to make it fit, but maybe just leave it on the dog...", AdditionalInformation = "S, M, L", ImageUrl = "../../images/mohawkdoghat.jpg", ImageThumbnailUrl = "../../images/mohawkdoghat.jpg", InStock = true, IsProductOfTheWeek = true, Category = Categories["Clothing"] },
					new Product { Name = "Winter/Rain Coat", Price = 29.95M, ShortDescription = "For those really cold or wet days", LongDescription = "Just because your dog has fur doesn't mean they wouldn't like a little shelter from the elements at times. Plus, having this means they can stay out longer, right??", AdditionalInformation = "XS, S, M, L", ImageUrl = "../../images/winterdogcoat.jpg", ImageThumbnailUrl = "../../images/winterdogcoatTN.jpg", InStock = true, IsProductOfTheWeek = false, Category = Categories["Clothing"] },
					new Product { Name = "Brimmed Cap", Price = 9.95M, ShortDescription = "Keep the sun or rain out of their eyes", LongDescription = "Oh, dogs don't need shade from the sun or something to keep the rain out of their eyes? What are you, a monster? Have a little compassion, man!", AdditionalInformation = "4 colors", ImageUrl = "../../images/dogbrimhat.jpg", ImageThumbnailUrl = "../../images/dogbrimhat.jpg", InStock = true, IsProductOfTheWeek = false, Category = Categories["Clothing"] },
					new Product { Name = "Viking Helmet", Price = 14.95M, ShortDescription = "Keep your pup warm in style", LongDescription = "This could be a costume, but it could also just be a really cool hat to wear whenever your dog wants to feel super cool. You decide.", AdditionalInformation = "S, L", ImageUrl = "../../images/doghelmethat.jpg", ImageThumbnailUrl = "../../images/doghelmethat.jpg", InStock = true, IsProductOfTheWeek = false, Category = Categories["Clothing"] },
					new Product { Name = "Plaid Hoodie", Price = 24.95M, ShortDescription = "For all your hipster needs", LongDescription = "Is your dog like, super old-school and was totally playing with that new toy WAYYY before all the other dogs? Then you'll need this.", AdditionalInformation = "", ImageUrl = "../../images/doghoodie.jpg", ImageThumbnailUrl = "../../images/doghoodie.jpg", InStock = true, IsProductOfTheWeek = false, Category = Categories["Clothing"] },
					new Product { Name = "Marilyn Costume", Price = 19.95M, ShortDescription = "When your dog wants to feel pretty", LongDescription = "Costumes are so much fun! No, not just for you - your dog loves getting all dressed up! Don't listen to the nay-sayers.", AdditionalInformation = "", ImageUrl = "../../images/dogmarilyn.jpg", ImageThumbnailUrl = "../../images/dogmarilyn.jpg", InStock = true, IsProductOfTheWeek = false, Category = Categories["Clothing"] },
					new Product { Name = "Knit Beanie", Price = 9.95M, ShortDescription = "Perfect for winter walks", LongDescription = "Don't let your pup get chilly on those long walks in the late fall and winter. Keep their little heads warm AND styling in this awesome knit hat!", AdditionalInformation = "", ImageUrl = "../../images/knitdoghat.jpg", ImageThumbnailUrl = "../../images/knitdoghatTN.jpg", InStock = true, IsProductOfTheWeek = false, Category = Categories["Clothing"] }
				);
			}

			context.SaveChanges();
		}

		private static Dictionary<string, Category> categories;
		public static Dictionary<string, Category> Categories
		{
			get
			{
				if (categories == null)
				{
					var genresList = new Category[]
					{
						new Category{CategoryName="Accessories"},
						new Category{CategoryName="Toys"},
						new Category{CategoryName="Clothing"}
					};

					categories = new Dictionary<string, Category>();

					foreach (Category genre in genresList)
					{
						categories.Add(genre.CategoryName, genre);
					}
				}
				return categories;
			}
		}
	}
}
