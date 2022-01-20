using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using TidUpWeb.Models;

namespace TidUpWeb.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        // GET: Login

        TIDUPEntities db = new TIDUPEntities();
        
        public ActionResult Index()
        {
            ViewBag.comp = Session["comp"];
            return View();
        }


        [HttpGet]
        public PartialViewResult SignUpM() { 
        
        
        return PartialView();
        }

        [HttpPost]
        public ActionResult SignUpM(TBLUSER mm,TBLCOMPANY cc) {
            //mm = new MultipModel();
            //db.TBLUSER.Add((TBLUSER)mm.m_user);
            //db.TBLCOMPANY.Add((TBLCOMPANY)mm.m_company);
            //db.SaveChanges();
           var companyCode = db.TBLCOMPANY.FirstOrDefault(x => x.COMPANYCODE == cc.COMPANYCODE);
            if (!string.IsNullOrEmpty(cc.COMPANYNAME))
            {
                cc.COMPANYCODE = gnrCompanyCode(10);
                db.TBLCOMPANY.Add(cc);
                mm.COMPANYID = cc.COMPANYID;
                mm.ROLE = "Manager";
                db.TBLUSER.Add(mm);
                db.SaveChanges();
                //return RedirectToAction("Index"); 
            }
            else if (companyCode == null) {
                mm.ROLE = "Employee";
                mm.COMPANYID = null;
                db.TBLUSER.Add(mm);
                db.SaveChanges();
            }
            else
            {

                if (companyCode != null)
                {

                    mm.COMPANYID = companyCode.COMPANYID;
                    mm.ROLE = "Employee";
                    db.TBLUSER.Add(mm);
                    db.SaveChanges();
                    //return RedirectToAction("YOxdu");
                }
                else
                {
                    ViewBag.ccWrong = "Company code is not true";
                }
            }

         
            return RedirectToAction("Index");

        }

        [HttpGet]
        public PartialViewResult LoginM() {

            return PartialView();
        }


        [HttpPost]
        public ActionResult LoginM(TBLUSER us) {
            var userinfo = db.TBLUSER.FirstOrDefault(x => x.EMAIL == us.EMAIL && x.PASSWORD == us.PASSWORD);
            if (userinfo != null)
            {
                FormsAuthentication.SetAuthCookie(userinfo.EMAIL, false);
                Session["usermail"] = userinfo.EMAIL;
                Session["company"] = userinfo.COMPANYID;
                Session["userID"] = userinfo.ID;
                Session["username"] = userinfo.USERNAME;
                Session["userrole"] = userinfo.ROLE;
                var company = db.TBLCOMPANY.FirstOrDefault(x => x.COMPANYID == userinfo.COMPANYID);
                Session["comp"] = company.COMPANYNAME;
                return RedirectToAction("MainPage","Main");//deyis

            }
            else
            {
                return RedirectToAction("MainPage","Main");
            }

        }
        



        public string gnrCompanyCode(int tokenLength)
        {
            var rngCryptoServiceProvider = new RNGCryptoServiceProvider();
            var randomBytes = new byte[tokenLength];
            rngCryptoServiceProvider.GetBytes(randomBytes);
            return BitConverter.ToString(randomBytes);
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            HttpContext.Request.Cookies.Clear();
            return RedirectToAction("Index", "Login");
        }


    }
}