using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebFlix.Models;

namespace WebFlix.Controllers
{
    [RoutePrefix("api/Movie")]
    public class MovieController : ApiController
    {
        //this is where we create a list iof movies
        private static List<Movie> Movies = new List<Movie>()
        {
            new Movie(){MovieID=1, Title="The Quiet Man", Cert=Certificate.PG, Gen=Genre.drama, ReleaseDate=new DateTime(1952, 6, 1), AvgRating=10},
            new Movie(){MovieID=2, Title="Darby O'Gill And The Little People", Cert=Certificate.PG, Gen=Genre.family, ReleaseDate=new DateTime(1965, 6, 1), AvgRating=8},
            new Movie(){MovieID=3, Title="Ryans Daughter", Cert=Certificate.Eighteen, Gen=Genre.drama, ReleaseDate=new DateTime(1962, 6, 1), AvgRating=10},
            new Movie(){MovieID=4, Title="Kisses", Cert=Certificate.Twelve, Gen=Genre.drama, ReleaseDate=new DateTime(2008, 6, 1), AvgRating=10}
        };

        // GET: api/Movie
        [Route("")]
        public IEnumerable<Movie> Get()
        {
            return Movies.OrderByDescending(p => p.ReleaseDate);//.Select(x => x.Title);
        }

        // GET: api/Movie/5
        [Route("GetById/{id}")]
        public string GetById(int id)
        {
            var foundValue = Movies.FirstOrDefault(p => p.MovieID == id);
            if (foundValue!=null)
            {
                return foundValue.Title;
            }
            else 
            {
                return "No Movie with that ID found!";
            }
        }

        // GET: api/Movie/5
        [HttpGet]
        [Route("WithWord/{word}")]
        
        public string WithWord(String word)
        {
            var foundValue = Movies.FirstOrDefault(p => p.Title.ToLower().Contains(word.ToLower()));
            if (foundValue != null)
            {
                return foundValue.Title;
            }
            else
            {
                return "No Movie with that word in the title found!";
            }
        }

        [HttpPost]
        [Route("AddMovie")]
        public HttpResponseMessage AddMovie(Movie newMovie)
        {
            var foundValue = Movies.FirstOrDefault(p => p.Title.ToLower().Contains(newMovie.Title.ToLower()));
            if (foundValue != null)
            {
                return new HttpResponseMessage(HttpStatusCode.Conflict);
            }
            else
            {
                Movies.Add(newMovie);
                return new HttpResponseMessage(HttpStatusCode.OK);
            }
        }
        
    }
}
