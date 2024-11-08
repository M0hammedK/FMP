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
        [HttpPut("EditCustomer/{id}")]
        public IActionResult EditC(int id, [FromBody] NewCustomer customer)
        {
            try
            {
                Customer c = new Customer();
                if (id != 0)
                    if (customer.Password == customer.Password2)
                    {
                        c.Id = id;
                        c.Name = customer.Name;
                        c.Email = customer.Email;
                        c.PhoneNumber = customer.PhoneNumber;
                        c.Password = customer.Password;
                        c.Age = customer.Age;
                        _context.Customers.Update(c);
                        _context.SaveChanges();
                    }
                return Ok(c);
            }
            catch (Exception ex) { return StatusCode(500, ex); }

        }

        [HttpPut("EditMovie/{id}")]
        public IActionResult EditM(int id, [FromBody] NewMovie movie)
        {
            try
            {
                Movie m = new Movie();
                if(id != 0)
                {
                    m.Id = id;
                    m.Title = movie.Title;
                    m.Price = movie.Price;
                    m.MovieDuration = movie.MovieDuration;
                    m.Description = movie.Description;
                    m.Date = movie.Date;
                    _context.Movies.Update(m);
                    _context.SaveChanges();
                }
                return Ok(m);
            }
            catch (Exception ex) { return StatusCode(500, ex); }
        }

        [HttpPut("EditTicket/{id}")]
        public IActionResult EditT(int id, [FromBody] NewTicket ticket)
        {
            Ticket t = new Ticket();
            try
            {
                t.Id = id;
                t.Date = ticket.Date;
                t.CustomerId = ticket.CustomerId;
                t.MovieId = ticket.MovieId;
                t.Price = ticket.Price;
                _context.Tickets.Update(t);
                _context.SaveChanges();
                return Ok(t);
            }
            catch (Exception ex) { return StatusCode(500, ex); }
        }
        [HttpDelete("DeleteCustomer/{id}")]
        public IActionResult DeleteC(int id)
        {
            try
            {
                if (id != 0)
                { 
                    _context.Customers.Remove(_context.Customers.FirstOrDefault(x => x.Id == id));
                    _context.SaveChanges();
                }
                return NoContent();
            }
            catch (Exception ex) { return StatusCode(500, ex); }

        }

        [HttpDelete("DeleteMovie/{id}")]
        public IActionResult DeleteM(int id)
        {
            try
            {
                if (id != 0)
                {
                    _context.Movies.Remove(_context.Movies.FirstOrDefault(x => x.Id == id));
                    _context.SaveChanges();
                }
                return NoContent();
            }
            catch (Exception ex) { return StatusCode(500, ex); }
        }

        [HttpDelete("DeleteTicket/{id}")]
        public IActionResult DeleteT(int id)
        {
            try
            {
                if (id != 0)
                {
                    _context.Tickets.Remove(_context.Tickets.FirstOrDefault(x => x.Id == id));
                    _context.SaveChanges();
                }
                return NoContent();
            }
            catch (Exception ex) { return StatusCode(500, ex); }
        }
    }
}
