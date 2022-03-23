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

    public class MovieRepository : IRepository
    {



        private readonly string _movieFile = $"{Environment.CurrentDirectory}/Files/MoviesShort.csv";
        // private readonly ILogger<IRepository> _logger;
        //
        // public MovieRepository(ILogger<IRepository> logger)
        // {
        //     _logger = logger;
        //
        //     if (!File.Exists(_movieFile))
        //     {
        //         _logger.LogError("File Not Found");
        //     }
        //
        // }

        
        public void Add(Media movie)
        {
            var movies = GetAll();

            var lastMovie = movies.OrderBy(o => o.Id).Last();
            movie.Id = lastMovie.Id + 1;

            movies.Add(movie);

            using (var writer = new StreamWriter(_movieFile))
            {
                using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
                {
                    csv.Context.RegisterClassMap<MovieMap>();
                    csv.WriteRecords(movies);
                }
            }
        }

        public Media? Search(string? searchString)
        {
            var movie = GetAll();
            var searchMedia = movie.FirstOrDefault(x => x.Title != null && x.Title.Contains(searchString));
            return searchMedia;
        }
        
        public List<Media> GetAll()
        {
            IEnumerable<Movie> records;

            using (var reader = new StreamReader(_movieFile))
            {
                using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                {
                    csv.Context.RegisterClassMap<MovieMap>();

                    records = csv.GetRecords<Movie>().ToList();
                }
            }
            return new List<Media>(records);
        }
        
        


    }
}
