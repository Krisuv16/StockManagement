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
    public class NewProductController : Controller
    {
        private readonly ApplicationDbContext _context;

        public NewProductController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: NewProduct
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.ProductModel.Include(p => p.CID);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: NewProduct/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productModel = await _context.ProductModel
                .Include(p => p.CID)
                .FirstOrDefaultAsync(m => m.ProductID == id);
            if (productModel == null)
            {
                return NotFound();
            }

            return View(productModel);
        }
        public async Task<IActionResult> ProductSearch(int id)
        {
            var productModel = await _context.ProductModel
    .Include(p => p.CID)
    .FirstOrDefaultAsync(m => m.ProductID == id);
            if (productModel != null)
            {
                return View("details",productModel); 
            }
            else
            {
                ViewBag.Message = String.Format("Nothing Found");
            }
            var applicationDbContext = _context.ProductModel.Include(p => p.CID);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: NewProduct/Create
        public IActionResult Create()
        {
            ViewData["CategoryID"] = new SelectList(_context.CategoryModel, "CategoryID", "CategoryDescription");
            return View();
        }

        // POST: NewProduct/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProductID,ProductName,ProductType,ProductDescription,ProductManufacturer,CategoryID,salable")] ProductModel productModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(productModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoryID"] = new SelectList(_context.CategoryModel, "CategoryID", "CategoryDescription", productModel.CategoryID);
            return View(productModel);
        }

        // GET: NewProduct/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productModel = await _context.ProductModel.FindAsync(id);
            if (productModel == null)
            {
                return NotFound();
            }
            ViewData["CategoryID"] = new SelectList(_context.CategoryModel, "CategoryID", "CategoryDescription", productModel.CategoryID);
            return View(productModel);
        }

        // POST: NewProduct/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProductID,ProductName,ProductType,ProductDescription,ProductManufacturer,CategoryID,salable")] ProductModel productModel)
        {
            if (id != productModel.ProductID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(productModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductModelExists(productModel.ProductID))
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
            ViewData["CategoryID"] = new SelectList(_context.CategoryModel, "CategoryID", "CategoryDescription", productModel.CategoryID);
            return View(productModel);
        }

        // GET: NewProduct/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productModel = await _context.ProductModel
                .Include(p => p.CID)
                .FirstOrDefaultAsync(m => m.ProductID == id);
            if (productModel == null)
            {
                return NotFound();
            }

            return View(productModel);
        }

        // POST: NewProduct/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var productModel = await _context.ProductModel.FindAsync(id);
            _context.ProductModel.Remove(productModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductModelExists(int id)
        {
            return _context.ProductModel.Any(e => e.ProductID == id);
        }
    }
}
