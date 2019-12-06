using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TEST.Controllers
{
    public class StartUpHomeController : Controller
    {

        DBSupportSystem db = new DBSupportSystem();

        // GET: StartUpHome
        public ActionResult Index()
        {
            using (db)
            {

                var userList = db.AspNetUsers.OrderBy(s => s.Name).ToList();

                return View(userList);
            }
      
        }

        [HttpGet]
        public ActionResult Create()
        {
            using (db)
            {
                return View();
            }
        }

        [HttpPost]
        public ActionResult Create(AspNetUser user)
        {
           
                using (db)
                {
                    var createUser = new AspNetUser()
                    {

                        Id = Guid.NewGuid().ToString(),
                        Name = user.Name,
                        Adress = user.Adress,
                        City = user.City,
                        Country = user.Country,
                        Phone = user.Phone,
                        RoleID = user.RoleID,
                        Aktivan = user.Aktivan

                    };
                
                    db.AspNetUsers.Add(createUser);
               
                    db.SaveChanges();
                
                

                }
                 return RedirectToAction("Index");
          
        }

        [HttpGet]

        public ActionResult Edit(string id)
        {
            DBSupportSystem db = new DBSupportSystem();
            AspNetUser user = db.AspNetUsers.Where(s => s.Id == id).SingleOrDefault();
            return View(user);

        }

        [HttpPost]
        public ActionResult Edit(AspNetUser user)
        {
            if (ModelState.IsValid)
            {
                using (db)
                {

                    var userUpdate = db.AspNetUsers.Where(s => s.Id == user.Id).SingleOrDefault();

                    userUpdate.Name = user.Name;
                    userUpdate.Adress = user.Adress;
                    userUpdate.City = user.City;
                    userUpdate.Country = user.Country;
                    userUpdate.Phone = user.Phone;
                    userUpdate.RoleID = user.RoleID;
                    userUpdate.Aktivan = user.Aktivan;


                    db.SaveChanges();

                }
                return RedirectToAction("Index");


            }
            return View(user);
        }

        [HttpGet]
        public ActionResult Delete(string id)
        {
            using (db)
            {
                var deleteUser = db.AspNetUsers.Where(s => s.Id == id).FirstOrDefault();
                return View(deleteUser);
            }

        }

        [HttpPost]
        public ActionResult Delete(AspNetUser user)
        {


            using (db)
            {

                db.AspNetUsers.Remove(db.AspNetUsers.Find(user.Id));
                db.SaveChanges();


            }
            return RedirectToAction("Index");


        }
    }
}