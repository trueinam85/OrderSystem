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
    public class OrderLinesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public OrderLinesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: OrderLines
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.OrderLines.Include(o => o.Item).Include(o => o.OrdernNumberNavigation);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: OrderLines/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orderLines = await _context.OrderLines
                .Include(o => o.Item)
                .Include(o => o.OrdernNumberNavigation)
                .FirstOrDefaultAsync(m => m.LineNumber == id);
            if (orderLines == null)
            {
                return NotFound();
            }

            return View(orderLines);
        }

        // GET: OrderLines/Create
        public IActionResult Create()
        {
            

            return View();
        }

        // POST: OrderLines/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("LineNumber,OrdernNumber,ItemId,Quantity")] OrderLines orderLines)
        {
            if (ModelState.IsValid)
            {
                _context.Add(orderLines);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ItemId"] = new SelectList(_context.Items, "Id", "Brand", orderLines.ItemId);
            ViewData["OrdernNumber"] = new SelectList(_context.Orders, "Id", "Id", orderLines.OrdernNumber);
            return View(orderLines);
        }

        // GET: OrderLines/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orderLines = await _context.OrderLines.FindAsync(id);
            if (orderLines == null)
            {
                return NotFound();
            }
            ViewData["ItemId"] = new SelectList(_context.Items, "Id", "Brand", orderLines.ItemId);
            ViewData["OrdernNumber"] = new SelectList(_context.Orders, "Id", "Id", orderLines.OrdernNumber);
            return View(orderLines);
        }

        // POST: OrderLines/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("LineNumber,OrdernNumber,ItemId,Quantity")] OrderLines orderLines)
        {
            if (id != orderLines.LineNumber)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(orderLines);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrderLinesExists(orderLines.LineNumber))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["ItemId"] = new SelectList(_context.Items, "Id", "Brand", orderLines.ItemId);
            ViewData["OrdernNumber"] = new SelectList(_context.Orders, "Id", "Id", orderLines.OrdernNumber);
            return View(orderLines);
        }

        // GET: OrderLines/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orderLines = await _context.OrderLines
                .Include(o => o.Item)
                .Include(o => o.OrdernNumberNavigation)
                .FirstOrDefaultAsync(m => m.LineNumber == id);
            if (orderLines == null)
            {
                return NotFound();
            }

            return View(orderLines);
        }

        // POST: OrderLines/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var orderLines = await _context.OrderLines.FindAsync(id);
            _context.OrderLines.Remove(orderLines);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OrderLinesExists(int id)
        {
            return _context.OrderLines.Any(e => e.LineNumber == id);
        }
    }
}
