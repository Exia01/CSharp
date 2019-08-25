using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

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


        public ActionResult New()
        {

            var membershipTypes = _context.membershipTypes.ToList();
            ViewBag.Action = "Create";

            //below we initialize a new view model which enables us to combine the models
            var viewModel = new CustomerFormViewModel
            {
                Customer = new Customer(), //this will initialize the customers properties
                MemberhipTypes = membershipTypes,
            };
            return View("CustomerForm",viewModel); //Overriding the "New" view
        }

        [HttpPost] //annotation --> can only be called only using POST method
        public ActionResult Save(CustomerFormViewModel viewModel) //model binding --> mvc framework will automatically bind the model to the req data
        {
            if (!ModelState.IsValid)//checking if the property of the model passed are valid
            {
                //if not valid
                var pendingUserModel = new CustomerFormViewModel
                {
                    Customer = viewModel.Customer, //using the values passed 
                    MemberhipTypes = _context.membershipTypes.ToList()
                };
                return View("CustomerForm", pendingUserModel);
            }
            if(viewModel.Customer.Id == 0)
            {

            _context.customers.Add(viewModel.Customer); //can also just pass customer as the parameter
            //line above is still just in memory -> we save with changes
            _context.SaveChanges();
                // action/controller
            }
            else
            {
                var cstmr = viewModel.Customer;
                var customerInDb = _context.customers.Single(c => c.Id == cstmr.Id);
                //Two ways of doing it
                //TryUpdateModel(customerInDb, "", new string[]{"Name","Email"});
                //can also use auto mapper, convention name tool
                customerInDb.Name = cstmr.Name;
                customerInDb.Birthday = cstmr.Birthday;
                customerInDb.MembershipTypeId = cstmr.MembershipTypeId;
                customerInDb.IsSubscribedToNewsletter = cstmr.IsSubscribedToNewsletter;
            }
            _context.SaveChanges();
            return RedirectToAction("Index", "Customers");
        }

        [Route("Customers/Movie/{id}")]
        public ActionResult Details(int id)
        {
            ViewBag.Message = "Customer Detail";
            //because of the SingleOrDefault extension method, this will query the db 
            var foundCustomer = _context.customers.Include(c => c.MembershipType).SingleOrDefault(c => c.Id == id);
            if (foundCustomer != null)
            {
                return View(foundCustomer);

            }
            else
            {
                return HttpNotFound();
            }

        }

        public ActionResult Edit(int id)
        {
            ViewBag.Action = "Customer";
            var customer = _context.customers.SingleOrDefault(c => c.Id == id);
            if (customer == null)
            {
                return HttpNotFound();

            }
            else
            {
                var viewmodel = new CustomerFormViewModel
                {
                    Customer = customer,
                    MemberhipTypes = _context.membershipTypes.ToList(),

                };
                //overriding view so that we are using the "CustomerForm" Template and creating a view model to combine properties
                return View("CustomerForm", viewmodel);
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