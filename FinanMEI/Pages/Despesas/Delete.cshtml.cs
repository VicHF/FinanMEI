﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using FinanMEI.DAL;
using FinanMEI.Models;

namespace FinanMEI.Pages.Despesas
{
    public class DeleteModel : PageModel
    {
        private readonly FinanMEI.DAL.AppDbContext _context;

        public DeleteModel(FinanMEI.DAL.AppDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Despesa Despesa { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var despesa = await _context.Despesas.FirstOrDefaultAsync(m => m.IdDespesa == id);

            if (despesa == null)
            {
                return NotFound();
            }
            else
            {
                Despesa = despesa;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var despesa = await _context.Despesas.FindAsync(id);
            if (despesa != null)
            {
                Despesa = despesa;
                _context.Despesas.Remove(Despesa);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
