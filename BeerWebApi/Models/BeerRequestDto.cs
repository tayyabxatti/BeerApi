using System;
using System.ComponentModel.DataAnnotations;

namespace BeerWebApi.Models
{
    public class BeerRequestDto
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Type { get; set; }
        [Range(1, 5)]
        public int Rating { get; set; }
    }
}
