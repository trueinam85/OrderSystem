﻿using System;
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
        public async Task<IActionResult> Create([FromBody] CustomerVM customer)
        {
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
