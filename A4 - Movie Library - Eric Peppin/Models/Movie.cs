using System;
using System.IO;
using CsvHelper.Configuration;

namespace A4___Movie_Library___Eric_Peppin.Models
{
    public class Movie : Media
    {
        public string[]? Genres { get; set; }

        public override string ToString()
        {
            return $"Movie - Id:{Id} Title:{Title}";
        }
    }

    public class MovieMap : ClassMap<Movie>
    {
        public MovieMap()
        {
            Map(m => m.Id).Index(0).Name("movieId");
            Map(m => m.Title).Index(1).Name("title");
            Map(m => m.Genres).Index(2).Name("genres");
        }
    }
}
