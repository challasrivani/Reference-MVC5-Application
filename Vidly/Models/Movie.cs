using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Vidly.Models
{
    public class Movie
    {
        public int Id { get; set; }
        [Required]
        public String Name { get; set; }
        [Required]
        public Genre Genre { get; set; }

        [Required]
        [DisplayName("Release Date")]
        [DisplayFormat(DataFormatString ="0:dd MMM yyyy")]
        public DateTime? ReleaseDate { get; set; }
        public DateTime? DateAdded { get; set; }

        [Required]
        [DisplayName("Number in Stocks")]
        [Range(1,20)]
        public int NumberOfStocks { get; set; }
    }
}