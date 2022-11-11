using IntroASP.Models;
using IntroASP.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace IntroASP.Controllers
{
    public class ArticleController : Controller
    {
        private readonly TechAspBDContext _context;

        public ArticleController(TechAspBDContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var articles = _context.Articles.Include(b => b.Brand);
            return View(await articles.ToListAsync());
        }

        public IActionResult Create()
        {
            ViewData["Brands"] = new SelectList(GetBrands(), "id", "Name");
            return View();
        }

        public class Brands
        {
            public int id { get; set; }
            public string Name { get; set; }
        }

        private List<Brands> GetBrands()
        {
            var brands = _context.Brands;
            var bs = new List<Brands>();

            foreach (var item in brands)
            {
                bs.Add(new Brands() { id = item.Id, Name = item.Name });
            }
            return bs;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ArticleViewModel model)
        {
            if (ModelState.IsValid)
            {
                var Article = new Article()
                {
                    Name = model.Name,
                    BrandId = model.idBrand
                };
                _context.Add(Article);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewData["Brands"] = new SelectList(GetBrands(), "id", "Name", model.idBrand);
            return View(model);
        }
    }
}
