using System;
namespace MovieAPI.DTOs
{
    public class MovieDTO
    {
        public string Title { get; set; } = string.Empty;
        public string Overview { get; set; } = string.Empty;
        public double Popularity { get; set; }
        public double Vote_Average { get; set; }
        public string Genre { get; set; } = string.Empty;
        public string Poster_Url { get; set; } = string.Empty;
        public DateTime Release_Date { get; set; }
    }
}

