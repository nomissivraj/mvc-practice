using System;
using System.Collections.Generic;
using System.Data.Entity;
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

            var viewModel = new MovieFormViewModel
            {
                Genres = _context.Genres.ToList()
            };

            return View("MovieForm", viewModel);
        }

        // Post save from form above
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(MovieModel movie)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new MovieFormViewModel(movie)
                {
                    Genres = _context.Genres.ToList()
                };
                return View("MovieForm", viewModel);
            }

            //movie.DateAdded = DateTime.Now;
            if (movie.ID == 0)
            {
                movie.DateAdded = DateTime.Now;
                _context.Movies.Add(movie);
            }
            else
            {
                var movieInDB = _context.Movies.Single(m => m.ID == movie.ID);
                movieInDB.Name = movie.Name;
                movieInDB.ReleaseDate = movie.ReleaseDate;
                movieInDB.GenreId = movie.GenreId;
                movieInDB.Stock = movie.Stock;
            }
            _context.SaveChanges();

            if (movie.ID == 0)
            {
                return RedirectToAction("Index", "Movies");
            }
            else
            {
                return RedirectToAction("Movie", "Movies", new { id = movie.ID });
            }

        }

        public ActionResult Edit(int ID)
        {

            var movie = _context.Movies.SingleOrDefault(m => m.ID == ID);
            if (movie == null)
                return HttpNotFound();

            var viewModel = new MovieFormViewModel(movie)
            {
                Genres = _context.Genres.ToList()//for select dropdown
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
            var movies = _context.Movies.Include(m => m.Genre).ToList();

            Random r = new Random();
            int rInt = r.Next(1, movies.Count + 1);

            var movie = movies.Find(x => x.ID == rInt);


            return View(movie);
        }

        public ActionResult Movie(int ID)
        {
            var movie = _context.Movies.Include(m => m.Genre).SingleOrDefault(m => m.ID == ID);
            if (movie == null)
                return HttpNotFound();


            return View(movie);
        }


    }
}