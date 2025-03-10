using System;
namespace MovieAPI.Models
{
    public class MovieFilter
    {
        public string? Title { get; set; }
        public string? Genre { get; set; }
        public string? Actor { get; set; }
        public string? SortBy { get; set; } 
        public int Page { get; set; } = 1;
        public int Limit { get; set; } = 10;
    }
}

