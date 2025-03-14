using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DemoWebAppMVC.Models
{
	public class EnrollmentRepository: IEnrollmentRepository
	{
		private readonly LMSDbContext _context;
        public EnrollmentRepository() : this(new LMSDbContext())
        {

        }
        public EnrollmentRepository(LMSDbContext context)
        {
            _context = context;
        }
        public IEnumerable<Enrollment> GetAllEnrollments()
        {
            return _context.Enrollments.ToList();
        }
        public Enrollment GetEnrollmentById(int id)
        {
            return _context.Enrollments.Find(id);
        }
        public void AddEnrollment(Enrollment enrollment)
        {
            _context.Enrollments.Add(enrollment);
            _context.SaveChanges();
        }
    }
}