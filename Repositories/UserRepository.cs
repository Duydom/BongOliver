using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BongOliver.API.Database.Entities;
using BongOliver.API.Database;

namespace BongOliver.API.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext _context;
 
        public UserRepository(DataContext context)
        {
            _context = context;
        }
 
        public void CreateUser(User user)
        {
            _context.Users.Add(user);
        }
 
        public void DeleteUser(User user)
        {
            _context.Users.Remove(user);
        }
 
        public User GetUserById(int id)
        {
            return _context.Users.FirstOrDefault(user => user.id == id);
        }
 
        public User GetUserByUsername(string username)
        {
            return _context.Users.FirstOrDefault(user => user.username == username);
        }
 
        public List<User> GetUsers()
        {
            return _context.Users.ToList();
        }
 
        public void UpdateUser(User user)
        {
            _context.Users.Update(user);
        }
 
        public bool IsSaveChanges()
        {
            return _context.SaveChanges() > 0;
        }
    }
}
