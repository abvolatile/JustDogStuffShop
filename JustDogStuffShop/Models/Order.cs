using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace JustDogStuffShop.Models
{
	public class Order
    {
		[BindNever]
		public int OrderId { get; set; }
		public List<OrderDetail> OrderItems { get; set; }

		[Required(ErrorMessage = "First name is required")]
		[Display(Name = "First Name")]
		[StringLength(50)]
		public string FirstName { get; set; }

		[Required(ErrorMessage = "Last name is required")]
		[Display(Name = "Last Name")]
		[StringLength(50)]
		public string LastName { get; set; }

		[Required(ErrorMessage = "Address is required")]
		[Display(Name = "Address Line 1")]
		[StringLength(100)]
		public string AddressLine1 { get; set; }

		[Display(Name = "Address Line 2")]
		public string AddressLine2 { get; set; }

		[Required(ErrorMessage = "City is required")]
		[StringLength(50)]
		public string City { get; set; }

		[Required(ErrorMessage = "State is required")]
		[StringLength(20)]
		public string State { get; set; }

		[Required(ErrorMessage = "Zip code is required")]
		[Display(Name = "Zip Code")]
		[StringLength(10, MinimumLength = 4)]
		public string ZipCode { get; set; }

		[Required(ErrorMessage = "Country is required")]
		[StringLength(50)]
		public string Country { get; set; }

		[Display(Name = "Phone Number")]
		[StringLength(25)]
		[DataType(DataType.PhoneNumber)]
		//[RegularExpression(@"^(\d{10})$", ErrorMessage = "The phone number should be entered without spaces, dashes or parentheses")]
		//[RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "The phone number entered is not in the correct format: (###) ###-#### or (###).###.####")]
		public string PhoneNumber { get; set; }

		[Required(ErrorMessage = "Email address is required")]
		[StringLength(50)]
		[DataType(DataType.EmailAddress)]
		[RegularExpression(@"(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*|""(?:[\x01-\x08\x0b\x0c\x0e-\x1f\x21\x23-\x5b\x5d-\x7f]|\\[\x01-\x09\x0b\x0c\x0e-\x7f])*"")@(?:(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?|\[(?:(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.){3}(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?|[a-z0-9-]*[a-z0-9]:(?:[\x01-\x08\x0b\x0c\x0e-\x1f\x21-\x5a\x53-\x7f]|\\[\x01-\x09\x0b\x0c\x0e-\x7f])+)\])",
			ErrorMessage = "The email address entered is not in the correct format")]
		public string Email { get; set; }

		[BindNever]
		[ScaffoldColumn(false)]
		public decimal OrderTotal { get; set; }

		[BindNever]
		[ScaffoldColumn(false)]
		public DateTime OrderDate { get; set; }
	}
}
