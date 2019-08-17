using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsSubscribedToNewsletter { get; set; }
        // navigation property --> allows navigation from customer to membership type
        public MembershipType MembershipType { get; set; }
        // we can look up as foreign key
        public byte MembershipTypeId { get; set; }
        public List<Customer> GetCustomers()
        {
            List<Customer> teachers = new List<Customer>();
            teachers.Add(new Customer { Id = 1, Name = "Yoshi" });
            teachers.Add(new Customer { Id = 2, Name = "Ruy" });
            teachers.Add(new Customer { Id = 3, Name = "Mario" });
            teachers.Add(new Customer { Id = 4, Name = "Sonic" });
            return teachers;
        }
        public String GetName()
        {
            return Name;
        }
    }

  
}