using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mission06.Models;


namespace Mission06.Models
{
	public class TasksContext: DbContext
	{
		//constructor
		public TasksContext(DbContextOptions<TasksContext> options) : base(options)
	{
		//leave balnk for now
	}

	public DbSet<TaskResponse> Responses { get; set; }
	public DbSet<Category> Categories { get; set; }

	//seeding database with categories and tasks
	protected override void OnModelCreating(ModelBuilder mb)
	{
		mb.Entity<Category>().HasData(
			 new Category { CategoryId = 1, CategoryName = "Home" },
			 new Category { CategoryId = 2, CategoryName = "School" },
			 new Category { CategoryId = 3, CategoryName = "Work" },
			 new Category { CategoryId = 4, CategoryName = "Church" }

		    );

              mb.Entity<TaskResponse>().HasData(

                new TaskResponse
                {
                    TaskId = 1,
                    Task = "Finish Mission6",
                    DueDate = new DateTime(2022-02-09),
                    Quadrant = 1,
                    Completed = true,
                    CategoryId = 2
                },
                new TaskResponse
                {
                    TaskId = 2,
                    Task = "Date Night",
                    DueDate = new DateTime(2022-02-12),
                    Quadrant = 2,
                    Completed = false,
                    CategoryId = 1
                },
                new TaskResponse
                {
                    TaskId = 3,
                    Task = "Apply for Internships",
                    DueDate =  new DateTime(2022-02-12),
                    Quadrant = 3,
                    Completed = false,
                    CategoryId = 3
                },
                new TaskResponse
                {
                    TaskId = 4,
                    Task = "Put strap on scabard",
                    Quadrant = 4,
                    Completed = false,
                    CategoryId = 4
                }
            );

	}

}
}
