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
    public class PurchaseModelsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PurchaseModelsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: PurchaseModels
        public async Task<IActionResult> Index()
        {
            return View(await _context.PurchaseModel.ToListAsync());
        }

        // GET: PurchaseModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var purchaseModel = await _context.PurchaseModel
                .FirstOrDefaultAsync(m => m.PurchaseID == id);
            if (purchaseModel == null)
            {
                return NotFound();
            }

            return View(purchaseModel);
        }

        // GET: PurchaseModels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PurchaseModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PurchaseID,PurchaseDescription,PurchaseDate,VendorName")] PurchaseModel purchaseModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(purchaseModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(purchaseModel);
        }

        // GET: PurchaseModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var purchaseModel = await _context.PurchaseModel.FindAsync(id);
            if (purchaseModel == null)
            {
                return NotFound();
            }
            return View(purchaseModel);
        }

        // POST: PurchaseModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PurchaseID,PurchaseDescription,PurchaseDate,VendorName")] PurchaseModel purchaseModel)
        {
            if (id != purchaseModel.PurchaseID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(purchaseModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PurchaseModelExists(purchaseModel.PurchaseID))
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
            return View(purchaseModel);
        }

        // GET: PurchaseModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var purchaseModel = await _context.PurchaseModel
                .FirstOrDefaultAsync(m => m.PurchaseID == id);
            if (purchaseModel == null)
            {
                return NotFound();
            }

            return View(purchaseModel);
        }

        // POST: PurchaseModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var purchaseModel = await _context.PurchaseModel.FindAsync(id);
            _context.PurchaseModel.Remove(purchaseModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PurchaseModelExists(int id)
        {
            return _context.PurchaseModel.Any(e => e.PurchaseID == id);
        }
    }
}
