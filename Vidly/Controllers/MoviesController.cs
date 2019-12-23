using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {

        private ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // Return form for new
        public ActionResult New()
        {
            var genres = _context.Genres.ToList();

            var viewModel = new MovieFormViewModel
            {
                Genres = genres
            };

            return View("MovieForm", viewModel);
        }

        // Post save from form above
        [HttpPost]
        public ActionResult Save(MovieModel movie)
        {
            //movie.DateAdded = DateTime.Now;
            _context.Movies.Add(movie);

            _context.SaveChanges();

            return RedirectToAction("Index", "Movies");
        }

        public ActionResult Edit(int ID)
        {

            var movie = _context.Movies.SingleOrDefault(m => m.ID == ID);
            if (movie == null)
                return HttpNotFound();

            var viewModel = new MovieFormViewModel
            {
                Movie = movie,
                Genres = _context.Genres.ToList()
            };

            return View("MovieForm", viewModel);
        }


        public ActionResult Index()
        {
            var movies = _context.Movies.ToList();

            return View(movies);
        }

        public ActionResult Random()
        {
            var movies = _context.Movies.ToList();

            Random r = new Random();
            int rInt = r.Next(1, movies.Count +1);

            var movie = movies.Find(x => x.ID == rInt);

            
            return View(movie);
        }

        public ActionResult Movie(int ID)
        {
            var movie = _context.Movies.SingleOrDefault(c => c.ID == ID);
            if (movie == null)
                return HttpNotFound();


            return View(movie);
        }
        
        
    }
}