using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OrderSystem.Data;

namespace OrderSystem.Controllers
{
    public class OrdersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public OrdersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Orders
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Orders.Include(o => o.Customer);
            return View(await applicationDbContext.ToListAsync());
        }

     
        public IActionResult Create()
        {
            ViewData["CustomerId"] = new SelectList(_context.Customers, "Id", "FirstName");
            return View();
        }

      
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CustomerId,OrderDate")] Orders orders)
        {
            if (ModelState.IsValid)
            {
                _context.Add(orders);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CustomerId"] = new SelectList(_context.Customers, "Id", "FirstName", orders.CustomerId);
            return View(orders);
        }

    }
}
