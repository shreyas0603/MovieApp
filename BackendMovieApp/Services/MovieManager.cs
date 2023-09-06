
using BackendMovieApp.Exceptions;
using BackendMovieApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;


namespace BackendMovieApp.Services
{
    public class MovieManager
    {
        public static string filepath = @"D:\Swabhavsessions\session3\ModifiedMovieApp\MovieList.txt";
        public static List<Movie> movies; //= new List<Movie>();
        public static int MaxCount = 5;

        public MovieManager()
        {
            movies = new List<Movie>();
            movies = DataSerialization.BinaryDeserializer(filepath);
        }

        public static int MovieCount()
        {
            int count= movies.Count;
            return count;
        }

        public static void Add(int movId, string movName, string movGenre, int movYear)
        {
                Movie movie = new Movie(movId, movName, movGenre, movYear);
                movies.Add(movie);
                DataSerialization.BinarySerializer(movies, filepath);
            
        }

        public static void ClearAll()
        {
            if (movies.Count == 0)
            {
                throw new NoMovieToBeCleared("No movies to be cleared");
            }
            movies.Clear();
            DataSerialization.BinarySerializer(movies, filepath);
        }

        public static List<Movie> DisplayByYear(int movyear)
        {
            var years = movies.FindAll(y => y.Year == movyear);

            if (!years.Any())
            {
                throw new NoMovieToDisplayByYear("No movie found in the year mentioned");
            }
            return years;

        }

        public static Movie Find(int delid)
        {
            Movie id = movies.Find(x => x.MovieId == delid);
            if (id != null)
            {
                return id;
            }
            else
            {
                throw new NoMovieToBeRemoved("Movie id not found");

            }

        }

        public static void RemoveMovie(Movie id)
        {
            movies.Remove(id);
            DataSerialization.BinarySerializer(movies, filepath);
        }

        public static void Display()
        {
            if (movies.Count == 0)
            {
                throw new MovieLimitReachedMin("The List is empty.Add movies to run this functionality\n");
            }
        }

        public static void CheckCount()
        {
            if (movies.Count >= MaxCount)
            {
                throw new MovieLimitReachedMax("You can only store upto 5 Movies");
            }
        }

       public static List<Movie> AllMovie()
        {
            return movies;
        }
    }
}
