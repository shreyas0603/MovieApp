
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BackendMovieApp;
using BackendMovieApp.Services;

namespace ModifiedMovieApp.Controller
{
    internal class MovieController
    {
        
        public MovieController()
        {

            Console.WriteLine("======================Welcome======================");

            UserInput();
        }
        static void UserInput()
        {
            while (true)
            {
                try
                {

                    new MovieManager();
                    int movieCount = MovieManager.MovieCount();
                    Console.WriteLine($"Movie Store Status: {movieCount}/5");

                    int userInput = Operations();

                    if (userInput < 7)
                    {
                        if (userInput == 1)
                        {
                            Add();
                            UserInput();
                            break;
                        }
                        else if (userInput == 2)
                        {
                            Display();

                        }
                        else if (userInput == 3)
                        {
                            ClearAll();
                        }
                        else if (userInput == 4)
                        {
                            DisplayByYear();
                        }
                        else if (userInput == 5)
                        {
                            RemoveMovie();
                        }
                        else if (userInput == 6)
                        {
                            return;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid Choice\n");
                    }
                }
                catch (FormatException ex)
                {
                    Console.WriteLine("Please Enter Valid input: " + ex.Message);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        static void RemoveMovie()
        {
            try
            {

                Console.WriteLine("Enter MoveId which you want to remove:");
                int delid = Convert.ToInt32(Console.ReadLine());
                Movie id = MovieManager.Find(delid);

                MovieManager.RemoveMovie(id);
                Console.WriteLine("The Movie has been Removed Successfully");


            }
            catch (FormatException ex)
            {
                Console.WriteLine("Please Enter a Valid input:" + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        static void DisplayByYear()
        {
            try
            {

                Console.WriteLine("Enter Movie Year you want to display:");
                int movyear = Convert.ToInt32(Console.ReadLine());
                var years = MovieManager.DisplayByYear(movyear);
                if (years.Any())
                {
                    foreach (var year in years)
                    {
                        Console.WriteLine($"Movie Id:{year.MovieId}\n" +
                                          $"Movie Name:{year.Name}\n" +
                                          $"Movie Genre:{year.Genre}\n" +
                                          $"Movie Release Year:{year.Year}\n");
                        Console.WriteLine("======================================================================");
                    }
                }

            }
            catch (FormatException ex)
            {

                Console.WriteLine("Please Enter Valid input: " + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        static int Operations()
        {
            Console.WriteLine("List of operation is given below:-\n");
            Console.WriteLine($"1.Add Movies\n" +
                              $"2.Display Movies\n" +
                              $"3.Clear all\n" +
                              $"4.Display by Year\n" +
                              $"5.Remove a Movie\n" +
                              $"6.Exit\n");
            Console.WriteLine("Enter your Choice:");
            int input = Convert.ToInt32(Console.ReadLine());
            return input;

        }

        static void Add()
        {
            try
            {
                MovieManager.CheckCount();
                Console.WriteLine($"Enter MovieId : ");
                int movId = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine($"Enter Movie Name : ");
                string movName = Convert.ToString(Console.ReadLine());
                Console.WriteLine($"Enter Movie Genre : ");
                string movGenre = Convert.ToString(Console.ReadLine());
                Console.WriteLine($"Enter Movie Release Year : ");
                int movYear = Convert.ToInt32(Console.ReadLine());

                MovieManager.Add(movId, movName, movGenre, movYear);

                Console.WriteLine("Movie Added Successfully\n");


                Console.WriteLine("====================================================================");
               

            }
            catch (FormatException ex)
            {
                Console.WriteLine("Please enter valid input:" + ex.Message);
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
        }

        static void Display()
        {
            try
            {
                MovieManager.Display();
                List<Movie> movies=MovieManager.AllMovie();

                foreach (Movie movie in movies)
                {
                    {
                        Console.WriteLine($"Movie Id:{movie.MovieId}\n" +
                                          $"Movie Name:{movie.Name}\n" +
                                          $"Movie Genre:{movie.Genre}\n" +
                                          $"Movie Release Year:{movie.Year}\n");
                        Console.WriteLine("======================================================================");
                    }
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        static void ClearAll()
        {
            try
            {
                MovieManager.ClearAll();
                Console.WriteLine("All Movies Cleared Up");
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
        }
    }
}
