using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using CoolDesk.Models;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace CoolDesk.API
{
    [Route("api/[controller]")]
    public class MoviesController : Controller
    {
        private ApplicationDbContext _db;
        public MoviesController(ApplicationDbContext db)
        {
            this._db = db;
        }

        // GET: api/values
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_db.Movies.ToList());
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            //return _db.Movies.Where(m => m.Id == id).FirstOrDefault();
            return Ok((from m in _db.Movies where m.Id == id select m).FirstOrDefault());
        }

        // POST api/movies
        [HttpPost]
        public IActionResult Post([FromBody]Movie value)
        {
            if(value.Id == 0)
            {
                _db.Movies.Add(value);
            }
            else
            {
                var movieToEdit = _db.Movies.Where(m => m.Id == value.Id).FirstOrDefault();
                movieToEdit.Title = value.Title;
                movieToEdit.Director = value.Director;
                _db.SaveChanges();
            }
            return Ok();
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var movieToDelete = _db.Movies.Where(m => m.Id == id).FirstOrDefault();
            _db.Movies.Remove(movieToDelete);
            _db.SaveChanges();

            return Ok();
        }
    }
}
