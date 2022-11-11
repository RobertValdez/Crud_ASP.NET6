using IntroASP.Models;
using IntroASP.Models.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace IntroASP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class APITechController : ControllerBase
    {
        private readonly TechAspBDContext _context;

        public APITechController(TechAspBDContext context)
        {
            _context = context;
        }

        public async Task<List<BrandArticleViewModel>> Get()
        => await _context.Articles.Include(b => b.Brand).Select( b => new BrandArticleViewModel
        {
            Name = b.Name,
            Brand = b.Brand.Name
        }).ToListAsync();
    }
}
