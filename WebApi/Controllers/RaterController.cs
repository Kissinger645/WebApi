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
    public class RaterController : ApiController
    {
        MovieContext db = new MovieContext();

        [ResponseType(typeof(Rater))]
        public IHttpActionResult Get()
        {
            DbSet<Rater> results = db.Raters;
            return Ok(results);
        }

        public IHttpActionResult Get(int id)
        {
            Rater result = db.Raters.Find(id);
            return Ok(result);
        }

        public IHttpActionResult Post(Rater rater)
        {
            db.Raters.Add(rater);
            db.SaveChanges();
            return Created("Get", rater);
        }

        public IHttpActionResult Put(int id, Rater rater)
        {
            rater.Id = id;
            db.Entry(rater).State = EntityState.Modified;

            // Step 3
            db.SaveChanges();
            return Ok();
        }

        public IHttpActionResult Delete(int id)
        {
            Rater rater = db.Raters.Find(id);
            db.Raters.Remove(rater);
            db.SaveChanges();
            return StatusCode(HttpStatusCode.NoContent);
        }
    }
}
