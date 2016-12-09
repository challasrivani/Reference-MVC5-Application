using System;
using System.ComponentModel.DataAnnotations;

namespace Vidly.Dtos
{
    public class CustomerDto
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public String Name { get; set; }

        [DataType(DataType.Date)]
       // [IsAgeAbove18forMembership]
        public DateTime? DateOfBirth { get; set; }

        public bool isSubscribedTNewsLetter { get; set; }

        public MembershipTypeDto MembershipType { get; set; }

        //public byte MembershipType_Id { get; set; }        

    }
}