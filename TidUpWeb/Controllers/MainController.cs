using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TidUpWeb.Models;
using TidUpWeb.Logs;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.tool.xml;
using System.Web.UI;
using System.Web.Security;

namespace TidUpWeb.Controllers
{

   
    public class MainController : Controller
    {
        // GET: Main

        TIDUPEntities db = new TIDUPEntities();

        [HttpGet]
        public ActionResult MainPage(string search)
        {//System.Web.HttpContext.Current.
            int compID = (int)Session["company"];
            var searchFolder = from x in db.TBLFOLDER where x.COMPANYID == compID && x.STATUS==true select x;
            if (!string.IsNullOrEmpty(search)) {
                searchFolder = searchFolder.Where(x => x.FOLDERNAME.Contains(search));
            }

           // var dgr = db.TBLFOLDER.Where(x => x.COMPANYID== compID).ToList();
            var numOfFolder=db.TBLFOLDER.Count(y=>y.COMPANYID == compID);
            ViewBag.numFolder = numOfFolder;
            var numOfItems = db.TBLPRODUCT.Count(y => y.TBLFOLDER.COMPANYID == compID);
            ViewBag.numItems = numOfItems;
            return View(searchFolder.ToList());
        }



        public ActionResult ItemList(int id,string itemSearch) {
            var searchItem = from k in db.TBLPRODUCT where k.FOLDERID == id && k.STATUS==true select k;
            if (!string.IsNullOrEmpty(itemSearch))
            {
                searchItem = searchItem.Where(x => x.NAME.Contains(itemSearch));
            }

            //var folderID = db.TBLPRODUCT.FirstOrDefault(x => x.FOLDERID == id);
            var dgr = db.TBLPRODUCT.Count(x => x.FOLDERID == id);
             
                var numOfItemsInFolder = db.TBLPRODUCT.Count(y => y.FOLDERID == id);
                ViewBag.numOfItemsFolder = numOfItemsInFolder;

                var folderName = db.TBLFOLDER.FirstOrDefault(x => x.FOLDERID == id);
                ViewBag.folderNameB = folderName.FOLDERNAME;

            TempData["folder_id"] = id;
            return View(searchItem.ToList()); 
        }



        public ActionResult ItemDetail(int id) {
            var dgr = db.TBLPRODUCT.FirstOrDefault(x => x.PRODUCTID == id);

            return View(dgr);
        }

        [LogItemsFilter]
        public ActionResult DeleteItem(int id) {
            var dgr = db.TBLPRODUCT.Find(id);
            dgr.STATUS = false;
            db.SaveChanges();
            return RedirectToAction("MainPage", "Main");
        
        }


        [HttpGet]
        public PartialViewResult GetItemInfo(int id) {
            var dgr = db.TBLPRODUCT.Find(id);


            return PartialView(dgr);
        }


        [HttpPost]
        [LogItemsFilter]
        public ActionResult GetItemInfo(TBLPRODUCT pro) {
            var dgr = db.TBLPRODUCT.Find(pro.PRODUCTID);
            dgr.NAME = pro.NAME;
            dgr.PRICE = pro.PRICE;
            dgr.DATE = pro.DATE;
            dgr.QUANTITY = pro.QUANTITY;
            dgr.BARCODE = pro.BARCODE;
            dgr.NOTE = pro.NOTE;
            db.SaveChanges();

            return RedirectToAction("MainPage", "Main");
        }

        [HttpGet]
       
        public PartialViewResult InviteCompany (){

            return PartialView();
        }

        [HttpPost]
        [Authorize(Roles = "Manager")]
        public ActionResult InviteCompany(TBLUSER us) {
            var dgr = db.TBLUSER.FirstOrDefault(x=>x.EMAIL==us.EMAIL);
            
             if(dgr==null)
            {       ViewBag.findInvitedPeople = "The user cannot find";
                return RedirectToAction("MainPage", "Main");
         
            }
            else if (!string.IsNullOrEmpty(dgr.EMAIL) && dgr.COMPANYID==null)
            {
                dgr.COMPANYID = (int)Session["company"];
                db.SaveChanges();
            }
            else if (dgr.COMPANYID!=null) {

                ViewBag.userJoinAlready = "The user already join company";
                    
                    }
            

            return RedirectToAction("MainPage","Main");
        }

        [HttpGet]
        public PartialViewResult UpdateFolder(int id) {
            var dgr = db.TBLFOLDER.Find(id);
            return PartialView(dgr);

        }


        [HttpPost]
        [LogFilters]
        public ActionResult UpdateFolder(TBLFOLDER fol) {
            var dgr = db.TBLFOLDER.Find(fol.FOLDERID);
            dgr.FOLDERNAME = fol.FOLDERNAME;
            db.SaveChanges();
            return RedirectToAction("ItemList"+fol.FOLDERID.ToString(),"Main");
        }

        [LogFilters]
        public ActionResult DeleteFolder(int id) {
            var dgr = db.TBLFOLDER.Find(id);
            dgr.STATUS = false;
            db.SaveChanges();

            return RedirectToAction("MainPage","Main");

        }


        public PartialViewResult ProfileHeader() {

            return PartialView();

        }

        [HttpGet]
        public ActionResult ExportData() {
            int compID = (int)Session["company"];
            var dgr = db.TBLPRODUCT.Where(x => x.TBLFOLDER.COMPANYID == compID).ToList();
            

            return View(dgr);
        }

        [HttpGet]
        public PartialViewResult AddFolder() {

            return PartialView();
        }


        [HttpPost]
        public ActionResult AddFolder(TBLFOLDER fld) {

            int compID = (int)Session["company"];
            fld.COMPANYID = compID;
            fld.STATUS = true;
            db.TBLFOLDER.Add(fld);
            db.SaveChanges();
            return RedirectToAction("MainPage", "Main");
        }


        [HttpGet]
        public PartialViewResult AddItem() {
           
            return PartialView();
        }

        [HttpPost]
        public ActionResult AddItem(TBLPRODUCT pro) {

            pro.STATUS = true;
            if (Request.Files.Count > 1) {
                string fileName = Path.GetFileName(Request.Files[0].FileName);
                string extFile = Path.GetExtension(Request.Files[0].FileName);
                string pathOfFile = "~/Images/" + fileName + extFile;
                Request.Files[0].SaveAs(Server.MapPath(pathOfFile));
                pro.PHOTO = "/Images/"+fileName+extFile;
            }
            db.TBLPRODUCT.Add(pro);
            db.SaveChanges();
            return RedirectToAction("ItemList/"+pro.FOLDERID.ToString(), "Main");
        }


     





        [HttpGet]
        public void ExportDataButton()
        {
            // List<Employee> emps = TempData["Data"] as List<Employee>;

            int compID = (int)Session["company"];
            //var name = db.TBLPRODUCT.Where(x => x.TBLFOLDER.COMPANYID == compID).Select(y=>y.NAME).ToList();
            //var price= db.TBLPRODUCT.Where(x => x.TBLFOLDER.COMPANYID == compID).Select(y => y.PRICE);
            //var quantity= db.TBLPRODUCT.Where(x => x.TBLFOLDER.COMPANYID == compID).Select(y => y.QUANTITY);
            //var date= db.TBLPRODUCT.Where(x => x.TBLFOLDER.COMPANYID == compID).Select(y => y.DATE);
            //var barcode= db.TBLPRODUCT.Where(x => x.TBLFOLDER.COMPANYID == compID).Select(y => y.BARCODE);
            //var folder= db.TBLPRODUCT.Where(x => x.TBLFOLDER.COMPANYID == compID).Select(y => y.TBLFOLDER.FOLDERNAME);
            var list =(from k in db.TBLPRODUCT
                       where k.TBLFOLDER.COMPANYID == compID
                       select new {k.NAME,k.PRICE,k.BARCODE,k.TBLFOLDER.FOLDERNAME,k.QUANTITY,k.DATE }).ToList();

            var grid = new System.Web.UI.WebControls.GridView();
            grid.DataSource = list;
            grid.DataBind();
            Response.ClearContent();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", "attachment; filename="+ Session["comp"]+"-" + Session["username"]+"-"+DateTime.Now+".csv");
            Response.ContentType = "application/ms-excel";
            Response.Charset = "";
            StringWriter sw = new StringWriter();
            HtmlTextWriter htw = new HtmlTextWriter(sw);
            grid.RenderControl(htw);
            Response.Output.Write(sw.ToString());
            Response.Flush();
            Response.End();
            TempData["Data"] = list;
        }

    


        }
}