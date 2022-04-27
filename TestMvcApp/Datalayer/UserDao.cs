using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TestMvcApp.Models;

namespace TestMvcApp.Datalayer
{
    public class UserDao
    {
        public List<User> GetAllUsers()
        {
            try
            {
                UserContext context = new UserContext();
                return context.UserTable.ToList();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        public User GetUserById(int id)
        {
            try
            {
                UserContext context = new UserContext();
                User user = context.UserTable.Include("UserRole").FirstOrDefault(u => u.UserID == id);
                return user;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool AddUser(User user)
        {
            try
            {
                UserContext context = new UserContext();
                user.UserRole = context.UserRoleTable.FirstOrDefault(u => u.RoleID == 2);
                context.UserTable.Add(user);
                int id = context.SaveChanges();
                return id > 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool UpdateUser(User user)
        {
            try
            {
                UserContext context = new UserContext();
                User userDetail = context.UserTable.FirstOrDefault(u => u.UserID == user.UserID);
                userDetail.UserID = user.UserID;

                userDetail.FirstName = user.FirstName;
                userDetail.LastName = user.LastName;
                userDetail.PhoneNumber = user.PhoneNumber;
                userDetail.UserRole = user.UserRole;
                int id = context.SaveChanges();
                return id > 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public bool Delete(int id)
        {
            try
            {
                UserContext context = new UserContext();

                User user = context.UserTable.Include("UserRole").FirstOrDefault(u => u.UserID == id);
                context.UserTable.Remove(user);
                int deletedId = context.SaveChanges();

                return deletedId > 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}