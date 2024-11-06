using FMP.Models;
using Microsoft.AspNetCore.Mvc;

namespace FMP.Controllers
{
    [Route("api/FMP")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly DBConfig _context;

        public CustomerController(DBConfig context)
        {
            _context = context;
        }

        [HttpGet ( "GetCustomers")]
        public ActionResult<IEnumerable<Customer>> GetC()
        {
            try
            {
                List<Customer> customers = _context.Customers.ToList();
                return Ok(customers);
            }catch (Exception ex) { return StatusCode(500, ex); }
        }

        [HttpGet("GetMovies")]
        public ActionResult<IEnumerable<Movie>> GetM()
        {
            try
            {
                return Ok(_context.Movies.ToList());
            }
            catch (Exception ex) { return StatusCode(500, ex); }
        }

        [HttpGet("GetTickets")]
        public ActionResult<IEnumerable<Ticket>> GetT()
        {
            try
            {
                return Ok(_context.Tickets.ToList());
            }
            catch (Exception ex) { return StatusCode(500, ex); }
        }

        [HttpPost("AddCustomer")]
        public IActionResult AddC([FromBody] NewCustomer customer)
        {
            try
            {
                Customer c = new Customer();
                if (_context.Customers.Select(x => x.Email == customer.Email).Count() == 0)
                    if (customer.Password == customer.Password2)
                    {
                        c.Name = customer.Name;
                        c.Email = customer.Email;
                        c.PhoneNumber = customer.PhoneNumber;
                        c.Password = customer.Password;
                        c.Age = customer.Age;
                        _context.Customers.Add(c);
                        _context.SaveChanges();
                    }
                return CreatedAtAction(nameof(GetC), c);
            }
            catch (Exception ex) { return StatusCode(500, ex); }

        }

        [HttpPost("AddMovie")]
        public IActionResult AddM([FromBody] NewMovie movie)
        {
            try
            {
                Movie m = new Movie();
                if (_context.Movies.Where(x => x.Title.Equals(movie.Title)).Count() == 0)
                {
                    m.Title = movie.Title;
                    m.Price = movie.Price;
                    m.MovieDuration = movie.MovieDuration;
                    m.Description = movie.Description;
                    m.Date = movie.Date;
                    _context.Movies.Add(m);
                    _context.SaveChanges();
                }
                return CreatedAtAction(nameof(GetM), m);
            }
            catch (Exception ex) { return StatusCode(500, ex); }
        }

        [HttpPost("AddTicket")]
        public IActionResult AddT([FromBody] NewTicket ticket)
        {
            Ticket t = new Ticket();
            try
            {
                t.Date = ticket.Date;
                t.CustomerId = ticket.CustomerId;
                t.MovieId = ticket.MovieId;
                t.Price = ticket.Price;
                _context.Tickets.Add(t);
                _context.SaveChanges();
                return CreatedAtAction(nameof(GetT), t);
            }
            catch (Exception ex) { return StatusCode(500, ex); }
        }


    }
}
