using System;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {
        private ApplicationDbContext _context;
        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        // GET: Customers
        [Route("Customers/List")]
        public ViewResult CustList()
        {
            return View();
        }

        public ActionResult New()
        {
            var viewModel = new NewCustomerViewModel();
            
            viewModel.MembershipTypes = _context.MembershipTypes.ToList();
            
            return View("CustomerForm",viewModel);
        }

        public ActionResult Update(Customers customer)
        {
            if(ModelState.IsValid == false)
            {
                var viewModel = new NewCustomerViewModel()
                {
                    Customer = customer,
                    MembershipTypes = _context.MembershipTypes
                };
                return View("CustomerForm", viewModel);
            }
            var customerInDB = _context.Customers.Single(c => c.Id == customer.Id);
            customerInDB.Name = customer.Name;
            customerInDB.DateOfBirth = customer.DateOfBirth;
            customerInDB.isSubscribedTNewsLetter = customer.isSubscribedTNewsLetter;


            customerInDB.MembershipType = _context.MembershipTypes.SingleOrDefault(m => m.Id == customer.MembershipType.Id);

            _context.SaveChanges();
            return RedirectToAction("List", "Customers");
        }

        [HttpPost]
        public ActionResult Save(Customers customer)
        {
            
            customer.MembershipType = _context.MembershipTypes.SingleOrDefault(c => c.Id == customer.MembershipType.Id);
            if (customer.MembershipType == null)
                return Content("New customer can not be added as the membership type is not selected.");
            _context.Customers.Add(customer);
            _context.SaveChanges();
        
            return RedirectToAction("List","Customers");
        }
        [Route("Customers/Details/{Id}")]
        public ActionResult Details(int Id)
        {
            var custDetail = _context.Customers.Include(c=>c.MembershipType).SingleOrDefault(c => c.Id == Id);
            if (custDetail.Name == null)
                return HttpNotFound();
            
            return View(custDetail);
        }

        public ActionResult Edit(int Id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == Id);
            if (customer == null)
                return HttpNotFound();

            var viewModel = new NewCustomerViewModel
            {
                Customer = customer,
                MembershipTypes = _context.MembershipTypes.ToList()
            };
            return View("CustomerForm",viewModel);
        }
        private ActionResult Content(Customers detail)
        {
            throw new NotImplementedException();
        }
    }
}