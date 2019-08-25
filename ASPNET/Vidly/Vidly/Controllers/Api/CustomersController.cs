using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using Vidly.Models;

namespace Vidly.Controllers.Api
{
    public class CustomersController : ApiController //derives from api controller not controller 
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/Customers
        public IQueryable<Customer> Getcustomers() //enumerable?
        {
            return db.customers; // can also do ToList()
        }

        // GET: api/Customers/5
        [ResponseType(typeof(Customer))]
        public async Task<IHttpActionResult> GetCustomer(int id)
        {
            Customer customer = await db.customers.FindAsync(id);
            if (customer == null)
            {
                return NotFound();
                // Can also use 
                //throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            return Ok(customer);
            //Can also just return customer?
        }

        // PUT: api/Customers/5
        [ResponseType(typeof(Customer))]
        public async Task<IHttpActionResult> PutCustomer(int id, Customer customer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != customer.Id)
            {
                return BadRequest();
            }

            db.Entry(customer).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
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

            return Ok(customer);
        }

        // POST: api/Customers
        [HttpPost]
        [ResponseType(typeof(Customer))]
        public async Task<IHttpActionResult> CreateCustomer(Customer customer)//Can also name PostCustomer and remove annotation
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.customers.Add(customer);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = customer.Id }, customer);
        }

        // DELETE: api/Customers/5
        [ResponseType(typeof(Customer))]
        public async Task<IHttpActionResult> DeleteCustomer(int id)
        {
            Customer customer = await db.customers.FindAsync(id);
            if (customer == null)
            {
                return NotFound();
            }

            db.customers.Remove(customer);
            await db.SaveChangesAsync();

            return Ok(customer);
        }


        //end connection to db
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        //method
        private bool CustomerExists(int id)
        {
            return db.customers.Count(e => e.Id == id) > 0;
        }
    }
}