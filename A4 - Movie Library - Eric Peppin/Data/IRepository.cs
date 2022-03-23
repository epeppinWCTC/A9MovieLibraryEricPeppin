using System.Collections.Generic;
using A4___Movie_Library___Eric_Peppin.Models;

namespace A4___Movie_Library___Eric_Peppin.Data
{
    public interface IRepository
    
    {
        void Add(Media media);
        List<Media> GetAll();
        Media? Search(string? searchString);
    }
}