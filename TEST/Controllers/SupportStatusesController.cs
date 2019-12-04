using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TEST.Controllers
{
    public class SupportStatusesController : Controller
    {

      public DBSupportSystem db = new DBSupportSystem();

        // GET: SupportStatuses
        public ActionResult Index()
        {
            using (db)
            {

                var statusList = db.Status.ToList();
                return View(statusList);
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
        public ActionResult Create(Status status)
        {
            using (db)
            {
                var createStatus = new Status()
                {

                    id = Guid.NewGuid().ToString(),
                    Name = status.Name,
                    Description = status.Description,
                 
                };

                db.Status.Add(createStatus);
                db.SaveChanges();

                return RedirectToAction("Index");
            }

        }

        [HttpGet]

        public ActionResult Edit(string id)
        {
            DBSupportSystem db = new DBSupportSystem();
            Status status = db.Status.Where(s => s.id == id).SingleOrDefault();
            return View(status);

        }

        [HttpPost]
        public ActionResult Edit(Status status)
        {
            if (ModelState.IsValid)
            {
                using (db)
                {

                    var updateStatus = db.Status.Where(s => s.id == status.id).SingleOrDefault();

                    updateStatus.Name = status.Name;
                    updateStatus.Description = status.Description;
                   
                    db.SaveChanges();

                }
                return RedirectToAction("Index");


            }
            return View(status);
        }

        [HttpGet]
        public ActionResult Delete(string id)
        {
            using (db)
            {
                var deleteStatus = db.Status.Where(s => s.id == id).FirstOrDefault();
                return View(deleteStatus);
            }

        }

        [HttpPost]
        public ActionResult Delete(Status status)
        {


            using (db)
            {


                db.Status.Remove(db.Status.Find(status.id));
                db.SaveChanges();


            }
            return RedirectToAction("Index");


        }
    }
}