using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {


        // GET: Customers
        public ActionResult Index()
        {
            ViewBag.Message = "Customer List";
            var customers = GetCustomers();

            return View(customers);
        }

        [Route("Customers/Details/{id}")]
        public ActionResult Details(int id)
        {
            ViewBag.Message = "Customer Detail";
            var customer = GetCustomers();

            var foundCustomer = customer.FirstOrDefault(c => c.Id == id);
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
        private IEnumerable<Customer> GetCustomers()
        {
            return new List<Customer> {
                new Customer {Id=1, Name = "Yoshi"},
                new Customer {Id=2,Name = "Ruy"},
                new Customer {Id=3,Name = "Mario"},
                new Customer {Id=4,Name = "Sonic"},
            };
        }
    }
}