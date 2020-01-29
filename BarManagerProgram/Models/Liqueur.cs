using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BarManagerProgram.Models
{
    public class Liqueur
    {
        [Key]
        public int LiqueurId { get; set; }
        public string LiqueurName { get; set; }
    }
}