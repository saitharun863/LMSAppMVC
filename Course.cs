using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;	//works for Entity framework for handling
using System.ComponentModel.DataAnnotations;	//constraint creation

namespace DemoWebAppMVC.Models
{
	public class Course
	{
		[Key]
		public int CourseId { get; set; }

		[Required(ErrorMessage ="Please enter title")]
		[StringLength(50, ErrorMessage = "Please do not enter values over 50 characters")]
		public string Title { get; set; }

		[Required(ErrorMessage = "Please Enter Description")]
		[StringLength(200,ErrorMessage ="Pleas do not enter values over 200 characters")]
		public string Description { get; set; }
		public virtual ICollection<Enrollment> Enrollments { get; set; }
	}
}