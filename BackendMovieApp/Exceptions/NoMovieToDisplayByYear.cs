using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendMovieApp.Exceptions
{
    public class NoMovieToDisplayByYear:Exception
    {
        public NoMovieToDisplayByYear(string message) : base(message) { 
        
        }   
    }
}
