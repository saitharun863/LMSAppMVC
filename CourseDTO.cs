using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DemoWebAppMVC.Models
{
	public class CourseDTO : Course
	{
		public new int CourseId { get; set; }
		public new string Title { get; set; }
		public new string Description { get; set; }
	}
}