using CourWork2024.Data;
using CourWork2024.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CourWork2024.Controllers
{
    public class BodyTsController : Controller
    {
        private readonly CourWork2024Context _context;

        public BodyTsController(CourWork2024Context context)
        {
            _context = context;
        }

        // GET: BodyTs
        public async Task<IActionResult> Index()
        {
            return View(await _context.BodyTs.ToListAsync());
        }

        // GET: BodyTs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bodyT = await _context.BodyTs
                .FirstOrDefaultAsync(m => m.Id == id);
            if (bodyT == null)
            {
                return NotFound();
            }

            return View(bodyT);
        }

        // GET: BodyTs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: BodyTs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] BodyT bodyT)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bodyT);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(bodyT);
        }

        // GET: BodyTs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bodyT = await _context.BodyTs.FindAsync(id);
            if (bodyT == null)
            {
                return NotFound();
            }
            return View(bodyT);
        }

        // POST: BodyTs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] BodyT bodyT)
        {
            if (id != bodyT.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bodyT);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BodyTExists(bodyT.Id))
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
            return View(bodyT);
        }

        // GET: BodyTs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bodyT = await _context.BodyTs
                .FirstOrDefaultAsync(m => m.Id == id);
            if (bodyT == null)
            {
                return NotFound();
            }

            return View(bodyT);
        }

        // POST: BodyTs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var bodyT = await _context.BodyTs.FindAsync(id);
            if (bodyT != null)
            {
                _context.BodyTs.Remove(bodyT);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BodyTExists(int id)
        {
            return _context.BodyTs.Any(e => e.Id == id);
        }
    }
}
