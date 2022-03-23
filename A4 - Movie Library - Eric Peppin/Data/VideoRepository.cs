using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using A4___Movie_Library___Eric_Peppin.Models;
using CsvHelper;
using Microsoft.Extensions.Logging;

namespace A4___Movie_Library___Eric_Peppin.Data
{
    public class VideoRepository : IRepository
    {
        private readonly string _videoFile = $"{Environment.CurrentDirectory}/Files/videos.csv";
        // private readonly ILogger<IRepository> _logger;
        //
        // public VideoRepository(ILogger<IRepository> logger)
        // {
        //     _logger = logger;
        //
        //     if (!File.Exists(_videoFile))
        //     {
        //         _logger.LogError("File Not Found");
        //     }
        // }


        public void Add(Media video)
        {
            var shows = GetAll();

            var lastshow = shows.OrderBy(o => o.Id).Last();
            video.Id = lastshow.Id + 1;

            shows.Add(video);

            using (var writer = new StreamWriter(_videoFile))
            {
                using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
                {
                    csv.Context.RegisterClassMap<ShowMap>();
                    csv.WriteRecords(shows);
                }
            }
        }

        public Media? Search(string? searchString)
        {
            var shows = GetAll();
            var searchMedia =
                shows.FirstOrDefault(x => x.Title != null && x.Title.ToLower().Contains(searchString.ToLower()));
            return searchMedia;
        }


        public List<Media> GetAll()
        {
            List<Video> records;

            using (var reader = new StreamReader(_videoFile))
            {
                using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                {
                    csv.Context.RegisterClassMap<VideoMap>();

                    records = csv.GetRecords<Video>().ToList();
                }
            }

            return new List<Media>(records);
        }
    }
}