using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace TrashCollector.Models
{
    public class Employee
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }
        public int ZipCode { get; set; }

        [ForeignKey("Application")]
        [Display(Name = "User Name")]

        public string AppUserId { get; set; }
        public IdentityUser ApplicationIdentity { get; set; }
        [NotMapped]
        public IEnumerable<ApplicationIdentity> Identities { get; set; }

    }
}
