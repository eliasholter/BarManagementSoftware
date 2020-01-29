using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BarManagerProgram.Models
{
    public class Liquor
    {
        [Key]
        public int LiquorId { get; set; }
        public string LiquorName { get; set; }
    }
}