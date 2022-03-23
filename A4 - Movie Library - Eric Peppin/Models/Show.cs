using System;
using System.IO;
using CsvHelper.Configuration;

namespace A4___Movie_Library___Eric_Peppin.Models
{
    public class Show : Media
    {
        public int Episode { get; set; }
        public int Season { get; set; }
        public string[]? Writers { get; set; }
        public override string ToString()
        {
            return $"Show - Id:{Id} Title:{Title}";
        }
    }

    public class ShowMap : ClassMap<Show>
    {
        public ShowMap()
        {
            Map(s => s.Id).Index(0).Name("showId");
            Map(s => s.Title).Index(1).Name("title");
            Map(s => s.Episode).Index(2).Name("episode");
            Map(s => s.Season).Index(3).Name("season");
            Map(s => s.Writers).Index(4).Name("writers");
        }
    }
}