using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class Min18ifAMember : ValidationAttribute //deriving class from validation attributes
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            //gives us access to the containing class --> in this case Customer
            var customer = (Customer)validationContext.ObjectInstance; //because it is obj, cast to cstmr
            if (customer.MembershipTypeId == MembershipType.Unknown ||
                customer.MembershipTypeId == MembershipType.PayAsYouGo)
            {  //if pay as you go  or if no membership selected. 
                return ValidationResult.Success; //static field on this class
            }
            if (customer.Birthday == null)
            {
                return new ValidationResult("Birthday is required.");
            }

            var age = DateTime.Today.Year - customer.Birthday.Value.Year;
            if (customer.Birthday == null)
            {
                return new ValidationResult("Birthday is required.");
            }

            return (age >= 18)
                ? ValidationResult.Success
                : new ValidationResult("Customer should be at least 18 years old to register with membership.");
        }
    }
}