using CRUD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD.DAL
{
 
    interface IUsersRepository
    {
        
        IEnumerable<User> GetAll();

        User GetById(int? id);
        
        User GetByFirstName(string firstName);
        
        User GetByLastName(string lastName);
        
        void Add(User user);
        
        void Update(User user);
        
        void Delete(User user);
        
        void Delete(int id);
        
        void DisposeDbConnection();
    }
}
