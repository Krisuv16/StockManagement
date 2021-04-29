using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using StockManagement.Data;
using StockManagement.Models;

namespace StockManagement.Controllers
{
    public class StockModelsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public StockModelsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: StockModels
        public async Task<IActionResult> Index()
        {
            return View(await _context.StockModel.ToListAsync());
        }

        // GET: StockModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var stockModel = await _context.StockModel
                .FirstOrDefaultAsync(m => m.StockModelID == id);
            if (stockModel == null)
            {
                return NotFound();
            }

            return View(stockModel);
        }

        // GET: StockModels/Create
        public IActionResult Create()
        {
            ViewData["ProductID"] = new SelectList(_context.ProductModel, "ProductID", "ProductName");
            return View();
        }

        // POST: StockModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SalesModedID,Quantity,ProductID")] StockModel stockModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(stockModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ProductID"] = new SelectList(_context.ProductModel, "ProductID", "ProductName", stockModel.ProductID);
            return View(stockModel);
        }

        // GET: StockModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var stockModel = await _context.StockModel.FindAsync(id);
            if (stockModel == null)
            {
                return NotFound();
            }
            ViewData["ProductID"] = new SelectList(_context.ProductModel, "ProductID", "ProductName", stockModel.ProductID);
            return View(stockModel);
        }

        // POST: StockModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SalesModedID,Quantity,ProductID")] StockModel stockModel)
        {
            if (id != stockModel.StockModelID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(stockModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StockModelExists(stockModel.StockModelID))
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
            ViewData["ProductID"] = new SelectList(_context.ProductModel, "ProductID", "ProductName", stockModel.ProductID);
            return View(stockModel);
        }

        // GET: StockModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var stockModel = await _context.StockModel
                .FirstOrDefaultAsync(m => m.StockModelID == id);
            if (stockModel == null)
            {
                return NotFound();
            }

            return View(stockModel);
        }

        // POST: StockModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var stockModel = await _context.StockModel.FindAsync(id);
            _context.StockModel.Remove(stockModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StockModelExists(int id)
        {
            return _context.StockModel.Any(e => e.StockModelID == id);
        }
    }
}
