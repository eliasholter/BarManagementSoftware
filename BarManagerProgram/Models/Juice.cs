using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BarManagerProgram.Models
{
    public class Juice
    {
        [Key]
        public int JuiceId { get; set; }
        public string JuiceName { get; set; }
    }
}