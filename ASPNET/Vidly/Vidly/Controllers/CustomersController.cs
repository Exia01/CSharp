using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using Vidly.Models;

namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {
        // db context declaration
        private ApplicationDbContext _context;
        
        //initializing in constructor
        public CustomersController()
        {
            _context = new ApplicationDbContext(); //disposable obj
        }
        //helps dispose of the connection??
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ActionResult New()
        {
            return View();
        }
        // GET: Customers
        public ActionResult Index()
        {
            ViewBag.Message = "Customer List";
            //including model membership type related to the customers
            var customers = _context.customers.Include(c => c.MembershipType); //this is not querying the db --> deferred execution
            // we can also query db by calling the _context.customers.ToList();
            //query will take place when we iterate over the customer obj 
            return View(customers);
        }


        [Route("Customers/Details/{id}")]
        public ActionResult Details(int id)
        {
            ViewBag.Message = "Customer Detail";
            var customer = _context.customers;
            //because of the SingleOrDefault extension method, this will query the db 
            var foundCustomer = customer.SingleOrDefault(c => c.Id == id);
            if (foundCustomer != null)
            {
                return View(foundCustomer);

            }
            else
            {
                return HttpNotFound();
            }

        }
        // Using as mock DB
        //    private IEnumerable<Customer> GetCustomers()
        //    {
        //        return new List<Customer> {
        //            new Customer {Id=1, Name = "Yoshi"},
        //            new Customer {Id=2,Name = "Ruy"},
        //            new Customer {Id=3,Name = "Mario"},
        //            new Customer {Id=4,Name = "Sonic"},
        //        };
        //    }
    }
}