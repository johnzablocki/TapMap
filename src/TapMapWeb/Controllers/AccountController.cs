using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TapMapWeb.Models;
using TapMapWeb.Extensions;
using TapMapWeb.Session;
using TapMapWeb.Constants;

namespace TapMapWeb.Controllers
{
	public class AccountController : ControllerBase
    {
        public UserRepository Repository { get; set; }

        public AccountController()
        {
            Repository = new UserRepository();
        }
        //
        // GET: /Account/

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult LogOn()
        {
            return View();
        }


        [HttpPost]
        public ActionResult LogOn(string username, string password)
        {

            User user = null;
            if ((user = Repository.Get(username, password)) != null)
            {
                setSessionUser(user);
            }

            return RedirectToAction("Index", "Home");
        }

        public ActionResult LogOut()
        {
            SessionUser.SetCurrent(null);
            return RedirectToAction("Index", "Home");
        }
        //
        // GET: /Account/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Account/Create

        public ActionResult Create()
        {       
            return View();
        } 

        //
        // POST: /Account/Create

        [HttpPost]
        public ActionResult Create(User user)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    //check for unique email and username
                    if (Repository.GetByEmail(user.Email) != null)
                    {
                        ModelState.AddModelError("Email", "Email address already in use");
                        return View();
                    }

                    if (Repository.GetByUsername(user.Username) != null)
                    {
                        ModelState.AddModelError("Username", "Username already in use");
                        return View();
                    }

                    if (Repository.Create(user) > 0)
                    {
                        setSessionUser(user);
                    };
                }
                
                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                TempData["Message"] = ex.Message;
                return View();
            }
        }
        
        //
        // GET: /Account/Edit/5D:\dev\TapMap\src\TapMapWeb\Controllers\AccountController.cs
        public ActionResult Edit()
        {
            var user = Repository.GetByUsername(SessionUser.Current.Username);
            return View(user);
        }

        //
        // POST: /Account/Edit/5

        [HttpPost]
        [Authorize(Roles=RoleConstants.ACTIVE_USERS, Order = 1)]   
        public ActionResult Edit(User user)
        {
            try
            {
                var currentUser = Repository.GetByUsername(user.Username);

                if (ModelState.IsValid)
                {
                    if (currentUser.Email != user.Email && Repository.GetByEmail(user.Email) != null)
                    {
                        ModelState.AddModelError("Email", "Email already in use");
                    }

                    Repository.Update(user);
                }
 
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Account/Delete/5 
        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Account/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
 
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        private void setSessionUser(User user)
        {
            SessionUser.SetCurrent(new SessionUser(
                    new string[] { RoleConstants.ACTIVE_USERS }, user.Username) 
                        { LoginDate = DateTime.Now, Email = user.Email });
        }
    }
}
