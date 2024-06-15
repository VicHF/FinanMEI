using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using FinanMEI.DAL;
using FinanMEI.Models;

namespace FinanMEI.Pages.Produtos
{
    public class IndexModel : PageModel
    {
        private readonly FinanMEI.DAL.AppDbContext _context;

        public IndexModel(FinanMEI.DAL.AppDbContext context)
        {
            _context = context;
        }

        public IList<Produto> Produto { get;set; } = default!;

        public string ProdutoSort { get; set; }
        public string ValUnitarioSort { get; set; }
        public string CurrentSort { get; set; }

        public async Task OnGetAsync(string sortOrder)
        {
            ProdutoSort = String.IsNullOrEmpty(sortOrder) ? "produto_desc" : "";
            ValUnitarioSort = sortOrder == "ValorUnitario" ? "valunitario_desc" : "ValorUnitario";
            CurrentSort = sortOrder;

            //IQueryable<Produto> produtosIQ = _context.Produtos;
            IQueryable<Produto> produtosIQ = from p in _context.Produtos
                                             select p;

            switch (sortOrder)
            {
                case "produto_desc":
                    produtosIQ = produtosIQ.OrderByDescending(p => p.NomeProduto);
                    break;
                case "ValorUnitario":
                    produtosIQ = produtosIQ.OrderBy(p => p.ValorUnitario);
                    break;
                case "valunitario_desc":
                    produtosIQ = produtosIQ.OrderByDescending(p => p.ValorUnitario);
                    break;
                default:
                    produtosIQ = produtosIQ.OrderBy(p => p.NomeProduto);
                    break;
            }

            //Produto = await _context.Produtos.ToListAsync();
            Produto = await produtosIQ.AsNoTracking().ToListAsync();
        }
    }
}
