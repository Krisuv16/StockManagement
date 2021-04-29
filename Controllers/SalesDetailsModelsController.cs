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
    public class SalesDetailsModelsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SalesDetailsModelsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: SalesDetailsModels
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.SalesDetailsModel.Include(s => s.CID).Include(s => s.PID).Include(s => s.SID);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: SalesDetailsModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var salesDetailsModel = await _context.SalesDetailsModel
                .Include(s => s.CID)
                .Include(s => s.PID)
                .Include(s => s.SID)
                .FirstOrDefaultAsync(m => m.SalesDetailsID == id);
            if (salesDetailsModel == null)
            {
                return NotFound();
            }

            return View(salesDetailsModel);
        }

        // GET: SalesDetailsModels/Create
        public IActionResult Create()
        {
            ViewData["CustomerID"] = new SelectList(_context.CustomerModel, "CustomerID", "CustomerAddress");
            ViewData["PurchaseID"] = new SelectList(_context.PurchaseModel, "PurchaseID", "PurchaseDescription");
            ViewData["SalesID"] = new SelectList(_context.SalesModel, "SalesModedID", "SalesModedID");
            return View();
        }

        // POST: SalesDetailsModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SalesDetailsID,Price,Quantity,Manufacturedate,Expirydate,SalesID,PurchaseID,CustomerID")] SalesDetailsModel salesDetailsModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(salesDetailsModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CustomerID"] = new SelectList(_context.CustomerModel, "CustomerID", "CustomerAddress", salesDetailsModel.CustomerID);
            ViewData["PurchaseID"] = new SelectList(_context.PurchaseModel, "PurchaseID", "PurchaseDescription", salesDetailsModel.PurchaseID);
            ViewData["SalesID"] = new SelectList(_context.SalesModel, "SalesModedID", "SalesModedID", salesDetailsModel.SalesID);
            return View(salesDetailsModel);
        }

        // GET: SalesDetailsModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var salesDetailsModel = await _context.SalesDetailsModel.FindAsync(id);
            if (salesDetailsModel == null)
            {
                return NotFound();
            }
            ViewData["CustomerID"] = new SelectList(_context.CustomerModel, "CustomerID", "CustomerAddress", salesDetailsModel.CustomerID);
            ViewData["PurchaseID"] = new SelectList(_context.PurchaseModel, "PurchaseID", "PurchaseDescription", salesDetailsModel.PurchaseID);
            ViewData["SalesID"] = new SelectList(_context.SalesModel, "SalesModedID", "SalesModedID", salesDetailsModel.SalesID);
            return View(salesDetailsModel);
        }

        // POST: SalesDetailsModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SalesDetailsID,Price,Quantity,Manufacturedate,Expirydate,SalesID,PurchaseID,CustomerID")] SalesDetailsModel salesDetailsModel)
        {
            if (id != salesDetailsModel.SalesDetailsID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(salesDetailsModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SalesDetailsModelExists(salesDetailsModel.SalesDetailsID))
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
            ViewData["CustomerID"] = new SelectList(_context.CustomerModel, "CustomerID", "CustomerAddress", salesDetailsModel.CustomerID);
            ViewData["PurchaseID"] = new SelectList(_context.PurchaseModel, "PurchaseID", "PurchaseDescription", salesDetailsModel.PurchaseID);
            ViewData["SalesID"] = new SelectList(_context.SalesModel, "SalesModedID", "SalesModedID", salesDetailsModel.SalesID);
            return View(salesDetailsModel);
        }

        // GET: SalesDetailsModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var salesDetailsModel = await _context.SalesDetailsModel
                .Include(s => s.CID)
                .Include(s => s.PID)
                .Include(s => s.SID)
                .FirstOrDefaultAsync(m => m.SalesDetailsID == id);
            if (salesDetailsModel == null)
            {
                return NotFound();
            }

            return View(salesDetailsModel);
        }

        // POST: SalesDetailsModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var salesDetailsModel = await _context.SalesDetailsModel.FindAsync(id);
            _context.SalesDetailsModel.Remove(salesDetailsModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SalesDetailsModelExists(int id)
        {
            return _context.SalesDetailsModel.Any(e => e.SalesDetailsID == id);
        }
    }
}
