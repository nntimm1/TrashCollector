using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace TrashCollector.Models
{
    public class Customer
    {
        [Key]
        public int ID { get; set; }
        [Display(Name = "First Name")] 
        public string FirstName { get; set; }
        [Display(Name = "Last Name")] 
        public string LastName { get; set; }


        [ForeignKey("AddressID")]
        [Display(Name = "Address")]
        public int AddressID { get; set; }
        public Address Address { get; set; }
        [NotMapped]
        public IEnumerable<Address> Addresses { get; set; }

        [ForeignKey("AccountID")]
        [Display(Name = "Account")]

        public int AccountID { get; set; }
        public Account Account { get; set; }
        [NotMapped]
        public IEnumerable<Account> Accounts { get; set; }


        [ForeignKey("IdentityUser")]
        public string IdentityUserId { get; set; }
        public IdentityUser IdentityUser { get; set; }
    }
}

