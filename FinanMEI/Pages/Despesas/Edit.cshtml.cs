using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FinanMEI.DAL;
using FinanMEI.Models;

namespace FinanMEI.Pages.Despesas
{
    public class EditModel : PageModel
    {
        private readonly FinanMEI.DAL.AppDbContext _context;

        public EditModel(FinanMEI.DAL.AppDbContext context)
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

            var despesa =  await _context.Despesas.FirstOrDefaultAsync(m => m.IdDespesa == id);
            if (despesa == null)
            {
                return NotFound();
            }
            Despesa = despesa;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Despesa).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DespesaExists(Despesa.IdDespesa))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool DespesaExists(int id)
        {
            return _context.Despesas.Any(e => e.IdDespesa == id);
        }
    }
}
