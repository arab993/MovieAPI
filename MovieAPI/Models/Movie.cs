using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieAPI.Models
{
    [Table("movies")]
    public class Movie
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Overview { get; set; } = string.Empty;
        public double Popularity { get; set; }
        public int Vote_Count { get; set; }
        public double Vote_Average { get; set; }
        public string Original_Language { get; set; } = string.Empty;
        public string Genre { get; set; } = string.Empty;
        public string Poster_Url { get; set; } = string.Empty;
        public DateTime Release_Date { get; set; }

    }
}
