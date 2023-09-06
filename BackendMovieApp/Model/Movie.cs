using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendMovieApp
{
    [Serializable]
    public class Movie
    {
        public int MovieId { get; set; }

        public string Name { get; set; }

        public string Genre { get; set; }

        public int Year { get; set; }


        public Movie(int id, string name, string genre, int year)
        {
            MovieId = id;
            Name = name;
            Genre = genre;
            Year = year;
        }
    }
}
