using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace TrashCollector.Models
{
    public class History
    {
        [Key]
        public int HistoryID { get; set; }
        public DateTime Pickup { get; set; }
        public bool Completed { get; set; }
    }
}
