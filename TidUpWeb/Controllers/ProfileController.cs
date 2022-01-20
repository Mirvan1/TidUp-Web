using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TidUpWeb.Models;
namespace TidUpWeb.Controllers
{
    
    public class ProfileController : Controller
    {
        // GET: Profile
        TIDUPEntities db = new TIDUPEntities();
        public ActionResult EditProfile()
        {
            int userID = (int)Session["userID"];
            var dgr = db.TBLUSER.Find(userID);
            
            return View(dgr);
        }


        [HttpPost]
        public ActionResult UpdateProfile(TBLUSER us)
        {
            var dgr = db.TBLUSER.Find(us.ID);
            dgr.USERNAME = us.USERNAME;
            dgr.EMAIL =us.EMAIL;
            db.SaveChanges();
            return RedirectToAction("EditProfile");

        }


    }
}