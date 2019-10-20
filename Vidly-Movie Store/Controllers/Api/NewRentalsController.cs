using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Vidly_Movie_Store.Dtos;
using Vidly_Movie_Store.Models;
using Vidly_Movie_Store.Models.IdentityModels;

namespace Vidly_Movie_Store.Controllers.Api
{
    public class NewRentalsController : ApiController
    {
        private ApplicationDbContext _context;

        public NewRentalsController()
        {
            _context = new ApplicationDbContext();
        }

        [HttpPost]
        public IHttpActionResult CreateNewRentals(NewRentalDto newRentalsDto)
        {
            var customerInDb = _context.Customers.Single(c => c.Id == newRentalsDto.CustomerId);
            var movies = _context.Movies.Where(m => newRentalsDto.MovieIds.Contains(m.Id)).ToList();

            foreach (Movie m in movies)
            {
                if (m.NumberAvailable == 0)
                    return BadRequest("Movie is not available.");

                m.NumberAvailable--;
                var rental = new Rental()
                {
                    Customer = customerInDb,
                    Movie = m,
                    DateRented = DateTime.Now
                };

                _context.Rentals.Add(rental);
            }

            _context.SaveChanges();

            return Ok();
        }
    }
}
