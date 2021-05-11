using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using Newtonsoft.Json;

namespace MovieStar
{
    public class StartUp
    {
        public static List<MovieStar> GetMovieStarsData(IEnumerable<MovieStarDto> data)
        {
            List<MovieStar> movieStars = new List<MovieStar>();
            
            foreach (MovieStarDto personData in data)
            {
                var newDate = DateTime.ParseExact(personData.DateOfBirth, "MMMM dd, yyyy",  
                    CultureInfo.InvariantCulture);
                
                int age = DateTime.Now.Year - newDate.Year;

                if (DateTime.Now.Month < newDate.Month)
                {
                    age -= 1;
                }
                
                movieStars.Add(new MovieStar
                {
                    Name = personData.Name,
                    Surname =  personData.Surname,
                    Age =  age,
                    Sex =  personData.Sex,
                    Nationality = personData.Nationality,
                });
            }

            return movieStars;
        }

        public static void PrintMoviesInformation(List<MovieStar> movies)
        {
            foreach (MovieStar movieData in movies)
            {
                Console.WriteLine($"{movieData.Name} {movieData.Surname}");
                Console.WriteLine(movieData.Sex);
                Console.WriteLine(movieData.Nationality);
                Console.WriteLine(movieData.Age);
                
                Console.WriteLine();
            }
        }
            
        static void Main(string[] args)
        {
            string data = File.ReadAllText("../../../input.txt");
            MovieStarDto[] jsonData = JsonConvert.DeserializeObject<MovieStarDto[]>(data);
            List<MovieStar> movieStars = GetMovieStarsData(jsonData);
            PrintMoviesInformation(movieStars);
        }
    }
}