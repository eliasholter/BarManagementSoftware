using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BarManagerProgram.Models
{
    public class Syrup
    {
        [Key]
        public int SyrupId { get; set; }
        public string SyrupName { get; set; }
    }
}