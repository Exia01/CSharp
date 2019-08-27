using System;
using System.ComponentModel.DataAnnotations;
using Vidly.Models;

namespace Vidly.Dtos
{
    public class CustomerDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter a name")]
        [StringLength(255)]
        public string Name { get; set; }
        
        [Min18ifAMember]
        public DateTime? Birthday { get; set; } //question marks deems it as optional

        public bool IsSubscribedToNewsletter { get; set; }

        //Domain class can be excluded because it is created a dependency from our dto to domain model
        //public MembershipType MembershipType { get; set; 

        [Required(ErrorMessage = "Please select a membership")]
        public byte MembershipTypeId //because it is byte and empty field passes a string throws error
        {
            get; set;
        }

    }
}