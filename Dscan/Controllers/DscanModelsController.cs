using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Dscan;
using Dscan.Models;

namespace Dscan.Controllers
{
    public class DscanModelsController : Controller
    {
        private readonly DscanContext _context;

        public DscanModelsController(DscanContext context)
        {
            _context = context;
        }

        // GET: DscanModels
        public async Task<IActionResult> Index()
        {
	        List<DscanModel> dscanModels = await _context.DscanModel.ToListAsync();
	        return View(dscanModels);
        }

        // GET: DscanModels/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dscanModel = await _context.DscanModel
                .FirstOrDefaultAsync(m => m.ID == id);
            if (dscanModel == null)
            {
                return NotFound();
            }

            return View(dscanModel);
        }

        // GET: DscanModels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: DscanModels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Paste")] DscanModel dscanModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dscanModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(dscanModel);
        }

        // GET: DscanModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dscanModel = await _context.DscanModel.FindAsync(id);
            if (dscanModel == null)
            {
                return NotFound();
            }
            return View(dscanModel);
        }

        // POST: DscanModels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("ID,Paste")] DscanModel dscanModel)
        {
            if (id != dscanModel.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dscanModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DscanModelExists(dscanModel.ID))
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
            return View(dscanModel);
        }

        // GET: DscanModels/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dscanModel = await _context.DscanModel
                .FirstOrDefaultAsync(m => m.ID == id);
            if (dscanModel == null)
            {
                return NotFound();
            }

            return View(dscanModel);
        }

        // POST: DscanModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var dscanModel = await _context.DscanModel.FindAsync(id);
            _context.DscanModel.Remove(dscanModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DscanModelExists(Guid id)
        {
            return _context.DscanModel.Any(e => e.ID == id);
        }
    }
}
