using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using WebFlix.Models;

namespace MovieClient
{
    class Program
    {
        static async Task GetTheMovies()
        {
            HttpClient theClient = new HttpClient();
            theClient.BaseAddress = new Uri("http://localhost:4734/");

            theClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = await theClient.GetAsync("api/Movie");

            if (response.IsSuccessStatusCode)
            {
                var returnedMovies = await response.Content.ReadAsAsync<IEnumerable<Movie>>();

                foreach(Movie mv in returnedMovies)
                {
                    Console.WriteLine(mv.Title);
                }
            }
        }
        
        //just adding a comment
        static void Main(string[] args)
        {
            GetTheMovies().Wait();
        }
    }
}
