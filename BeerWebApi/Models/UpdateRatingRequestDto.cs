using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BeerWebApi.Models
{
    public class UpdateRatingRequestDto
    {
        [Required]
        public int BeerId { get; set; }
        [Range(1, 5)]
        public int Rating { get; set; }
    }
}
