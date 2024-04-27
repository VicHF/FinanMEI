using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using FinanMEI.DAL;
using FinanMEI.Models;

namespace FinanMEI.Pages.Vendas
{
    public class DetailsModel : PageModel
    {
        private readonly FinanMEI.DAL.AppDbContext _context;

        public DetailsModel(FinanMEI.DAL.AppDbContext context)
        {
            _context = context;
        }

        public Venda Venda { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var venda = await _context.Vendas.FirstOrDefaultAsync(m => m.IdVenda == id);
            if (venda == null)
            {
                return NotFound();
            }
            else
            {
                Venda = venda;
            }
            return Page();
        }
    }
}
