using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DemoWebAppMVC.Models
{
	public class UserViewModel : UserDTO
	{
        public new int UserId { get; set; }
        public new string Name { get; set; }
        public new string Email { get; set; }
        public new string Password { get; set; }
        public new string Type { get; set; }
    }
}