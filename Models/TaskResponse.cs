using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Mission06.Models;

namespace Mission06.Models
{
	public class TaskResponse
	{
		[Key]
		[Required]
		public int TaskId { get; set; }
		[Required]
		public string Task { get; set; }
		public DateTime DueDate { get; set; }
		[Required]
		public int Quadrant { get; set; }
        public Boolean Completed { get; set; }
		//foriegn key of category
		public int CategoryId { get; set; }
		public Category Category { get; set; }
    }
}
