using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Vidly.Models;
using Vidly.DTOs;
using AutoMapper;

namespace Vidly.Controllers.API
{
    public class MoviesController : ApiController
    {

        private ApplicationDbContext _context;

        public MoviesController() // |||||||||||||||| Re-watch this part to see if explained
        {
            _context = new ApplicationDbContext();
        }

        //GET /api/movies
        public IEnumerable<MovieDTO> GetMovies() {

            return _context.Movies.ToList().Select(Mapper.Map<MovieModel, MovieDTO>);    
        }

        //GET /api/movies/1
        public IHttpActionResult GetMovie(int id)
        {
            var movie = _context.Movies.SingleOrDefault(mv => mv.ID == id);

            if (movie == null)
                return NotFound();

            return Ok(Mapper.Map<MovieModel, MovieDTO>(movie));
        }

        //POST /api/movies/
        [HttpPost]
        public IHttpActionResult CreateMovie(MovieDTO movieDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var movie = Mapper.Map<MovieDTO, MovieModel>(movieDTO);

            movie.DateAdded = movie.DateAdded = DateTime.Now;

            // Could do custom functionality for adding genre as a string

            //             (|add to DTO|)
            // i.e. if movieDTO.Genre string is in db genretable return id from table and set movie.GenreId to that id


            _context.Movies.Add(movie);
            _context.SaveChanges();

            movieDTO.ID = movie.ID; // |||||||||||||||| Rewatch this bit to understand better

            return Created(new Uri(Request.RequestUri + "/" + movie.ID), movieDTO);
        }

        //PUT /api/customers/1
        [HttpPut]
        public void UpdateMovie(int id, MovieDTO movieDTO)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            // Get target movie from database to update
            var movieInDb = _context.Movies.SingleOrDefault(mv => mv.ID == id);
            // If not exist throw httpResponseException error
            if (movieInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            // Could do custom functionality for adding genre as a string

            //             (|add to DTO|)
            // i.e. if movieDTO.Genre string is in db genretable return id from table and set movie.GenreId to that id



            // Finally map the incomig data (movieDTO) to the db context (movieInDb) and then save the overall context
            Mapper.Map(movieDTO, movieInDb);

            _context.SaveChanges();
        }


        //DELETE /api/customers/1
        [HttpDelete]
        public void DeleteMovie(int id)
        {
            var movieInDb = _context.Movies.SingleOrDefault(mv => mv.ID == id);
            if (movieInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            _context.Movies.Remove(movieInDb);
            _context.SaveChanges();

        }

    }
}
