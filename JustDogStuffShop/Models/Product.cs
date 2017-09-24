﻿namespace JustDogStuffShop.Models
{
	public class Product
    {
		public int ProductId { get; set; }
		public string Name { get; set; }
		public string ShortDescription { get; set; }
		public string LongDescription { get; set; }
		public string AdditionalInformation { get; set; }
		public decimal Price { get; set; }
		public string ImageUrl { get; set; }
		public string ImageThumbnailUrl { get; set; }
		public bool IsProductOfTheWeek { get; set; }
		public bool InStock { get; set; }
		public int CategoryId { get; set; }
		public virtual Category Category { get; set; }
	}
}