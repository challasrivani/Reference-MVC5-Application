using System.Collections.Generic;
using Vidly.Models;

namespace Vidly.ViewModels
{
    public class NewCustomerViewModel
    {
        public Customers Customer { get; set; }
        public IEnumerable<MembershipType> MembershipTypes { get; set; }
    }
}