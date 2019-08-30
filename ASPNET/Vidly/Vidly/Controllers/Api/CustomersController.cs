using AutoMapper;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using Vidly.Dtos;
using Vidly.Models;

namespace Vidly.Controllers.Api
{

    public class CustomersController : ApiController //derives from api controller not controller 
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/Customers
        public IQueryable<Dtos.Customer> Getcustomers() //enumerable?
        {
            // mapping customer obj to customer dto, using a delegate mapper.map this will return the customer DTO??
            //select performs an operation => "mapper on each customer"
            var customersQuery = db.customers
                 .Include(c => c.MembershipType)
                 .Select(Mapper.Map<Models.Customer, Dtos.Customer>)
                 .AsQueryable(); // can also do ToList()
            return customersQuery;
        }

        // GET: api/Customers/5
        [ResponseType(typeof(Dtos.Customer))]
        public async Task<IHttpActionResult> GetCustomer(int id)
        {
            Models.Customer customer = await db.customers.FindAsync(id);
            if (customer == null)
            {
                return NotFound();
                // Can also use 
                //throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            //Can't use the select method of linq so instead we pass the customer obj as an argument? 
            return Ok(Mapper.Map<Models.Customer, Dtos.Customer>(customer));
            //Can also just return customer?
        }

        // PUT: api/Customers/5
        [ResponseType(typeof(Models.Customer))] //Responding with DTO instead of customer
        public async Task<IHttpActionResult> PutCustomer(int id, Models.Customer customer)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != customer.Id) //here be dragons
            {
                return BadRequest();
            }

            //mapping the customer to the DTO to check changes
            var foundCustomer = db.customers.SingleOrDefault(c => c.Id == id);
            //Mapper.Map(CustomerDto, customerInDB); // no declaration passed. Inferred by argumments 
            db.Entry(foundCustomer).State = EntityState.Modified;
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

            return Ok(foundCustomer);
        }

        // POST: api/Customers
        [HttpPost]
        [ResponseType(typeof(Models.Customer))]
        public async Task<IHttpActionResult> CreateCustomer(Models.Customer customer)//Can also name PostCustomer and remove annotation
        {
            //var customer = Mapper.Map<Dtos.Customer, Models.Customer>(customerDto); //mapping the CustomerDto to Customer

            db.customers.Add(customer);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);// returns error with message
            }
            await db.SaveChangesAsync();

            //Not sure if the Id returned should be the Dto or regular Customer
            return CreatedAtRoute("DefaultApi", new { id = customer.Id }, customer);
        }

        // DELETE: api/Customers/5
        [ResponseType(typeof(Models.Customer))]
        public async Task<IHttpActionResult> DeleteCustomer(int id)
        {

            Models.Customer customer = await db.customers.FindAsync(id);
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


//https://stackoverflow.com/questions/2433306/whats-the-difference-between-iqueryable-and-ienumerable?rq=1