using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CRUD.DAL;
using CRUD.Models;

namespace CRUD.Controllers
{
    public class UsersController : Controller
    {
    
        private UsersRepository usersRepo = new UsersRepository();      

  
        public ActionResult Index()
        {
            var users = usersRepo.GetAll().ToList();
            
            return View(users);
            
        }
        
     
        public ActionResult Create()
        {
            return View();
        }

 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "UserId,FirstName,LastName,Email,TelephoneNumber")] User user)
        {
            if (ModelState.IsValid)
            {
                usersRepo.Add(user);
                return RedirectToAction("Index");
            }

            return View(user);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            User user = usersRepo.GetById(id);

            if (user == null)
            {
                return HttpNotFound();

            }
            return View(user);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UserId,FirstName,LastName,Email,TelephoneNumber")] User user)
        {
            if (ModelState.IsValid)
            {
                usersRepo.Update(user);
                return RedirectToAction("Index");
            }

            return View(user);
        }


        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            User user = usersRepo.GetById(id);

            if (user == null)
            {
                return HttpNotFound();
            }

            return View(user);
        }

    
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            usersRepo.Delete(id);

            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                usersRepo.DisposeDbConnection();
            }

            base.Dispose(disposing);
        }
    }
}
