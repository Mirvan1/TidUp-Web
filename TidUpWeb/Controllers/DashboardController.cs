using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TidUpWeb.Models;

namespace TidUpWeb.Controllers
{
   
    public class DashboardController : Controller
    {
        // GET: Dashboard
        TIDUPEntities db = new TIDUPEntities();
        public ActionResult Dashboard()
        {
            int compID = (int)Session["company"];
            var numOfFolder = db.TBLFOLDER.Count(y => y.COMPANYID == compID);
            ViewBag.numFolder = numOfFolder;
            var numOfItems = db.TBLPRODUCT.Count(y => y.TBLFOLDER.COMPANYID == compID);
            ViewBag.numItems = numOfItems;
            var numOfManager = db.TBLUSER.Where(x=>x.COMPANYID == compID).Count(y => y.ROLE == "Manager");
            ViewBag.numManager = numOfManager;
            var numOfEmployee = db.TBLUSER.Where(x => x.COMPANYID == compID).Count(y => y.ROLE == "Employee");
            ViewBag.numEmployee = numOfEmployee;
            var totalMoney = db.TBLPRODUCT.Where(x => x.TBLFOLDER.COMPANYID == compID).Sum(y => y.PRICE);
            ViewBag.totalMoney = totalMoney;
            var totalQuantity = db.TBLPRODUCT.Where(x => x.TBLFOLDER.COMPANYID == compID).Sum(y => y.QUANTITY);
            ViewBag.totalQuantity = totalQuantity;

            var dgr = db.TBLLOGS.Where(x => x.COMPANYID == compID && x.INFO.Equals("OnActionExecuted")).OrderByDescending(x=>x.ID).ToList();
           
       
            return View(dgr);
        }
    }
}