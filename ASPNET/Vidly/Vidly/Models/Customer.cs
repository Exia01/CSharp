using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations; // data annotations to override methods

namespace Vidly.Models
{
    public class Customer {
    
        public int Id { get; set; }
        //string type is nullable and there is not limit in characters numbers
        [Required(ErrorMessage ="Please enter a name")]
        [StringLength(255)]
    
        public string Name { get; set; }

        ///[Display(Name = "Date of Birth")]  // //Data annotation -> have to recompile to show difference
        
        [Min18ifAMember]
        public DateTime? Birthday { get; set; } //question marks deems it as optional

        public bool IsSubscribedToNewsletter { get; set; }
        // navigation property --> allows navigation from customer to membership type
        //[DefaultValue(null)]
        public MembershipType MembershipType { get; set; }


        // we can look up as foreign key
        [Display(Name ="Membership Type")]
        //no validation
        [Required(ErrorMessage = "Please select a membership")]
        public byte MembershipTypeId //because it is byte and empty field passes a string throws error
        {
            get; set;
        }

    }


}