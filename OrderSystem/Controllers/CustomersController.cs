using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ModelsPackage;
using OrderSystem.Data;
using OrderSystem.Helpers.VMMappers;

namespace OrderSystem.Controllers
{
    public class CustomersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CustomersController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View( CustomerMapper.MappToCustomerVMList( await _context.Customers.ToListAsync()));
        }

        
        public IActionResult Create()
        {
            return View();
        }

      
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([FromForm] CustomerVM customer)
        {
            if(customer.FirstName==null || customer.FirstName.Trim().Length<3 || customer.FirstName.Length>45)
            {
                ModelState.AddModelError("FirstName", "First name should be between 3 and 45 characters long");
            }
            if (customer.LastName == null || customer.LastName.Trim().Length < 3 || customer.LastName.Length > 45)
            {
                ModelState.AddModelError("LastName", "Last name should be between 3 and 45 characters long");
            }
            if (ModelState.IsValid)
            {
                _context.Add(CustomerMapper.MappToCumster(customer));
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(customer);
        }
       
    }
}
