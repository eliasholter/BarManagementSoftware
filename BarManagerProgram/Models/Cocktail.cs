using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

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
        [Display(Name = "Flavor Profile")]
        public string FlavorProfile { get; set; }
        [Display(Name = "Bubbly")]
        public bool IsBubble { get; set; } 
        [Display(Name = "Cocktail Rating")]
        public int CocktailRating { get; set; }

        [ForeignKey("Liquor")]
        [Display(Name = "Type Of Liquor")]
        public int? LiquorId { get; set; }
        public Liquor Liquor { get; set; }
        [Display(Name = "Amount Of Liquor")]
        public double LiquorAmount { get; set; }

        [ForeignKey("Juice")]
        [Display(Name = "Type Of Juice")]
        public int? JuiceId { get; set; }
        public Juice Juice { get; set; }
        [Display(Name = "Amount Of Juice")]
        public double JuiceAmount { get; set; }

        [ForeignKey("Syrup")]
        [Display(Name = "Type Of Syrup")]
        public int SyrupId { get; set; }
        public Syrup Syrup { get; set; }
        [Display(Name = "Amount Of Syrup")]
        public double SyrupAmount { get; set; }

        [ForeignKey("Liqueur")]
        [Display(Name = "Type Of Liqueur")]
        public int LiqueurId { get; set; }
        public Liqueur Liqueur { get; set; }
        [Display(Name = "Amount Of Liqueur")]
        public double LiqueurAmount { get; set; }

        [ForeignKey("Bitter")]
        [Display(Name = "Type Of Bitter")]
        public int BitterId { get; set; }
        public Bitter Bitter { get; set; }
        [Display(Name = "Amount Of Bitter")]
        public double BitterAmount { get; set; }

        [ForeignKey("Topper")]
        [Display(Name = "Type Of Topper")]
        public int TopperId { get; set; }
        public Topper Topper { get; set; }
        [Display(Name = "Amount Of Topper")]
        public double TopperAmount { get; set; }

        [NotMapped]
        public List<Liquor> Liquors { get; set; }
        [NotMapped]
        public List<Juice> Juices { get; set; }
        [NotMapped]
        public List<Liquor> Syrups { get; set; }
        [NotMapped]
        public List<Liqueur> Liqueurs { get; set; }
        [NotMapped]
        public List<Bitter> Bitters { get; set; }
        [NotMapped]
        public List<Topper> Toppers { get; set; }
    }
}