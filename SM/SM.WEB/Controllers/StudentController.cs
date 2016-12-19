using SM.LIB.EN.DB;
using SM.LIB.EN.Student;
using SM.LIB.VM;
using SM.LIB.VM.Student;
using SM.WEB.Models.BL;
using System;
using System.IO;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using System.Linq.Dynamic;
using SM.LIB.VM.Account.Enums;
using System.Data.Entity;
using SM.LIB.VM.Student.Enum;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;

namespace SM.WEB.Controllers
{
    [Authorize]
    public class StudentController : Controller
    {
        /// <summary>
        /// This function for Searching paging and Listing
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult LoadStudent()
        {
            string curId = SUsers.GetCurrentUserId();
            var context = new AppContext();
            var studentdb = context.StudentRegs.Where(s => s.SchoolProfileId == curId);
            //var students = studentdb.Select(s =>
            //new StudentSearchVM
            //{
            //    StudentName = s.StudentName,
            //    StuClass = s.StuClass.ToString(),
            //    StuSection = s.StuSection.ToString(),
            //    TenureYear = s.TenureYear.ToString(),
            //    IsActive = s.IsActive
            //}).ToList();

            //return Json(new { data = students, JsonRequestBehavior.AllowGet });

            //jQuery DataTables Param
            var draw = Request.Form.GetValues("draw").FirstOrDefault();
            //Find paging info
            var start = Request.Form.GetValues("start").FirstOrDefault();
            var length = Request.Form.GetValues("length").FirstOrDefault();
            //Find order columns info
            var sortColumn = Request.Form.GetValues("columns[" + Request.Form.GetValues("order[0][column]").FirstOrDefault()
                                    + "][name]").FirstOrDefault();
            var sortColumnDir = Request.Form.GetValues("order[0][dir]").FirstOrDefault();
            //find search columns info
            var studentName = Request.Form.GetValues("columns[0][search][value]").FirstOrDefault();
            var sClass = Request.Form.GetValues("columns[1][search][value]").FirstOrDefault();
            var sSection = Request.Form.GetValues("columns[2][search][value]").FirstOrDefault();
            var tenure = Request.Form.GetValues("columns[3][search][value]").FirstOrDefault();
            var active = Request.Form.GetValues("columns[4][search][value]").FirstOrDefault();

            int pageSize = length != null ? Convert.ToInt32(length) : 0;
            int skip = start != null ? Convert.ToInt16(start) : 0;
            int recordsTotal = 0;

            // dc.Configuration.LazyLoadingEnabled = false; // if your table is relational, contain foreign key
            var v = studentdb;

            //SEARCHING...
            if (!string.IsNullOrEmpty(tenure))
            {
                TenureYear y = EnumUtil.ParseEnum<TenureYear>(tenure);
                v = v.Where(a => a.TenureYear == y);
            }
            if (!string.IsNullOrEmpty(studentName))
            {
                v = v.Where(a => a.StudentName.Contains(studentName));
            }
            if (!string.IsNullOrEmpty(sClass))
            {
                SClass c = EnumUtil.ParseEnum<SClass>(sClass);
                v = v.Where(a => a.StuClass == c);
            }
            if (!string.IsNullOrEmpty(sSection))
            {
                SSectionEnum s = EnumUtil.ParseEnum<SSectionEnum>(sSection);
                v = v.Where(a => a.StuSection == s);
            }
            if (!string.IsNullOrEmpty(active))
            {
                bool activee = Convert.ToBoolean(active);
                v = v.Where(a => a.IsActive == activee);
            }
            //SORTING...  (For sorting we need to add a reference System.Linq.Dynamic)
            if (!(string.IsNullOrEmpty(sortColumn) && string.IsNullOrEmpty(sortColumnDir)))
            {
                v = v.OrderBy(sortColumn + " " + sortColumnDir);
            }

            recordsTotal = v.Count();
            var data = v.Skip(skip).Take(pageSize).Select(s => new StudentSearchVM
            {
                StudentProfileId = s.StudentProfileId,
                StudentName = s.StudentName,
                StuClass = s.StuClass.ToString(),
                StuSection = s.StuSection.ToString(),
                TenureYear = s.TenureYear.ToString(),
                IsActive = s.IsActive
            }).ToList();
            return Json(new { draw = draw, recordsFiltered = recordsTotal, recordsTotal = recordsTotal, data = data },
                JsonRequestBehavior.AllowGet);

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
        public async System.Threading.Tasks.Task<ActionResult> StudentProfileEdit(StudentVM vm, HttpPostedFileBase upload)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var context = new AppContext();
                    var studentToUpdate = context.StudentsProfiles.Find(vm.StudentId);
                    if (studentToUpdate.Files.Any(f => f.FileType == FileType.Avatar))
                    {
                        context.Files.Remove(studentToUpdate.Files.First(f => f.FileType == FileType.Avatar));
                    }
                    if(context.StudentsProfiles.Any(s => s.StudentId == vm.StudentId))
                    {

                        StudentProfile stp1 = context.StudentsProfiles.First(s => s.StudentId == vm.StudentId);

                        stp1.Name = vm.Name;
                        stp1.Gender = vm.Gender;
                        stp1.DateOfBirth = vm.DateOfBirth;
                        stp1.PreEduInfo = vm.PreEduInfo;
                        stp1.GuardianName = vm.GuardianName;
                        stp1.GuardianMobile = vm.GuardianMobile;
                        stp1.GuardialEmail = vm.GuardialEmail;
                        stp1.GuardianQualification = vm.GuardianQualification;
                        stp1.GuardianOcupation = vm.GuardianOcupation;
                        stp1.RelationWithGuardian = vm.RelationWithGuardian;
                        stp1.Address.AddL1 = vm.Address.AddL1;
                        stp1.Address.AddL2 = vm.Address.AddL2;
                        stp1.Address.City = vm.Address.City;
                        stp1.Address.Pin = vm.Address.Pin;
                        stp1.Address.state = vm.Address.state;

                        var avatar = new SMFile
                        {
                            FileName = System.IO.Path.GetFileName(upload.FileName),
                            FileType = FileType.Avatar,
                            ContentType = upload.ContentType
                        };
                        using (var reader = new System.IO.BinaryReader(upload.InputStream))
                        {
                            avatar.Content = reader.ReadBytes(upload.ContentLength);
                        }
                        stp1.Files = new List<SMFile> { avatar };
                        context.Entry(stp1).State = EntityState.Modified;
                        context.SaveChanges();
                    }
                    if (context.StudentsProfiles.Any(s => s.StudentId == vm.StudentId))
                    {
                        StudentReg stp1 = context.StudentRegs.First(s => s.StudentProfileId == vm.StudentId);
                        stp1.StudentName = vm.Name;
                        stp1.StuClass = vm.Stuclass;
                        stp1.StuSection = vm.StuSection;
                        stp1.TenureYear = vm.TenureYear;
                        stp1.IsActive = vm.IsActive;
                        stp1.AdmissioinDate = vm.AdmissioinDate;

                        context.Entry(stp1).State = EntityState.Modified;
                        context.SaveChanges();

                    }
                        //string fileName = vm.PhotoLocation;
                        //string extension;
                        //extension = Path.GetExtension(fileName);
                        string pictureName = Path.GetFileName(vm.PhotoLocation);

                    //C:\\fakepath\\Pass - Fail Road Sign.jpg"
                    var stId = Guid.NewGuid().ToString();
                    //Getting Current
                    string curId = SUsers.GetCurrentUserId();
                    //Saving into SchoolProfile table

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

                    if (upload != null && upload.ContentLength > 0)
                    {
                        var avatar = new SMFile
                        {
                            FileName = Path.GetFileName(upload.FileName),
                            FileType = FileType.Avatar,
                            ContentType = upload.ContentType,
                            PersonId = stId
                        };
                        using (var reader = new BinaryReader(upload.InputStream))
                        {
                            avatar.Content = reader.ReadBytes(upload.ContentLength);
                        }
                        stp.Files = new List<SMFile> { avatar };
                    }

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
                }
            }
            catch (RetryLimitExceededException /* dex */)
            {
                //Log the error (uncomment dex variable name and add a line here to write a log.
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }
            return RedirectToAction("StudentSearch");
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


        [HttpGet]
        public ActionResult Details(string id)
        {

            return PartialView("_StudentProfilePartialView", getStudentDetails(id));
        }

        private StudentVM getStudentDetails(string id)
        {
            string curId = SUsers.GetCurrentUserId();
            var context = new AppContext();
            var studentRegdb = context.StudentRegs.First(s => s.SchoolProfileId == curId && s.StudentProfileId == id);
            var studentProdb = context.StudentsProfiles.Include(db => db.Address).First(s => s.StudentId == id);
            var filedb = context.Files.First(f => f.PersonId == id);
            //Loading DB to VM
            StudentVM vm = new StudentVM();

            vm.Address = studentProdb.Address;
            vm.Name = studentProdb.Name;
            vm.Gender = studentProdb.Gender;
            vm.DateOfBirth = studentProdb.DateOfBirth;
            vm.PhotoLocation = studentProdb.PhotoLocation;
            vm.PreEduInfo = studentProdb.PreEduInfo;
            vm.GuardianName = studentProdb.GuardianName;
            vm.GuardianMobile = studentProdb.GuardianMobile;
            vm.GuardialEmail = studentProdb.GuardialEmail;
            vm.GuardianOcupation = studentProdb.GuardianOcupation;
            vm.GuardianQualification = studentProdb.GuardianQualification;
            vm.RelationWithGuardian = studentProdb.RelationWithGuardian;
            vm.smfile = filedb;

            vm.StudentId = id;
            vm.Stuclass = studentRegdb.StuClass;
            vm.StuSection = studentRegdb.StuSection;
            vm.TenureYear = studentRegdb.TenureYear;
            vm.IsActive = studentRegdb.IsActive;
            vm.AdmissioinDate = studentRegdb.AdmissioinDate;
            return vm;
        }

        [HttpGet]
        public ActionResult StuEdtPop(string id)
        {


            return View("StudentProfileEdit", getStudentDetails(id));
        }

        public ActionResult StudentSearch()
        {
            string curId = SUsers.GetCurrentUserId();
            var context = new AppContext();

            var students = context.StudentRegs.Where(s => s.SchoolProfileId == curId).ToList();
            return View();
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