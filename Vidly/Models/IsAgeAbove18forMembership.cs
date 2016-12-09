using System;
using System.ComponentModel.DataAnnotations;

namespace Vidly.Models
{
    public class IsAgeAbove18forMembership : ValidationAttribute

    {

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var customer = (Customers)validationContext.ObjectInstance;

            if ((customer.MembershipType.Id == 0) || (customer.MembershipType.Id == 1))
                return ValidationResult.Success;

            if (customer.DateOfBirth == null)
                return new ValidationResult("BirthDate is Required");

            var age = DateTime.Today.Year - customer.DateOfBirth.Value.Year;
            return ((age >= 18) ? ValidationResult.Success : new ValidationResult("Age should be minimum 18 year to have membership"));
        }

    }
}