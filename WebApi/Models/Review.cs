using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebApi.Models
{
    public class Review
    {
        public int Id { get; set; }
        public int Rating { get; set; }
        public virtual Movie Title { get; set; }
        public virtual Rater RaterName { get; set; }
    }

}