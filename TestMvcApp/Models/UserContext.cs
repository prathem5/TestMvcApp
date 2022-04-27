using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace TestMvcApp.Models
{
    public class UserContext:DbContext
    {
        public UserContext():base("DBConnection")
        {

        }
        public DbSet<User> UserTable { get; set; }
        public DbSet<UserLogin> UserLoginTable { get; set; }
        public DbSet<UserRole> UserRoleTable { get; set; }
    }
}