using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vidly.Models;

namespace Vidly.ViewModels
{
    //This ViewModel encapsulates all the models required by a view
    public class CustomerFormViewModel
    {   // since no functionality is needed from list IEnumerable enables looping
        public IEnumerable<MembershipType> MemberhipTypes { get; set; }
        public Customer Customer { get; set; }
        //public MembershipType MembershipType { get; set; } // //Don't think this is needed. Not sure how it ended here. 
    }
}