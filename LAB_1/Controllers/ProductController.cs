using Microsoft.AspNetCore.Mvc;
using WEB.Models;
using WEB.Data;
using LAB_1.Data;
using Microsoft.EntityFrameworkCore;

namespace WEB.Controllers
{
    public class ProductController : Controller
    {
        ApplicationDbContext context;

        private int _pageSize = 3;

        public ProductController(ApplicationDbContext dbContext) => context = dbContext; 

        [Route("Catalog")]
        [Route("Catalog/Page_{pageNo}")]
        public async Task<IActionResult> Index(int? section, int pageNo = 1)
        {
            var goodsFiltered = context.Goods.Where(g => !section.HasValue || g.SectionId == section.Value);
            // Поместить список групп во ViewData
            ViewData["Groups"] = await context.Sections.ToListAsync();
            // Получить id текущей группы и поместить в TempData
            ViewData["CurrentGroup"] = section ?? 0;
            return View(ListViewModel<Good>
            .GetModel(goodsFiltered, pageNo, _pageSize));
        }  
        
    }
}
