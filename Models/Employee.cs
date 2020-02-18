using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TrashCollector.Models
{
    public class Employee
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }
        public int ZipCode { get; set; }

        [ForeignKey("ApplicationUser")]
        [Display(Name = "User Name")]
        public int UserID { get; set; }


    }
}
