﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {
        // GET: Customers
        private ApplicationDbContext _context;

        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }


        //New Customer
        public ActionResult New()
        {
            var membershipTypes = _context.MembershipTypes.ToList();

            var viewModel = new CustomerFormViewModel
            {
                Customer = new CustomerModel(),
                MembershipType = membershipTypes
            };

            return View("CustomerForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(CustomerModel customer)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new CustomerFormViewModel
                {
                    Customer = customer,
                    MembershipType = _context.MembershipTypes.ToList()
                };

                return View("CustomerForm", viewModel);
            }

            if (customer.ID == 0)
            {
                _context.Customers.Add(customer);
            } else
            {
                var customerInDb = _context.Customers.Single(c => c.ID == customer.ID);
                customerInDb.Name = customer.Name;
                customerInDb.DoB = customer.DoB;
                customerInDb.MembershipTypeId = customer.MembershipTypeId;
                customerInDb.IsSubbedNewsletter = customer.IsSubbedNewsletter;
                
            }
            
            _context.SaveChanges();

            return RedirectToAction("Index", "Customers");
        }

        // Edit Customer
        public ActionResult Edit(int ID)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.ID == ID);
            if (customer == null)
                return HttpNotFound();

            var viewModel = new CustomerFormViewModel
            {
                Customer = customer,
                MembershipType = _context.MembershipTypes.ToList()
            };

            return View("CustomerForm", viewModel);
        }

        public ActionResult Index()
        {
            var customers = _context.Customers.Include(c => c.MembershipType).ToList();
            return View(customers);

        }

        public new ActionResult Profile(int ID)
        {
            var customer = _context.Customers.Include(c => c.MembershipType).SingleOrDefault(c => c.ID == ID);
            if (customer == null)
                return HttpNotFound();

            return View(customer);
            
        }
    }
}