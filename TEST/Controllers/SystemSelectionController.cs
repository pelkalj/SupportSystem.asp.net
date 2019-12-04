using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TEST.Controllers
{
    public class SystemSelectionController : Controller
    {

        public DBSupportSystem db = new DBSupportSystem();

        // GET: SystemSelection
        public ActionResult Index()
        {
            using (db)
            {
                var systemSelectionList = db.SystemSelections.ToList();
                return View(systemSelectionList);
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
        public ActionResult Create(SystemSelection selection)
        {
            using (db)
            {
                var selectionCreate = new SystemSelection()
                {

                    id = Guid.NewGuid().ToString(),
                    Name = selection.Name,
                    Description = selection.Description,
                    isDeleted = selection.isDeleted
                };

                db.SystemSelections.Add(selectionCreate);
                db.SaveChanges();

                return RedirectToAction("Index");
            }

        }

        [HttpGet]

        public ActionResult Edit(string id)
        {
            DBSupportSystem db = new DBSupportSystem();
            SystemSelection selection = db.SystemSelections.Where(s => s.id == id).SingleOrDefault();
            return View(selection);

        }

        [HttpPost]
        public ActionResult Edit(SystemSelection selection)
        {
            if (ModelState.IsValid)
            {
                using (db)
                {

                    var updateSelection = db.SystemSelections.Where(s => s.id == selection.id).SingleOrDefault();

                    updateSelection.Name = selection.Name;
                    updateSelection.Description = selection.Description;
                    updateSelection.isDeleted = selection.isDeleted;
                    db.SaveChanges();

                }
                return RedirectToAction("Index");


            }
            return View(selection);
        }

        [HttpGet]
        public ActionResult Delete(string id)
        {
            using (db)
            {
                var deleteSelection = db.SystemSelections.Where(s => s.id == id).FirstOrDefault();
                return View(deleteSelection);
            }

        }

        [HttpPost]
        public ActionResult Delete(SystemSelection selection)
        {
           

            using (db)
            {


                db.SystemSelections.Remove(db.SystemSelections.Find(selection.id));
                db.SaveChanges();


            }
            return RedirectToAction("Index");


        }

    }
}
