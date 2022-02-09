using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Mission06.Models
{
	public class Categories
	{
		[Key]
		[Required]
		public int CategoryId { get; set; }
		public string CategoryName { get; set; }
	}
}
