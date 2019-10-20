using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Vidly_Movie_Store.Models;
using System.Data.Entity;
using AutoMapper;
using Vidly_Movie_Store.Dtos;
using Vidly_Movie_Store.Models.IdentityModels;

namespace Vidly_Movie_Store.Controllers.Api
{
    public class MoviesController : ApiController
    {
        private ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }

        public IEnumerable<MovieDto> GetMovies(string query = null)
        {
            var moviesQuery = _context.Movies
                .Include(m => m.Genres)
                .Where(m => m.NumberAvailable > 0);

            if (!String.IsNullOrWhiteSpace(query))
                moviesQuery = moviesQuery.Where(c => c.Name.Contains(query));

            return moviesQuery
                .ToList().Select(Mapper.Map<Movie, MovieDto>);

           // return Ok(movies);
        }

        public IHttpActionResult GetMovie(int id)
        {
            var movie = _context.Movies.SingleOrDefault(m => m.Id == id);

            if (movie == null)
                return NotFound();

            return Ok(Mapper.Map<Movie, MovieDto>(movie));
        }

        [HttpPost]
        [Authorize(Roles = RoleName.CanManageMovies)]
        public IHttpActionResult CreateMovie(MovieDto movieDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var movie = Mapper.Map<MovieDto, Movie>(movieDto);

            _context.Movies.Add(movie);
            _context.SaveChanges();

            movieDto.Id = movie.Id;

            return Created(new Uri(Request.RequestUri + "/" + movieDto.Id), movieDto);
        }

        [HttpPut]
        [Authorize(Roles = RoleName.CanManageMovies)]
        public IHttpActionResult UpdateMovie(int id, MovieDto movieDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var movie = _context.Movies.SingleOrDefault(m => m.Id == id);

            if (movie == null)
                return NotFound();

            Mapper.Map(movieDto, movie);

            _context.SaveChanges();

            return Ok();
        }

        [Authorize(Roles = RoleName.CanManageMovies)]
        public IHttpActionResult DeleteMovie(int id)
        {
            var movie = _context.Movies.SingleOrDefault(m => m.Id == id);

            if (movie == null)
                return BadRequest();

            _context.Movies.Remove(movie);
            _context.SaveChanges();

            return Ok();
        }
    }
}
