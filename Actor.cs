using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DemoWebAppMVC.Models
{
	public class Actor
	{
		[Key]
		public int UserId { get; set; }

		[Required(ErrorMessage ="Please enter name")]
		[StringLength(100,ErrorMessage ="Please do not enter values over 100 characters")]
		public string Name { get; set; }

		[Required(ErrorMessage ="Please enter email")]
		[EmailAddress]
		public string Email { get; set; }

		[Required(ErrorMessage ="Please Enter password")]
		[StringLength(8,ErrorMessage = "Please do not enter values over 8 characters")]
		[DataType(DataType.Password)]
		public string Password { get; set; }

        public string Role { get; set; }
        public enum Type { Admin, Instructor, Student }
		public virtual ICollection<Enrollment> Enrollments { get; set; }

	}
}