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
        // GET: Student
        public ActionResult Index()
        {
            return View();
        }



        public ActionResult StudentSearch()
        {
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
            string fileName = vm.PhotoLocation;
            string extension;
            extension = Path.GetExtension(fileName);
            string pictureName = Path.GetFileNameWithoutExtension(fileName)+extension;

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
                StudentId = stId,
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
                    var pic = System.Web.HttpContext.Current.Request.Files["HelpSectionImages"];
                    HttpPostedFileBase filebase = new HttpPostedFileWrapper(pic);
                    var fileName = Path.GetFileName(filebase.FileName);
                    var path = Path.Combine(Server.MapPath("~/Uploads/StudentsProfileImg"), fileName);
                    filebase.SaveAs(path);
                    Thread.Sleep(2000);
                    return Json("File Saved Successfully.");
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