using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DemoWebAppMVC.Models
{
	public class EnrollmentDTO : Enrollment
    {
        public new int EnrollmentId { get; set; }
        public new int UserId { get; set; }
        public new int CourseId { get; set; }
        public new string EnrollmentDate { get; set; }
    }
}