using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
namespace DemoWebAppMVC.Models
{
	public class CourseRepository : ICourseRepository
	{
		private readonly LMSDbContext _context;

		public CourseRepository():this(new LMSDbContext())
		{

		}
		public CourseRepository(LMSDbContext context)
		{
			_context = context;
		}
		public IEnumerable<Course> GetAllCourses()
		{
			return _context.Courses.ToList();
		}

		public Course GetCourseById(int id)
		{
			return _context.Courses.Find(id);
		}

		public void AddCourse(Course course)
		{
			_context.Courses.Add(course);
			_context.SaveChanges();
		}

        public void UpdateCourse(Course course)
        {
            _context.Entry(course).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void DeleteCourse(Course course)
        {
            _context.Courses.Remove(course);
            _context.SaveChanges();
        }
    }
}