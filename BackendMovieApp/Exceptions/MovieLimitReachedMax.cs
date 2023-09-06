using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendMovieApp.Exceptions
{
    public class MovieLimitReachedMax:Exception
    {
        public MovieLimitReachedMax(string message):base(message) { 
        
        }
    }
}
