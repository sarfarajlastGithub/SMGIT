using SM.LIB.EN.School;
using SM.LIB.EN.Student;
using SM.LIB.EN.Tenure;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SM.LIB.EN.DB
{
    public class AppContext : ApplicationDbContext
    {

        public DbSet<SchoolProfile> SchoolProfile { get; set; }

        public DbSet<ClassAndSection> ClassAndSection { get; set; }

        public DbSet<SAddress> SAddresses { get; set; }

        public DbSet<StudentProfile> StudentsProfiles { get; set; }

        public DbSet<StudentReg> StudentRegs { get; set; }

        public DbSet<TenureTime> TenureTimes { get; set; }

        public System.Data.Entity.DbSet<SM.LIB.VM.Student.StudentVM> StudentVMs { get; set; }

        public System.Data.Entity.DbSet<SM.LIB.EN.Student.Address> Addresses { get; set; }

        public DbSet<SMFile> Files { get; set; }
    }
}
