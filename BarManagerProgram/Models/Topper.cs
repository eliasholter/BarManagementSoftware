using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BarManagerProgram.Models
{
    public class Topper
    {
        [Key]
        public int TopperId { get; set; }
        public string TopperName { get; set; }
    }
}