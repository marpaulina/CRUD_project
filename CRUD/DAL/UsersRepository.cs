
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CRUD.Models;
using System.Data.Entity;

namespace CRUD.DAL
{
    public class UsersRepository : IUsersRepository
    {
        private AppDbContext appDbContext = new AppDbContext();
        
        public UsersRepository()
        {
            //empty
        }
        
        public void Add(User user)
        {
            appDbContext.Users.Add(user);
            appDbContext.SaveChanges();
        }
        
        public void Update(User user)
        {
            appDbContext.Entry(user).State = EntityState.Modified;
            appDbContext.SaveChanges();
        }
        
        public void Delete(User user)
        {
            appDbContext.Users.Remove(user);
            appDbContext.SaveChanges();
        }
        
        public void Delete(int id)
        {
            User userToBeDeleted = GetById(id);

            appDbContext.Users.Remove(userToBeDeleted);
            appDbContext.SaveChanges();
        }
   
        public IEnumerable<User> GetAll()
        {
            IEnumerable<User> allUsers = appDbContext.Users;

            return allUsers;
        }
        
        public User GetById(int? id)
        {
            User userToBeReturned = appDbContext.Users.FirstOrDefault(u => u.UserId == id);

            return userToBeReturned;
        }
        
        public User GetByFirstName(string firstName)
        {
            User userToBeReturned = appDbContext.Users.FirstOrDefault(u => u.FirstName.Equals(firstName));

            return userToBeReturned;
        }
        
        public User GetByLastName(string lastName)
        {
            User userToBeReturned = appDbContext.Users.FirstOrDefault(u => u.LastName.Equals(lastName));

            return userToBeReturned;
        }       
        
        public void DisposeDbConnection()
        {
            appDbContext.Dispose();
        }
    }
}