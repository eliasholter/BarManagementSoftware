using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BarManagerProgram.Models
{
    public class Cocktail
    {
        [Key]
        public int CocktailId { get; set; }
        [Display(Name = "Name Of Cocktail")]
        public string CocktailName { get; set; }
        [Display(Name = "Type Of Cocktail")]
        public string CocktailType { get; set; }
        [Display(Name = "Price")]
        public double Price { get; set; }
        [Display(Name = "Flavor Profile")]
        public string FlavorProfile { get; set; }
        [Display(Name = "Bubbly")]
        public bool IsBubble { get; set; } 
        [Display(Name = "Cocktail Rating")]
        public int CocktailRating { get; set; }

        [Display(Name = "Type Of Liquor")]
        public string LiquorName { get; set; }
        [Display(Name = "Amount Of Liquor")]
        public double LiquorAmount { get; set; }

        [Display(Name = "Type Of Juice")]
        public string JuiceName { get; set; }
        [Display(Name = "Amount Of Juice")]
        public double JuiceAmount { get; set; }

        [Display(Name = "Type Of Syrup")]
        public string SyrupName { get; set; }
        [Display(Name = "Amount Of Syrup")]
        public double SyrupAmount { get; set; }

        [Display(Name = "Type Of Liqueur")]
        public string LiqueurName { get; set; }
        [Display(Name = "Amount Of Liqueur")]
        public double LiqueurAmount { get; set; }

        [Display(Name = "Type Of Bitter")]
        public string BitterName { get; set; }
        [Display(Name = "Amount Of Bitter")]
        public double BitterAmount { get; set; }

        [Display(Name = "Type Of Topper")]
        public string TopperName { get; set; }
        [Display(Name = "Amount Of Topper")]
        public double TopperAmount { get; set; }

        [ForeignKey("Manager")]
        public int ManagerId { get; set; }
        public Manager Manager { get; set; }
    }
}