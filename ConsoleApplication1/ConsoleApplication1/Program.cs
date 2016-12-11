using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            string dateString = "25 JANUARY, 2006";
            DateTime date = Convert.ToDateTime(dateString);

            string newDate = date.ToString("dd MMMM, yyyy");
            var test = "Hi";
            Console.WriteLine(newDate);
        }
    }
}
