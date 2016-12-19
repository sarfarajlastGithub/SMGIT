using Microsoft.AspNet.Identity;
using SM.LIB.EN.DB;
using SM.LIB.EN.School;
using SM.LIB.EN.Student;
using SM.LIB.VM;
using SM.LIB.VM.Student;
using SM.WEB.Models.BL;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace SM.WEB.Controllers
{
    public class StudentController : Controller
    {
        [HttpPost]
        public ActionResult LoadStudent()
        {
            string curId = SUsers.GetCurrentUserId();
            var context = new AppContext();

            var students = context.StudentRegs.Where(s => s.SchoolProfileId == curId).Select(s =>
            new StudentSearchVM
            {
                StudentName = s.StudentName,
                StuClass = s.StuClass.ToString(),
                StuSection = s.StuSection.ToString(),
                TenureYear = s.TenureYear.ToString(),
                IsActive = s.IsActive
            }).ToList();

            return Json(new { data = students, JsonRequestBehavior.AllowGet });

            ////jQuery DataTables Param
            //var draw = Request.Form.GetValues("draw").FirstOrDefault();
            ////Find paging info
            //var start = Request.Form.GetValues("start").FirstOrDefault();
            //var length = Request.Form.GetValues("length").FirstOrDefault();
            ////Find order columns info
            //var sortColumn = Request.Form.GetValues("columns[" + Request.Form.GetValues("order[0][column]").FirstOrDefault()
            //                        + "][name]").FirstOrDefault();
            //var sortColumnDir = Request.Form.GetValues("order[0][dir]").FirstOrDefault();
            ////find search columns info
            //var contactName = Request.Form.GetValues("columns[0][search][value]").FirstOrDefault();
            //var country = Request.Form.GetValues("columns[3][search][value]").FirstOrDefault();

            //int pageSize = length != null ? Convert.ToInt32(length) : 0;
            //int skip = start != null ? Convert.ToInt16(start) : 0;
            //int recordsTotal = 0;


            //using (MyDatabaseEntities dc = new MyDatabaseEntities())
            //{
            //    // dc.Configuration.LazyLoadingEnabled = false; // if your table is relational, contain foreign key
            //    var v = (from a in dc.Customers select a);

            //    //SEARCHING...
            //    if (!string.IsNullOrEmpty(contactName))
            //    {
            //        v = v.Where(a => a.ContactName.Contains(contactName));
            //    }
            //    if (!string.IsNullOrEmpty(country))
            //    {
            //        v = v.Where(a => a.Country == country);
            //    }
            //    //SORTING...  (For sorting we need to add a reference System.Linq.Dynamic)
            //    if (!(string.IsNullOrEmpty(sortColumn) && string.IsNullOrEmpty(sortColumnDir)))
            //    {
            //        v = v.OrderBy(sortColumn + " " + sortColumnDir);
            //    }

            //    recordsTotal = v.Count();
            //    var data = v.Skip(skip).Take(pageSize).ToList();
            //    return Json(new { draw = draw, recordsFiltered = recordsTotal, recordsTotal = recordsTotal, data = data },
            //        JsonRequestBehavior.AllowGet);
            //}
        }

        public ActionResult StudentSearch()
        {
            string curId = SUsers.GetCurrentUserId();
            var context = new AppContext();

            var students = context.StudentRegs.Where(s => s.SchoolProfileId == curId).ToList();


            return View();
        }


        public ActionResult StudentProfileEdit()
        {
            StudentVM vm = new StudentVM()
            {
                SchoolId = SUsers.GetCurrentUserId()
            };
            return View(vm);
        }

        [HttpPost]
        public async System.Threading.Tasks.Task<ActionResult> StudentProfileEdit(StudentVM vm)
        {
            //string fileName = vm.PhotoLocation;
            //string extension;
            //extension = Path.GetExtension(fileName);
            string pictureName = Path.GetFileName(vm.PhotoLocation);

            //C:\\fakepath\\Pass - Fail Road Sign.jpg"
            var stId = Guid.NewGuid().ToString();
            //Getting Current
            string curId = SUsers.GetCurrentUserId();
            //Saving into SchoolProfile table
            var context = new AppContext();
            StudentProfile stp = new StudentProfile()
            {
                StudentId = stId,
                Name = vm.Name,
                Gender = vm.Gender,
                DateOfBirth = vm.DateOfBirth,
                PhotoLocation = pictureName,
                PreEduInfo = vm.PreEduInfo,
                GuardianName = vm.GuardianName,
                GuardianMobile = vm.GuardianMobile,
                GuardialEmail = vm.GuardialEmail,
                GuardianQualification = vm.GuardianQualification,
                GuardianOcupation = vm.GuardianOcupation,
                RelationWithGuardian = vm.RelationWithGuardian,

                Address = new Address
                {
                    AddL1 = vm.Address.AddL1,
                    AddL2 = vm.Address.AddL2,
                    City = vm.Address.City,
                    Pin = vm.Address.Pin,
                    state = vm.Address.state
                }
            };
            context.StudentsProfiles.Add(stp);
            await context.SaveChangesAsync();

            //Saving into Student registration table

            StudentReg stg = new StudentReg()
            {
                SchoolProfileId = curId,
                StudentProfileId = stId,
                StudentName = vm.Name,
                StuClass = vm.Stuclass,
                StuSection = vm.StuSection,
                TenureYear = vm.TenureYear,
                IsActive = vm.IsActive,
                AdmissioinDate = vm.AdmissioinDate
            };
            context.StudentRegs.Add(stg);
            await context.SaveChangesAsync();

            return View();
        }


        ///For Saving photo to server Using Ajax Jquery
        ///
        [HttpPost]
        public ActionResult SaveProfileImage()
        {
            try
            {
                if (System.Web.HttpContext.Current.Request.Files.AllKeys.Any())
                {
                    string folderPath = "~/Uploads/StudentsProfileImg/";
                    string rootPath = Server.MapPath(folderPath);

                    var pic = System.Web.HttpContext.Current.Request.Files["HelpSectionImages"];
                    HttpPostedFileBase filebase = new HttpPostedFileWrapper(pic);

                    string extension;
                    extension = Path.GetExtension(filebase.FileName);
                    var fileName = Guid.NewGuid() + extension;
                    //var fileName = Path.GetFileName(filebase.FileName);
                    var path = Path.Combine(rootPath, fileName);
                    filebase.SaveAs(path);
                    Thread.Sleep(2000);
                    folderPath = "/Uploads/StudentsProfileImg/";
                    string fileRelativePath = folderPath + fileName;


                    return new JsonResult { Data = new { filePath = fileRelativePath, onlyFileName = fileName, message = "File Saved Successfully." } };
                }
                else { return Json("No File Saved."); }
            }
            catch (Exception ex) { return Json("Error While Saving."); }
        }

        /// Using Server side Saving Picture
        ///
        //[HttpPost]
        //public ActionResult About(HttpPostedFileBase file)
        //{

        //    if (file.ContentLength > 0)
        //    {
        //        var fileName = Path.GetFileName(file.FileName);
        //        var path = Path.Combine(Server.MapPath("~/Uploads/"), fileName);
        //        file.SaveAs(path);
        //    }


        //    ViewBag.Message = "Your application description page.";

        //    return View();
        //}

    }
}