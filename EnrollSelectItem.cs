using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DemoWebAppMVC.Models
{
	public class EnrollSelectItem : SelectListItem
	{
		public EnrollSelectItem()
        {
            Id = 0;
            Text = "Not Found";
            Value = "0";
        }
        public int Id { get; set; }
        public string Text { get; set; }
        public string Value { get; set; }
    }
}