using CourWork2024.Data;
using CourWork2024.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CourWork2024.Controllers
{
    public class CarsController : Controller
    {
        private readonly CourWork2024Context _context;

        public CarsController(CourWork2024Context context)
        {
            _context = context;
        }

        // GET: Cars
        public async Task<IActionResult> Index()
        {
            var courWork2024Context = _context.Cars
                .Include(c => c.Body)
                .Include(c => c.Color)
                .Include(c => c.GearBox)
                .Include(c => c.Model).
                Include(c => c.Picture).ToListAsync();
            return View(await courWork2024Context);
        }

        // GET: Cars/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var car = await _context.Cars
                .Include(c => c.Body)
                .Include(c => c.Color)
                .Include(c => c.GearBox)
                .Include(c => c.Model)
                .Include(c => c.Picture)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (car == null)
            {
                return NotFound();
            }

            return View(car);
        }

        // GET: Cars/Create
        public async Task<IActionResult> Create()
        {
            ViewData["ColorId"] = await _context.Colors.ToListAsync();
            ViewData["GearBoxId"] = await _context.GearBoxes.ToListAsync();
            ViewData["ModelId"] = await _context.Models.Include(m => m.Brand).ToListAsync();
            ViewData["PictureName"] = await _context.Pictures.ToListAsync();
            ViewData["BodyId"] = await _context.BodyTs.ToListAsync();

            return View();
        }

        // POST: Cars/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,ModelId,ColorId,BodyId,mileage,FabDate,Cost,PictureId,GearBoxId")] Car car,IFormFile fille)
        {

            try
            {
                _context.Add(car);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                ViewData["ColorId"] = await _context.Colors.ToListAsync();
                ViewData["GearBoxId"] = await _context.GearBoxes.ToListAsync();
                ViewData["ModelId"] = await _context.Models.ToListAsync();
                ViewData["PictureName"] = await _context.Pictures.ToListAsync();
                ViewData["BodyId"] = await _context.BodyTs.ToListAsync();
                return View(car);
            }
        }

        // GET: Cars/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var car = await _context.Cars.FindAsync(id);
            if (car == null)
            {
                return NotFound();
            }
            ViewData["ColorId"] = await _context.Colors.ToListAsync();
            ViewData["GearBoxId"] = await _context.GearBoxes.ToListAsync();
            ViewData["ModelId"] = await _context.Models.ToListAsync();
            ViewData["PictureName"] = await _context.Pictures.ToListAsync();
            ViewData["BodyId"] = await _context.BodyTs.ToListAsync();
            return View(car);
        }

        // POST: Cars/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,ModelId,ColorId,BodyId,mileage,FabDate,Cost,PictureId,GearBoxId")] Car car)
        {
            if (id != car.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(car);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CarExists(car.Id))
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
            ViewData["ColorId"] = await _context.Colors.ToListAsync();
            ViewData["GearBoxId"] = await _context.GearBoxes.ToListAsync();
            ViewData["ModelId"] = await _context.Models.ToListAsync();
            ViewData["PictureName"] = await _context.Pictures.ToListAsync();
            ViewData["BodyId"] = await _context.BodyTs.ToListAsync();
            return View(car);
        }

        // GET: Cars/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var car = await _context.Cars
                .Include(c => c.Body)
                .Include(c => c.Color)
                .Include(c => c.GearBox)
                .Include(c => c.Model)
                .Include(c => c.Model.Brand)
                .Include(c => c.Picture)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (car == null)
            {
                return NotFound();
            }

            return View(car);
        }

        // POST: Cars/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var car = await _context.Cars.FindAsync(id);
            if (car != null)
            {
                _context.Cars.Remove(car);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CarExists(int id)
        {
            return _context.Cars.Any(e => e.Id == id);
        }
    }
}
