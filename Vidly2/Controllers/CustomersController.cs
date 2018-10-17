using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly2.Models;
using Vidly2.ViewModels;
using System.Data.Entity;

namespace Vidly2.Controllers
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

        public ActionResult New()
        {            
            var membershipTypes = _context.MembershipTypes.ToList();
            var viewModel = new CustomerFormViewModel
            {
                Customer = new Customer(),
                MembershipTypes = membershipTypes
            };

            return View("CustomerForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Customer customer)
        {
            if(!ModelState.IsValid)
            {
                var viewModel = new CustomerFormViewModel
                {
                    Customer = customer,
                    MembershipTypes = _context.MembershipTypes.ToList()
                };

                return View("CustomerForm", viewModel);
            }

            if (customer.Id == 0)
            {
                _context.Customers.Add(customer);
            }
            else
            {
                var customerIdDb = _context.Customers.Single(c => c.Id == customer.Id);
                customerIdDb.Name = customer.Name;
                customerIdDb.Birthdate = customer.Birthdate;
                customerIdDb.MembershipTypeId = customer.MembershipTypeId;
                customerIdDb.IsSubcribedToNewsLetter = customer.IsSubcribedToNewsLetter;
            }

            _context.SaveChanges();

            return RedirectToAction("Index", "Customers");
        }


        public ActionResult Edit(int? id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);
            if (customer == null)
            {
                return HttpNotFound();
            }

            var viewModel = new CustomerFormViewModel
            {
                Customer = customer,
                MembershipTypes = _context.MembershipTypes.ToList()
            };
            return View("CustomerForm", viewModel);
        }

        // GET: Customers
        public ActionResult Index()
        {
            return RedirectToAction("Customers", "Customers");
        }

        [Route(@"customers/details/{Id:regex(\d{1})}")]
        public ActionResult Details(int? Id)
        {
            return View(GetCustomersViewModel(Id).Customers.FirstOrDefault());
        }

        [Route(@"customers/")]
        public ActionResult Customers()
        {
            //return View(GetCustomersViewModel(null));
            return View();
        }

        [Route(@"customers/{Id:regex(\d{1})}")]
        public ActionResult Customers(int? Id)
        {
            
            return View(GetCustomersViewModel(Id));

        }


        public CustomerViewModel GetCustomersViewModel(int? Id)
        {
            //var customers = new List<Customer>
            //{
            //    new Customer {Id = 1, Name = "Leia"},
            //    new Customer {Id = 2, Name = "Christina"},
            //    new Customer {Id = 3, Name = "Isabelle"}
            //};

            var customers = _context.Customers.Include(c => c.MembershipType).ToList();

            var cvm = new CustomerViewModel();

            if (Id.HasValue && Id.Value > 0)
            {
                cvm.Customers = customers.Where(c => c.Id == Id).ToList();
                if (cvm.Customers != null && cvm.Customers.Count == 1)
                {
                    cvm.IsCustomersFound = false;
                    cvm.IsCustomerListEmpty = false;
                    cvm.IsSingleCustomerFound = true;
                    cvm.IsSingleCustomerNotFound = false;
                }
                else if (cvm.Customers != null && cvm.Customers.Count == 0)
                {
                    cvm.IsCustomersFound = false;
                    cvm.IsCustomerListEmpty = false;
                    cvm.IsSingleCustomerFound = false;
                    cvm.IsSingleCustomerNotFound = true;
                }
            }
            else
            {
                cvm.Customers = customers;

                if (cvm.Customers != null && cvm.Customers.Count == 0)
                {
                    cvm.IsCustomersFound = false;
                    cvm.IsCustomerListEmpty = true;
                    cvm.IsSingleCustomerFound = false;
                    cvm.IsSingleCustomerNotFound = false;
                }
                else
                {
                    cvm.IsCustomersFound = true;
                    cvm.IsCustomerListEmpty = false;
                    cvm.IsSingleCustomerFound = false;
                    cvm.IsSingleCustomerNotFound = false;
                }
            }

            return cvm;
        }
    }
}