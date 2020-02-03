using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BarManagerProgram.Models
{
    public class Inventory
    {
        [Key]
        public int InventoryId { get; set; }
        [Display(Name = "Bottles of Vodka")]
        public double VodkaBottleCount { get; set; }
        //[Display(Name = "Ounces of Vodka")]
        //public double VodkaOuncesCount { get; set; }
        [Display(Name = "Bottles of Gin")]
        public double GinBottleCount { get; set; }
        //[Display(Name = "Ounces of Gin")]
        //public double GinOuncesCount { get; set; }
        [Display(Name = "Bottles of White Rum")]
        public double WhiteRumBottleCount { get; set; }
        //[Display(Name = "Ounces of White Rum")]
        //public double WhiteRumOuncesCount { get; set; }
        [Display(Name = "Bottles of Tequila")]
        public double TequilaBottleCount { get; set; }
        //[Display(Name = "Ounces of Tequila")]
        //public double TequilaOuncesCount { get; set; }
        [Display(Name = "Bottles of Spiced Rum")]
        public double SpicedRumBottleCount { get; set; }
        //[Display(Name = "Ounces of Spiced Rum")]
        //public double SpicedRumOuncesCount { get; set; }
        [Display(Name = "Bottles of Brandy")]
        public double BrandyBottleCount { get; set; }
        //[Display(Name = "Ounces of Brandy")]
        //public double BrandyOuncesCount { get; set; }
        [Display(Name = "Bottles of Whiskey")]
        public double WhiskeyBottleCount { get; set; }
        //[Display(Name = "Ounces of Whiskey")]
        //public double WhiskeyOuncesCount { get; set; }
        [Display(Name = "Bottles of Scotch")]
        public double ScotchBottleCount { get; set; }
        //[Display(Name = "Ounces of Scotch")]
        //public double ScotchOuncesCount { get; set; }
        [ForeignKey("Bar")]
        public int BarId { get; set; }
        public Bar Bar { get; set; }
    }
}