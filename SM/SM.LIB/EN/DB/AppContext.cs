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
    }
}
