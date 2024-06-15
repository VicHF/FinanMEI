using System;
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
    public class IndexModel : PageModel
    {
        private readonly FinanMEI.DAL.AppDbContext _context;

        public IndexModel(FinanMEI.DAL.AppDbContext context)
        {
            _context = context;
        }

        public IList<Despesa> Despesa { get;set; } = default!;

        public string DespesaSort { get; set; }
        public string ValorDespSort { get; set; }
        public string CategoriaDespSort { get; set; }
        public string DataSort { get; set; }
        public string CurrentSort { get; set; }

        public string CurrentFilter { get; set; }
        public string CurrentCategoriaFilter { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        public async Task OnGetAsync(string sortOrder, string searchDespesa, string searchCategoria, DateTime? startDate, DateTime? endDate)
        {
            DespesaSort = String.IsNullOrEmpty(sortOrder) ? "despesa_desc" : "";
            ValorDespSort = sortOrder == "ValorDespesa" ? "valordesp_desc" : "ValorDespesa";
            DataSort = sortOrder == "Data" ? "data_desc" : "Data";
            CategoriaDespSort = sortOrder == "Categoria" ? "catdesp_desc" : "Categoria";
            CurrentSort = sortOrder;

            CurrentFilter = searchDespesa;
            CurrentCategoriaFilter = searchCategoria;
            StartDate = startDate;
            EndDate = endDate;

            IQueryable<Despesa> despesasIQ = from d in _context.Despesas
                                             select d;

            if (!String.IsNullOrEmpty(searchDespesa))
            {
                despesasIQ = despesasIQ.Where(d => d.NomeDespesa.Contains(searchDespesa));
            }

            if (!String.IsNullOrEmpty(searchCategoria))
            {
                despesasIQ = despesasIQ.Where(d => d.Categoria.Contains(searchCategoria));
            }

            if (startDate.HasValue)
            {
                despesasIQ = despesasIQ.Where(d => d.Data >= startDate.Value);
            }

            if (endDate.HasValue)
            {
                despesasIQ = despesasIQ.Where(d => d.Data <= endDate.Value);
            }

            switch (sortOrder)
            {
                case "despesa_desc":
                    despesasIQ = despesasIQ.OrderByDescending(d => d.NomeDespesa);
                    break;
                case "Data":
                    despesasIQ = despesasIQ.OrderBy(d => d.Data);
                    break;
                case "data_desc":
                    despesasIQ = despesasIQ.OrderByDescending(d => d.Data);
                    break;
                case "Categoria":
                    despesasIQ = despesasIQ.OrderBy(d => d.Categoria);
                    break;
                case "catdesp_desc":
                    despesasIQ = despesasIQ.OrderByDescending(d => d.Categoria);
                    break;
                case "ValorDespesa":
                    despesasIQ = despesasIQ.OrderBy(d => d.Valor);
                    break;
                case "valordesp_desc":
                    despesasIQ = despesasIQ.OrderByDescending(d => d.Valor);
                    break;
                default:
                    despesasIQ = despesasIQ.OrderBy(d => d.NomeDespesa);
                    break;
            }

            Despesa = await despesasIQ.AsNoTracking().ToListAsync();
            
        }
    }
}
