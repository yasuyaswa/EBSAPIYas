using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EBSYas.Models;

namespace EBSYas.Controllers.cs
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly EBSContext _context;

        public CustomersController(EBSContext context)
        {
            _context = context;
        }

        // GET: api/Customers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Customer>>> GetCustomers()
        {
          if (_context.Customers == null)
          {
              return NotFound();
          }
            return await _context.Customers.ToListAsync();
        }

        // GET: api/Customers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Customer>> GetCustomer(decimal id)
        {
          if (_context.Customers == null)
          {
              return NotFound();
          }
            var customer = await _context.Customers.FindAsync(id);

            if (customer == null)
            {
                return NotFound();
            }

            return customer;
        }

        // PUT: api/Customers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCustomer(decimal id, Customer customer)
        {
            if (id != customer.CustomerId)
            {
                return BadRequest();
            }

            _context.Entry(customer).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CustomerExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Customers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Customer>> PostCustomer(Customer customer)
        {
          if (_context.Customers == null)
          {
              return Problem("Entity set 'EBSContext.Customers'  is null.");
          }
            _context.Customers.Add(customer);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCustomer", new { id = customer.CustomerId }, customer);
        }

        // DELETE: api/Customers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomer(decimal id)
        {
            if (_context.Customers == null)
            {
                return NotFound();
            }
            var customer = await _context.Customers.FindAsync(id);
            if (customer == null)
            {
                return NotFound();
            }

            _context.Customers.Remove(customer);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        //private bool CustomerExists(decimal id)
        //{
        //    return (_context.Customers?.Any(e => e.CustomerId == id)).GetValueOrDefault();
        //}
        [HttpPost("Login")]
        public async Task<ActionResult<Customer>> Login([FromBody] Signin customer)
        {
            if (_context.Customers == null)
            {
                return NotFound("Invalid credentials");
            }
            var A_Details = await _context.Customers.Where(x => x.CustomerEmail == customer.CustomerEmail && x.CustomerPassword == customer.CustomerPassword).Select(x => new Customer()
            {
                CustomerId = x.CustomerId,
                CustomerName = x.CustomerName,
                CustomerEmail = x.CustomerEmail,
                CustomerMobile = x.CustomerMobile,
                CustomerPassword = x.CustomerPassword,

            })
                .FirstOrDefaultAsync();
            if (A_Details == null)
            {
                return NotFound("Invalid credentials");
            }
            return Ok(A_Details);
        }

        private bool CustomerExists(decimal id)
        {
            return _context.Customers.Any(e => e.CustomerId == id);
        }
    }

}

