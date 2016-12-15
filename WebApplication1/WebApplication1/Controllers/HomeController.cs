using ClassLibrary1;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {

            ViewBag.Message = "Your application description page.";

            return View();
        }
        [HttpPost]
        // use IEnumerable<HttpPostedFileBase> files if you want to post multiple files
        public ActionResult About(HttpPostedFileBase file)
        {

            if (file.ContentLength > 0)
            {
                var fileName = Path.GetFileName(file.FileName);
                var path = Path.Combine(Server.MapPath("~/Uploads/"), fileName);
                file.SaveAs(path);
            }


            ViewBag.Message = "Your application description page.";

            return View();
        }

        [HttpPost]
        public ActionResult SaveProfileImage()
        {
            try
            {
                if (System.Web.HttpContext.Current.Request.Files.AllKeys.Any())
                {
                    var pic = System.Web.HttpContext.Current.Request.Files["HelpSectionImages"];
                    HttpPostedFileBase filebase = new HttpPostedFileWrapper(pic);
                    var fileName = Path.GetFileName(filebase.FileName);
                    var path = Path.Combine(Server.MapPath("~/Uploads/"), fileName);
                    filebase.SaveAs(path);
                    return Json("File Saved Successfully.");
                }
                else { return Json("No File Saved."); }
            }
            catch (Exception ex) { return Json("Error While Saving."); }
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public PartialViewResult SearchPeople(string keyword)
        {
            AppDbContext db = new AppDbContext();
             System.Threading.Thread.Sleep(4000);
            var data = db.ScClass.Where(f => f.FirstName.Contains(keyword)).ToList();
            return PartialView("_SearchPeople", data);
        }




        [HttpPost]
        public ActionResult UploadFiles()
        {
            // Checking no of files injected in Request object
            if (Request.Files.Count > 0)
            {
                try
                {
                    //  Get all files from Request object
                    HttpFileCollectionBase files = Request.Files;
                    for (int i = 0; i < files.Count; i++)
                    {
                        //string path = AppDomain.CurrentDomain.BaseDirectory + "Uploads/";
                        //string filename = Path.GetFileName(Request.Files[i].FileName);

                        HttpPostedFileBase file = files[i];
                        string fname;

                        // Checking for Internet Explorer
                        if (Request.Browser.Browser.ToUpper() == "IE" || Request.Browser.Browser.ToUpper() == "INTERNETEXPLORER")
                        {
                            string[] testfiles = file.FileName.Split(new char[] { '\\' });
                            fname = testfiles[testfiles.Length - 1];
                        }
                        else
                        {
                            fname = file.FileName;
                        }

                        // Get the complete folder path and store the file inside it.
                        fname = Path.Combine(Server.MapPath("~/Uploads/"), fname);
                        file.SaveAs(fname);
                    }
                    // Returns message that successfully uploaded
                    return Json("File Uploaded Successfully!");
                }
                catch (Exception ex)
                {
                    return Json("Error occurred. Error details: " + ex.Message);
                }
            }
            else
            {
                return Json("No files selected.");
            }
        }


        [HttpPost]
        public async Task<JsonResult> UploadHomeReport(string id)
        {
            try
            {
                foreach (string file in Request.Files)
                {
                    var fileContent = Request.Files[file];
                    if (fileContent != null && fileContent.ContentLength > 0)
                    {
                        // get a stream
                        var stream = fileContent.InputStream;
                        // and optionally write the file to disk
                        var fileName = Path.GetFileName(file);
                        var path = Path.Combine(Server.MapPath("~/App_Data/Images"), fileName);
                        using (var fileStream = System.IO.File.Create(path))
                        {
                            stream.CopyTo(fileStream);
                        }
                    }
                }
            }
            catch (Exception)
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return Json("Upload failed");
            }

            return Json("File uploaded successfully");
        }

    }

}