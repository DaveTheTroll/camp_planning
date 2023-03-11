using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CampPlanningWeb.Data;
using CampPlanningWeb.Models;

namespace CampPlanningWeb.Controllers
{
    public class TentTypesController : Controller
    {
        private readonly CampPlanningContext _context;

        public TentTypesController(CampPlanningContext context)
        {
            _context = context;
        }

        // GET: TentTypes
        public async Task<IActionResult> Index()
        {
              return View(await _context.TentType.ToListAsync());
        }

        // GET: TentTypes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.TentType == null)
            {
                return NotFound();
            }

            var tentType = await _context.TentType
                .FirstOrDefaultAsync(m => m.TentTypeID == id);
            if (tentType == null)
            {
                return NotFound();
            }

            return View(tentType);
        }

        // GET: TentTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TentTypes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TentTypeID,Description,PlanImage,Width,Height")] TentType tentType)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tentType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tentType);
        }

        // GET: TentTypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.TentType == null)
            {
                return NotFound();
            }

            var tentType = await _context.TentType.FindAsync(id);
            if (tentType == null)
            {
                return NotFound();
            }
            return View(tentType);
        }

        // POST: TentTypes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TentTypeID,Description,PlanImage,Width,Height")] TentType tentType)
        {
            if (id != tentType.TentTypeID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tentType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TentTypeExists(tentType.TentTypeID))
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
            return View(tentType);
        }

        // GET: TentTypes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.TentType == null)
            {
                return NotFound();
            }

            var tentType = await _context.TentType
                .FirstOrDefaultAsync(m => m.TentTypeID == id);
            if (tentType == null)
            {
                return NotFound();
            }

            return View(tentType);
        }

        // POST: TentTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.TentType == null)
            {
                return Problem("Entity set 'CampPlanningContext.TentType'  is null.");
            }
            var tentType = await _context.TentType.FindAsync(id);
            if (tentType != null)
            {
                _context.TentType.Remove(tentType);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TentTypeExists(int id)
        {
          return _context.TentType.Any(e => e.TentTypeID == id);
        }
    }
}
