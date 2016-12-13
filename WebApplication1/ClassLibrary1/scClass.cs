using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class scClass
    {
        [Key]
        public int ScId { get; set; }
        public string Name { get; set; }
    }
}
