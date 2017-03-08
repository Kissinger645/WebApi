using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using WebApi.Models;

namespace WebApi.Controllers
{
    
    public class MovieController : ApiController
    {
        MovieContext db = new MovieContext();

        [ResponseType(typeof(Movie))]
        public IHttpActionResult Get()
        {
            DbSet<Movie> results = db.Movies;
            return Ok(results);
        }

        public IHttpActionResult Get(int id)
        {
            var result = db.Movies.Find(id);
            return Ok(result);
        }

        [ResponseType(typeof(Movie))]
        public IHttpActionResult Post(Movie movie)
        {
            db.Movies.Add(movie);
            db.SaveChanges();
            return Created("Get", movie);
        }

        public IHttpActionResult Put(int id, Movie movie)
        {
            movie.Id = id;
            db.Entry(movie).State = EntityState.Modified;
            db.SaveChanges();

            return Ok();
        }

        public IHttpActionResult Delete(int id)
        {
            var mov = db.Movies.Find(id);
            db.Movies.Remove(mov);
            return StatusCode(HttpStatusCode.NoContent);
        }

        
    }
}
