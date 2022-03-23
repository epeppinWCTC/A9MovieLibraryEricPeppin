using System.Collections.Generic;
using A4___Movie_Library___Eric_Peppin.Data;
using A4___Movie_Library___Eric_Peppin.Models;
using Microsoft.Extensions.Logging;

namespace A4___Movie_Library___Eric_Peppin.Services
{
    public class OrchestratorService : IOrchestrator
    {
        private readonly List<Media> _mediaList = new();
        private readonly MovieRepository _movieRepository;
        private readonly ShowRepository _showRepository;
        private readonly VideoRepository _videoRepository;
        // private readonly ILogger<IRepository> _logger;

        public OrchestratorService()
        {
            _movieRepository = new MovieRepository();
            _videoRepository = new VideoRepository();
            _showRepository = new ShowRepository();
        }

        public List<Media> SearchAllMedia(string searchString)
        {
            _mediaList.Add(_movieRepository.Search(searchString));
            _mediaList.Add(_videoRepository.Search(searchString));
            _mediaList.Add(_showRepository.Search(searchString));

            return _mediaList;
        }
    }
}