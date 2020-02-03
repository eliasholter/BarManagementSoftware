using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BarManagerProgram.Models
{
    public class Bar
    {
        [Key]
        public int BarId { get; set; }
        [ForeignKey("Manager")]
        public int ManagerId { get; set; }
        public Manager Manager { get; set; }
    }
}