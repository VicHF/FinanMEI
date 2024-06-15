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

        /*public async Task OnGetAsync()
        {
            Venda = await _context.Vendas
                .Include(v => v.Produto).ToListAsync();
        }*/ //anterior

        public string ProdutoSort { get; set; }
        public string ValorTotalSort { get; set; }
        public string DataSort { get; set; }
        public string QtdeSort { get; set; }
        public string ValUnitarioSort { get; set; }
        public string CurrentSort { get; set; }

        public string CurrentFilter { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        public async Task OnGetAsync(string sortOrder, string searchProduto, DateTime? startDate, DateTime? endDate)
        {
            ProdutoSort = String.IsNullOrEmpty(sortOrder) ? "produto_desc" : "";
            ValorTotalSort = sortOrder == "ValorTotal" ? "valortotal_desc" : "ValorTotal";
            DataSort = sortOrder == "Data" ? "data_desc" : "Data";
            QtdeSort = sortOrder == "Quantidade" ? "qtde_desc" : "Quantidade";
            ValUnitarioSort = sortOrder == "ValorUnitario" ? "valunitario_desc" : "ValorUnitario";
            CurrentSort = sortOrder;

            CurrentFilter = searchProduto;
            StartDate = startDate;
            EndDate = endDate;

            /*IQueryable<Venda> vendasIQ = from v in _context.Vendas
                                         select v;*/

            IQueryable<Venda> vendasIQ = _context.Vendas.Include(v => v.Produto);

            if (!String.IsNullOrEmpty(searchProduto))
            {
                vendasIQ = vendasIQ.Where(v => v.Produto.NomeProduto.Contains(searchProduto));
            }

            if (startDate.HasValue)
            {
                vendasIQ = vendasIQ.Where(v => v.Data >= startDate.Value);
            }

            if (endDate.HasValue)
            {
                vendasIQ = vendasIQ.Where(v => v.Data <= endDate.Value);
            }

            switch (sortOrder)
            {
                case "produto_desc":
                    vendasIQ = vendasIQ.OrderByDescending(v => v.Produto.NomeProduto);
                    break;
                case "ValorTotal":
                    vendasIQ = vendasIQ.OrderBy(v => v.Qtde * v.ValorUnitario);
                    break;
                case "valortotal_desc":
                    vendasIQ = vendasIQ.OrderByDescending(v => v.Qtde * v.ValorUnitario);
                    break;
                case "Data":
                    vendasIQ = vendasIQ.OrderBy(v => v.Data);
                    break;
                case "data_desc":
                    vendasIQ = vendasIQ.OrderByDescending(v => v.Data);
                    break;
                case "Quantidade":
                    vendasIQ = vendasIQ.OrderBy(v => v.Qtde);
                    break;
                case "qtde_desc":
                    vendasIQ = vendasIQ.OrderByDescending(v => v.Qtde);
                    break;
                case "ValorUnitario":
                    vendasIQ = vendasIQ.OrderBy(v => v.ValorUnitario);
                    break;
                case "valunitario_desc":
                    vendasIQ = vendasIQ.OrderByDescending(v => v.ValorUnitario);
                    break;
                default:
                    vendasIQ = vendasIQ.OrderBy(v => v.Produto.NomeProduto);
                    break;
            }

            Venda = await vendasIQ.AsNoTracking().ToListAsync();
        }
    }
}
