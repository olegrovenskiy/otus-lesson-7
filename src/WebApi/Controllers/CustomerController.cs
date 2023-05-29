using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApi.Models;

namespace WebApi.Controllers
{
    [Route("customers")]
    public class CustomerController : Controller
    {
        [HttpGet("{id:long}")]   
        public IActionResult GetCustomer([FromRoute] long id)
        {
            using (CustomerContext db = new CustomerContext())
            {

                var found = db.Customers.Find(id);
                if (found == null)
                {
                    return NotFound();
                }

                else
                    return Ok(found);


             }
        }

        [HttpPost("")]   
        public IActionResult CreateCustomer([FromBody] Customer customer)
        {

            using (CustomerContext db = new CustomerContext())
            {
              Console.WriteLine(customer.Firstname);

                var item = db.Customers.Find(customer.Id);

                if (item == null)
                {

                    db.Customers.Add(customer);
                    db.SaveChanges();

                  //  return CreatedAtAction(nameof(CreateCustomer), new { id = customer.Id }, customer);

                    return Ok(CreatedAtAction(nameof(CreateCustomer), new { id = customer.Id }, customer));
                }

                else
                    return Conflict();

            }

        }
    }
}