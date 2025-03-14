using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DemoWebAppMVC.Models
{
	public class UserRepository : IUserRepository
	{
		private readonly LMSDbContext _context;
		public UserRepository() : this(new LMSDbContext()) 
		{
		}
		public UserRepository(LMSDbContext context)
		{
			_context = context;
		}
		public IEnumerable<Actor> GetAllUsers()
		{
			return _context.Users.ToList();
		}
		public Actor GetUserById(int id)
		{
			return _context.Users.Find(id);
		}
		public void AddUser(Actor user)
		{
			_context.Users.Add(user);
			_context.SaveChanges();
		}
		public string Login(string username, string password)
        {
            return _context.Users.Where<Actor>(u => u.Email == username && u.Password == password).Select(x => x.Role).FirstOrDefault();   
        }
    }
}