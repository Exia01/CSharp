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
        public IQueryable<CustomerDto> Getcustomers() //enumerable?
        {
            // mapping customer obj to customer dto, using a delegate mapper.map this will return the customer DTO??
            return db.customers.Select(Mapper.Map<Customer, CustomerDto>).AsQueryable(); // can also do ToList()
        }

        // GET: api/Customers/5
        [ResponseType(typeof(CustomerDto))]
        public async Task<IHttpActionResult> GetCustomer(int id)
        {
            Customer customer = await db.customers.FindAsync(id);
            if (customer == null)
            {
                return NotFound();
                // Can also use 
                //throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            //Can't use the select method of linq so instead we pass the customer obj as an argument? 
            return Ok(Mapper.Map<Customer, CustomerDto>(customer));
            //Can also just return customer?
        }

        // PUT: api/Customers/5
        [ResponseType(typeof(CustomerDto))] //Responding with DTO instead of customer
        public async Task<IHttpActionResult> PutCustomer(int id, CustomerDto customerDto)
        {

            var customerInDB = db.customers.SingleOrDefault(c => c.Id == id);
            //mapping the customer to the DTO to check changes
            Mapper.Map(customerDto, customerInDB); // no declaration passed. Inferred by argumments 
            db.Entry(customerInDB).State = EntityState.Modified;

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != customerDto.Id) //here be dragons
            {
                return BadRequest();
            }
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

            return Ok(customerDto);
        }

        // POST: api/Customers
        [HttpPost]
        [ResponseType(typeof(CustomerDto))]
        public async Task<IHttpActionResult> CreateCustomer(CustomerDto customerDto)//Can also name PostCustomer and remove annotation
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var customer = Mapper.Map<CustomerDto, Customer>(customerDto); //mapping the CustomerDto to Customer
            db.customers.Add(customer);
            await db.SaveChangesAsync();

            //Not sure if the Id returned should be the Dto or regular Customer
            return CreatedAtRoute("DefaultApi", new { id = customerDto.Id }, customerDto);
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


//https://stackoverflow.com/questions/2433306/whats-the-difference-between-iqueryable-and-ienumerable?rq=1