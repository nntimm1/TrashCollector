using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace TrashCollector.Models
{
    public class Address
    {
        [Key]
        public int ID { get; set; }
        public string StreetAddress { get; set }
        public string State { get; set; }
        public int ZipCode { get; set; }
        public string City { get; set; }
    }
}
