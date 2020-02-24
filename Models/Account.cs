using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TrashCollector.Models
{
    public class Account
    {
        [Key]
        public int AccountId { get; set; }
        public string PickUpDay { get; set; }
        public DateTime OneTimePickUp { get; set; }
        public bool isSuspended { get; set; }
        public DateTime StartDay { get; set; }
        public DateTime EndDay { get; set; }
        public double Balance { get; set; }

    }
}