using System;
using System.ComponentModel.DataAnnotations;

namespace Vidly.Models
{
    public class Customers
    {
        
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public String Name { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd MMM yyyy}")]
        [IsAgeAbove18forMembership]
        public DateTime? DateOfBirth { get; set; }

        public bool isSubscribedTNewsLetter { get; set; }
        public MembershipType MembershipType { get; set; }
       // public byte MembershipType_Id { get; set; }



    }
}