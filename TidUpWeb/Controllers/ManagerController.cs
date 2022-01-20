using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TidUpWeb.Models;
namespace TidUpWeb.Controllers
{
   
    public class ManagerController : Controller
    {
        // GET: Manager
        TIDUPEntities db = new TIDUPEntities();
        public ActionResult AssignManager(string search)
        {
            var searchEmployee = from k in db.TBLUSER where k.ROLE.Equals("Employee") select k;
            if (!string.IsNullOrEmpty(search)) {
                searchEmployee = searchEmployee.Where(x => x.USERNAME.Contains(search));
            }

            //var dgr = db.TBLUSER.Where(x => x.ROLE.Equals("Employee")).ToList();
            return View(searchEmployee.ToList());
        }


        public ActionResult SetManager(int id) {
            var dgr = db.TBLUSER.Find(id);
            dgr.ROLE = "Manager";
            db.SaveChanges();
            return RedirectToAction("AssignManager");
        
        }
    }
}