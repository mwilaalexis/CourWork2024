using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CourWork2024.Data;
using CourWork2024.Models;

namespace CourWork2024.Controllers
{
    public class GearBoxesController : Controller
    {
        private readonly CourWork2024Context _context;

        public GearBoxesController(CourWork2024Context context)
        {
            _context = context;
        }

        // GET: GearBoxes
        public async Task<IActionResult> Index()
        {
            return View(await _context.GearBoxes.ToListAsync());
        }

        // GET: GearBoxes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gearBox = await _context.GearBoxes
                .FirstOrDefaultAsync(m => m.ID == id);
            if (gearBox == null)
            {
                return NotFound();
            }

            return View(gearBox);
        }

        // GET: GearBoxes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: GearBoxes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Name")] GearBox gearBox)
        {
            if (ModelState.IsValid)
            {
                _context.Add(gearBox);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(gearBox);
        }

        // GET: GearBoxes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gearBox = await _context.GearBoxes.FindAsync(id);
            if (gearBox == null)
            {
                return NotFound();
            }
            return View(gearBox);
        }

        // POST: GearBoxes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Name")] GearBox gearBox)
        {
            if (id != gearBox.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(gearBox);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GearBoxExists(gearBox.ID))
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
            return View(gearBox);
        }

        // GET: GearBoxes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gearBox = await _context.GearBoxes
                .FirstOrDefaultAsync(m => m.ID == id);
            if (gearBox == null)
            {
                return NotFound();
            }

            return View(gearBox);
        }

        // POST: GearBoxes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var gearBox = await _context.GearBoxes.FindAsync(id);
            if (gearBox != null)
            {
                _context.GearBoxes.Remove(gearBox);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GearBoxExists(int id)
        {
            return _context.GearBoxes.Any(e => e.ID == id);
        }
    }
}
