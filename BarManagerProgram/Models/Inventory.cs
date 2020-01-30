using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BarManagerProgram.Models
{
    public class Inventory
    {
        [Key]
        public int InventoryId { get; set; }
        [Display(Name = "Bottles of Vodka")]
        public int VodkaBottleCount { get; set; }
        [Display(Name = "Bottles of Gin")]
        public int GinBottleCount { get; set; }
        [Display(Name = "Bottles of White Rum")]
        public int WhiteRumBottleCount { get; set; }
        [Display(Name = "Bottles of Tequila")]
        public int TequilaBottleCount { get; set; }
        [Display(Name = "Bottles of Spiced Rum")]
        public int SpicedRumBottleCount { get; set; }
        [Display(Name = "Bottles of Brandy")]
        public int BrandyBottleCount { get; set; }
        [Display(Name = "Bottles of Whiskey")]
        public int WhiskeyBottleCount { get; set; }
        [Display(Name = "Bottles of Scotch")]
        public int ScotchBottleCount { get; set; }
    }
}