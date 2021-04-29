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
    public class PurchaseDetailsModelsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PurchaseDetailsModelsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: PurchaseDetailsModels
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.PurchaseDetailsModel.Include(p => p.PDID).Include(p => p.PID);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: PurchaseDetailsModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var purchaseDetailsModel = await _context.PurchaseDetailsModel
                .Include(p => p.PDID)
                .Include(p => p.PID)
                .FirstOrDefaultAsync(m => m.PurchaseDetailID == id);
            if (purchaseDetailsModel == null)
            {
                return NotFound();
            }

            return View(purchaseDetailsModel);
        }

        // GET: PurchaseDetailsModels/Create
        public IActionResult Create()
        {
            ViewData["PurchaseID"] = new SelectList(_context.PurchaseModel, "PurchaseID", "PurchaseDescription");
            ViewData["ProductID"] = new SelectList(_context.ProductModel, "ProductID", "ProductDescription");
            return View();
        }

        // POST: PurchaseDetailsModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PurchaseDetailID,ProductID,PurchaseID,PurchaseQuantity,PurchasePrice")] PurchaseDetailsModel purchaseDetailsModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(purchaseDetailsModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PurchaseID"] = new SelectList(_context.PurchaseModel, "PurchaseID", "PurchaseDescription", purchaseDetailsModel.PurchaseID);
            ViewData["ProductID"] = new SelectList(_context.ProductModel, "ProductID", "ProductDescription", purchaseDetailsModel.ProductID);
            return View(purchaseDetailsModel);
        }

        // GET: PurchaseDetailsModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var purchaseDetailsModel = await _context.PurchaseDetailsModel.FindAsync(id);
            if (purchaseDetailsModel == null)
            {
                return NotFound();
            }
            ViewData["PurchaseID"] = new SelectList(_context.PurchaseModel, "PurchaseID", "PurchaseDescription", purchaseDetailsModel.PurchaseID);
            ViewData["ProductID"] = new SelectList(_context.ProductModel, "ProductID", "ProductDescription", purchaseDetailsModel.ProductID);
            return View(purchaseDetailsModel);
        }

        // POST: PurchaseDetailsModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PurchaseDetailID,ProductID,PurchaseID,PurchaseQuantity,PurchasePrice")] PurchaseDetailsModel purchaseDetailsModel)
        {
            if (id != purchaseDetailsModel.PurchaseDetailID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(purchaseDetailsModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PurchaseDetailsModelExists(purchaseDetailsModel.PurchaseDetailID))
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
            ViewData["PurchaseID"] = new SelectList(_context.PurchaseModel, "PurchaseID", "PurchaseDescription", purchaseDetailsModel.PurchaseID);
            ViewData["ProductID"] = new SelectList(_context.ProductModel, "ProductID", "ProductDescription", purchaseDetailsModel.ProductID);
            return View(purchaseDetailsModel);
        }

        // GET: PurchaseDetailsModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var purchaseDetailsModel = await _context.PurchaseDetailsModel
                .Include(p => p.PDID)
                .Include(p => p.PID)
                .FirstOrDefaultAsync(m => m.PurchaseDetailID == id);
            if (purchaseDetailsModel == null)
            {
                return NotFound();
            }

            return View(purchaseDetailsModel);
        }

        // POST: PurchaseDetailsModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var purchaseDetailsModel = await _context.PurchaseDetailsModel.FindAsync(id);
            _context.PurchaseDetailsModel.Remove(purchaseDetailsModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PurchaseDetailsModelExists(int id)
        {
            return _context.PurchaseDetailsModel.Any(e => e.PurchaseDetailID == id);
        }
    }
}
