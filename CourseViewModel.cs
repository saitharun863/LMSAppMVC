using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DemoWebAppMVC.Models
{
	public class CourseViewModel : CourseDTO
	{
		public new int CourseId { get; set; }
		public new string Title { get; set; }
		public new string Description { get; set; }
		public bool IsEnrolled { get; set; } = false;
	}
}