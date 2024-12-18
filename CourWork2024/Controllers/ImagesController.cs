using CourWork2024.Data;
using CourWork2024.Models;
using Microsoft.AspNetCore.Mvc;

namespace CourWork2024.Controllers
{
    public class ImagesController : Controller
    {
        private readonly CourWork2024Context _context;

        public ImagesController(CourWork2024Context context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Upload()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Upload(IFormFile file)
        {
            var imagesPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images");
            if (!Directory.Exists(imagesPath))
            {
                Directory.CreateDirectory(imagesPath);
            }
            var picture = new Picture { ImagePath = file.FileName };
            _context.Pictures.Add(picture);
            await _context.SaveChangesAsync();
            var filePath = Path.Combine(imagesPath, Path.GetFileName(file.FileName));
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            return View();
        }
    }
}
