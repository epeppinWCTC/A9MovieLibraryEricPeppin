using System;
using System.IO;
using CsvHelper.Configuration;

namespace A4___Movie_Library___Eric_Peppin.Models
{
    public class Video : Media
    {
        public string? Format { get; set;}
        public int Length { get; set; }
        public int[]? Regions { get; set; }
        
        public override string ToString()
        {
            return $"Video - Id:{Id} Title:{Title}";
        }

    }
    
    public class VideoMap : ClassMap<Video>
    {
        public VideoMap()
        {
            Map(v => v.Id).Index(0).Name("videoId");
            Map(v => v.Title).Index(1).Name("title");
            Map(v => v.Format).Index(2).Name("format");
            Map(v => v.Length).Index(3).Name("length");
            Map(v => v.Regions).Index(4).Name("regions");
        }
    }
}