using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Web;

namespace DemoWebAppMVC.Models
{
	public class LMSDbContext : DbContext
	{
		public LMSDbContext() : base(@"Server=WIN2019;Database=LMSDB;Trusted_Connection=True;")
		{
			Database.SetInitializer(new CreateDatabaseIfNotExists<LMSDbContext>());
		}
		public DbSet<Actor> Users { get; set; }
		public DbSet<Course> Courses { get; set; }
		public DbSet<Enrollment> Enrollments { get; set; }

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);
		}
	}
}