﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebApp.Data;
using WebApp.Models;

namespace WebApp.Pages.Characters
{
    public class DeleteModel : PageModel
    {
        private readonly WebApp.Data.WebAppContext _context;

        public DeleteModel(WebApp.Data.WebAppContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Character Character { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Character == null)
            {
                return NotFound();
            }

            var character = await _context.Character.FirstOrDefaultAsync(m => m.Id == id);

            if (character == null)
            {
                return NotFound();
            }
            else 
            {
                Character = character;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Character == null)
            {
                return NotFound();
            }
            var character = await _context.Character.FindAsync(id);

            if (character != null)
            {
                Character = character;
                _context.Character.Remove(Character);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
