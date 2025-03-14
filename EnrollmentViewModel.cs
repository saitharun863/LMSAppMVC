using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DemoWebAppMVC.Models
{
	public class EnrollmentViewModel : EnrollmentDTO
	{
		public new int EnrollmentId { get; set; }
        public new int UserId { get; set; }
        public new int CourseId { get; set; }
        public new string EnrollmentDate { get; set; }
               
        public List<EnrollSelectItem> course_list { get; set; }
        public List<EnrollSelectItem> user_list { get; set; }
    }
}