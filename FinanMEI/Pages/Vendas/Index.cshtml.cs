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
    public class IndexModel : PageModel
    {
        private readonly FinanMEI.DAL.AppDbContext _context;

        public IndexModel(FinanMEI.DAL.AppDbContext context)
        {
            _context = context;
        }

        public IList<Venda> Venda { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Venda = await _context.Vendas
                .Include(v => v.Produto).ToListAsync();
        }
    }
}
