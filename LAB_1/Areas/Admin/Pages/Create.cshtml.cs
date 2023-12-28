using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using LAB_1.Data;
using WEB.Models;

namespace WEB.Areas.Admin.Pages
{
    public class CreateModel : PageModel
    {
        private readonly LAB_1.Data.ApplicationDbContext _context;
        private readonly IWebHostEnvironment _environment;

        public CreateModel(LAB_1.Data.ApplicationDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _environment = env;
        }

        public IActionResult OnGet()
        {
        ViewData["SectionId"] = new SelectList(_context.Sections, "Id", "Name");
            return Page();
        }

        [BindProperty]
        public Good Good { get; set; } = default!;
        [BindProperty]
        public IFormFile Image { get; set; }


        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {           
            if (Image != null)
            {
                var fileName = $"{Good.Id}" + Path.GetExtension(Image.FileName);
                Good.Image = fileName;
                var path = Path.Combine(_environment.WebRootPath, "Images", fileName);
                using (var fStream = new FileStream(path, FileMode.Create))
                {
                    await Image.CopyToAsync(fStream);
                }                
            }
            await _context.Goods.AddAsync(Good);
            await _context.SaveChangesAsync();

            if (!ModelState.IsValid || _context.Goods == null || Good == null)
            {
                return Page();
            }

            return RedirectToPage("./Index");
        }
    }
}
