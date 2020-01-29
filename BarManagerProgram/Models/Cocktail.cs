using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BarManagerProgram.Models
{
    public abstract class Cocktail
    {
        [Key]
        public int CocktailId { get; set; }
        [Display(Name = "Name Of Cocktail")]
        public string CocktailName { get; set; }
        [Display(Name = "Type Of Cocktail")]
        public string CocktailType { get; set; }

        [ForeignKey("LiquorId")]
        [Display(Name = "Type Of Liquor")]
        public string LiquorType { get; set; }
        [Display(Name = "Amount Of Liquor")]
        public double LiquorAmount { get; set; }

        [ForeignKey("JuiceId")]
        [Display(Name = "Type Of Juice")]
        public string JuiceType { get; set; }
        [Display(Name = "Amount Of Juice")]
        public double JuiceAmount { get; set; }

        [ForeignKey("SyrupId")]
        [Display(Name = "Type Of Syrup")]
        public string SyrupType { get; set; }
        [Display(Name = "Amount Of Syrup")]
        public double SyrupAmount { get; set; }

        [ForeignKey("LiqueurId")]
        [Display(Name = "Type Of First Liqueur")]
        public string Liqueur1Type { get; set; }
        [Display(Name = "Amount Of First Liqueur")]
        public double Liqueur1Amount { get; set; }

        [ForeignKey("LiqueurId")]
        [Display(Name = "Type Of Second Liqueur")]
        public string Liqueur2Type { get; set; }
        [Display(Name = "Amount Of Second Liqueur")]
        public double Liqueur2Amount { get; set; }

        [ForeignKey("LiqueurId")]
        [Display(Name = "Type Of Third Liqueur")]
        public string Liqueur3Type { get; set; }
        [Display(Name = "Amount Of Third Liqueur")]
        public double Liqueur3Amount { get; set; }

        [ForeignKey("BitterId")]
        [Display(Name = "Type Of First Bitter")]
        public string Bitter1Type { get; set; }
        [Display(Name = "Amount Of First Bitter")]
        public double Bitter1Amount { get; set; }

        [ForeignKey("BitterId")]
        [Display(Name = "Type Of Second Bitter")]
        public string Bitter2Type { get; set; }
        [Display(Name = "Amount Of Second Bitter")]
        public double Bitter2Amount { get; set; }

        [ForeignKey("TopperId")]
        [Display(Name = "Type Of Topper")]
        public string TopperType { get; set; }
        [Display(Name = "Amount Of Topper")]
        public double TopperAmount { get; set; }
    }
}