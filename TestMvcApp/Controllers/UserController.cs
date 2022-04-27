using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestMvcApp.Datalayer;
using TestMvcApp.Models;
using TestMvcApp.AuthenticationFilter;

namespace TestMvcApp.Controllers
{
    [Authenticate]
    public class UserController : Controller
    {
        UserDao userDao = new UserDao();
        // GET: User
        public ActionResult Index()
        {
            List<User> userList = userDao.GetAllUsers();
            return View(userList);
        }
        
        public ActionResult Create()
        {
            User userModel = new User();
            return PartialView("Create",userModel);
        }
        [HttpPost]
        public ActionResult Create(User user)
        {
            if (ModelState.IsValid)
            {
                bool userAdded = userDao.AddUser(user);
                if (userAdded)
                {
                    ViewBag.IsSucess = "Added succesfully";
                    return RedirectToAction("Index", "User");
                }
            }
            return RedirectToAction("Index");
        }
        public ActionResult Edit(int userId)
        {
            UserContext context = new UserContext();
            User userModel = userDao.GetUserById(userId);
            return PartialView("Edit", userModel);
        }
        [HttpPost]
        public ActionResult Edit(User user)
        {
            if (ModelState.IsValid)
            {
                bool userUpdated = userDao.UpdateUser(user);
                if (userUpdated)
                {
                    return RedirectToAction("Index", "User");
                }
            }
            return View("Index");
        }
        public ActionResult Delete(int id)
        {
            bool userDeleted = userDao.Delete(id);
            return RedirectToAction("Index","User");
        }
    }
}