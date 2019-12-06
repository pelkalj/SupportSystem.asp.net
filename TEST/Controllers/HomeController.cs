using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TEST.Controllers
{
    public class HomeController : Controller
    {
        public DBSupportSystem db = new DBSupportSystem();

        public ActionResult Index()
        {
            using (db)
            {
                var systemSelectionList = db.SupportLists.ToList();
                return View(systemSelectionList);
            }
             
        }

        //public ActionResult Create()
        //{
        //    using (db)
        //    {
        //        var statuses = db.Status.ToList();
        //        var categories = db.Categories.ToList();
        //        var severities = db.Severities.ToList();
        //        var priorities = db.Priorities.ToList();
        //        var model = new Models.SupportListViewModel
        //        {
        //            status = statuses,
        //            category = categories,
        //            severity = severities,
        //            priority = priorities,
        //        };

        //        return View(model);
        //    }

        //}

        //public ActionResult Create(SupportList list)
        //{

        //    using (db)
        //    {
        //        var supportList = new SupportList()
        //        {
        //            id = Guid.NewGuid().ToString(),
        //            SugestionNo = list.SugestionNo,
        //            CreatedBy = list.CreatedBy





                    


        //        };
        //        return View();


        //    }
        //}



       
    }
}