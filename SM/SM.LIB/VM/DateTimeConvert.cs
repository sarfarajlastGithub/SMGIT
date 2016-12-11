using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SM.LIB.VM
{
    public class DateTimeConvert
    {
        public static DateTime GetDate(string date)
        {
            DateTime datee = Convert.ToDateTime(date);
            return datee;
        }

        public static string GetString(DateTime date)
        {
            //DateTime datee = date;
            string dates = date.ToString("dd MMMM, yyyy");
            return dates;
        }
    }
}
