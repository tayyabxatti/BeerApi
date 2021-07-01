using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BeerWebApi.Models
{
    
    public class Beer
    {
        [Key]
        public int BeerId { get; set; }
        [Required(ErrorMessage = "Beer name is required")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Book Type is required")]
        public string Type { get; set; }
        [Range(1,5)]
        public double Rating { set; get; }
    }

   
}
