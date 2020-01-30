using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BarManagerProgram.Models
{
    public class Bitter
    {
        [Key]
        public int BitterId { get; set; }
        public string BitterName { get; set; }
    }
}