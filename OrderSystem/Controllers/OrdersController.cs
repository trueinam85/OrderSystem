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
            var orderObjects = await _context.Orders.Include(o => o.Customer)
                .Include(i=>i.OrderLines).ToListAsync();
            
            var listOfItemIds = new List<int>();

            foreach (var order in orderObjects)
            {
                for (int i = 0; i < order.OrderLines.Count(); i++)
                {
                    if(!listOfItemIds.Contains(order.OrderLines.ElementAt(i).ItemId))
                    {
                        listOfItemIds.Add(order.OrderLines.ElementAt(i).ItemId);
                    }
                }
            }

            var items = await _context.Items.Where(c => listOfItemIds.Contains(c.Id)).ToListAsync();
            return View( OrderMapper.MappToOrdersVMList(orderObjects, items));
        }


        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orders = await _context.Orders.Where(i=>i.Id== id)
                .Include(o => o.Customer)
                .Include(o => o.OrderLines)
                .ToListAsync();

            if (orders.Count() == 0)
            {
                return NotFound();
            }

            var listOfItemIds = new List<int>();

            foreach (var orderLine in orders.FirstOrDefault().OrderLines)
            {
                for (int i = 0; i < orders.FirstOrDefault().OrderLines.Count(); i++)
                {
                    if (!listOfItemIds.Contains(orders.FirstOrDefault().OrderLines.ElementAt(i).ItemId))
                    {
                        listOfItemIds.Add(orders.FirstOrDefault().OrderLines.ElementAt(i).ItemId);
                    }
                }
            }

            var items = await _context.Items.Where(c => listOfItemIds.Contains(c.Id)).ToListAsync();

            return View(OrderMapper.MappToOrdersVMList(orders, items).FirstOrDefault());
        }
        public async Task<IActionResult> Create()
        {
            var customers = await _context.Customers.ToListAsync();

            List<object> customersList = new List<object>();
            foreach (var customer in customers)
                customersList.Add(new
                {
                    Id = customer.Id,
                    Name = customer.FirstName + ", " + customer.LastName
                });
            var empty = new
            {
                Id = -1,
                Name = "Please select customer"
            };
            customersList.Insert(0, empty);
            ViewData["CustomerId"] = new SelectList(customersList, "Id", "Name");

            return View(new OrderVM());
        }

      
        [HttpPost]
        public async Task<IActionResult> Create([FromForm] OrderVM orders)
        {
            if (ModelState.IsValid)
            {
                //_context.Add(orders);
                //await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            //ViewData["CustomerId"] = new SelectList(_context.Customers, "Id", "FirstName", orders.CustomerId);
            return View(orders);
        }

    }
}
