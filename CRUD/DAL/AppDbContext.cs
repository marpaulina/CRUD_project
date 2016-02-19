using CRUD.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CRUD.DAL
{
    public class AppDbContext : DbContext
    {
        public AppDbContext() : base("AppConnectionString")
        {
            //empty
        }

        public DbSet<User> Users { get; set; }
    }
}