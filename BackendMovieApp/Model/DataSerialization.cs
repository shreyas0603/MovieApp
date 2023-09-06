using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace BackendMovieApp.Model
{
    public class DataSerialization
    {
        public static void BinarySerializer(List<Movie> movies, string filepath)
        {
            using (FileStream fileStream = new FileStream(filepath, FileMode.OpenOrCreate, FileAccess.Write))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                //foreach (Movie movie in movies)
                //{
                    formatter.Serialize(fileStream, movies);
                
                //}
            }
        }

        public static List<Movie> BinaryDeserializer(string filepath)
        {
            List<Movie> result = new List<Movie>();

            using (FileStream fileStream = new FileStream(filepath, FileMode.OpenOrCreate, FileAccess.Read))
            {
                if(fileStream.Length > 0)
                {

                BinaryFormatter formatter = new BinaryFormatter();

                //while (fileStream.Position < fileStream.Length)
                //{
                    result =(List<Movie>)formatter.Deserialize(fileStream);
               
                //}

                }

            }
            return result;

        }
    }
}
