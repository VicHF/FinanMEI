using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using FinanMEI.DAL;
using FinanMEI.Models;

namespace FinanMEI.Pages.Vendas
{
    public class CreateModel : PageModel
    {
        private readonly FinanMEI.DAL.AppDbContext _context;

        public CreateModel(FinanMEI.DAL.AppDbContext context)
        {
            _context = context;
        }

       public IActionResult OnGet()
        {
        ViewData["IdProduto"] = new SelectList(_context.Produtos, "IdProduto", "NomeProduto");
       // ViewData["Context"] = _context;//NOVO
            return Page();
        }


        [BindProperty]
        // public Venda Venda { get; set; } = default!;
        public Venda Venda { get; set; } = new Venda(); //NOVO

        //public decimal ValorUnitario { get; set; } //NOVO

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            //Venda.ValorUnitario = ValorUnitario; //NOVO
            // Obter o valor unitário do produto selecionado
            var produtoSelecionado = await _context.Produtos.FindAsync(Venda.IdProduto);//NOVO
            if (produtoSelecionado == null)//NOVO
            {
                ModelState.AddModelError(string.Empty, "Produto não encontrado.");//NOVO
                return Page();//NOVO
            }

            // Atribuir o valor unitário ao objeto Venda
            Venda.ValorUnitario = produtoSelecionado.ValorUnitario;//NOVO

            _context.Vendas.Add(Venda);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
