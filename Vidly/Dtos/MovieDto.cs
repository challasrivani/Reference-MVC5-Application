using System;
using System.ComponentModel.DataAnnotations;

namespace Vidly.Dtos
{
    public class MovieDto
    {
        public int Id { get; set; }
        [Required]
        public String Name { get; set; }
        
        [Required]
        public DateTime? ReleaseDate { get; set; }
        public DateTime? DateAdded { get; set; }

        public GenreDto Genre { get; set; }

        [Required]
        [Range(1, 20)]
        public int NumberOfStocks { get; set; }
    }
}