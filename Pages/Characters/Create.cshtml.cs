using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApp.Data;
using WebApp.Models;

namespace WebApp.Pages.Characters
{
    public class CreateModel : PageModel
    {
        private readonly WebApp.Data.WebAppContext _context;

        public CreateModel(WebApp.Data.WebAppContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Character Character { get; set; } = default!;

        public List<SelectListItem> Locations { get; set; } // For dropdown

        public async Task<IActionResult> OnGetAsync()
        {
            Locations = await _context.Locations.Select(a =>
                new SelectListItem
                {
                    Value = a.Id.ToString(),
                    Text = a.Name
                }).ToListAsync();

            return Page();
        }


        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {

            if (!ModelState.IsValid || _context.Character == null || Character == null)
            {
                return Page();
            }

            _context.Character.Add(Character);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
