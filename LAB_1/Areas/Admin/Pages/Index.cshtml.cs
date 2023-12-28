using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using LAB_1.Data;
using WEB.Models;

namespace WEB.Areas.Admin.Pages
{
    public class IndexModel : PageModel
    {
        private readonly LAB_1.Data.ApplicationDbContext _context;

        public IndexModel(LAB_1.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Good> Good { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Goods != null)
            {
                Good = await _context.Goods
                .Include(g => g.Section).ToListAsync();
            }
        }
    }
}
