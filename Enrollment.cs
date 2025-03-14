using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DemoWebAppMVC.Models
{
	public class Enrollment
	{
		[Key]
        public int EnrollmentId { get; set; }
        [Required(ErrorMessage = "Please enter user ID ")]
        public int UserId { get; set; }
        [Required(ErrorMessage = "Please enter course ID ")]
        public int CourseId { get; set; }
        [Required(ErrorMessage = "Please enter enrollment date ")]
        [DataType(DataType.Date)]
        public string EnrollmentDate { get; set; }

        public virtual Course Course { get; set; }
        public virtual Actor Actor { get; set; }
    }
}