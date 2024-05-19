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

        public SelectList IdProdutoSelectList { get; set; } //novo novo
        public IActionResult OnGet()
        {
            IdProdutoSelectList = new SelectList(_context.Produtos, "IdProduto", "NomeProduto");//novo novo
            //ViewData["IdProduto"] = IdProdutoSelectList;//sugestao automatica complementar
            //ViewBag.IdProduto = new SelectList(_context.Produtos, "IdProduto", "NomeProduto");
            //ViewData["IdProduto"] = new SelectList(_context.Produtos, "IdProduto", "NomeProduto");
            // ViewData["Context"] = _context;//NOVO
            if (IdProdutoSelectList.Any())
            {
                Venda = new Venda { IdProduto = _context.Produtos.First().IdProduto }; // alterou
            }
            return Page();
        }


        [BindProperty]
        // public Venda Venda { get; set; } = default!;
        public Venda Venda { get; set; } = new Venda(); //NOVO

        //public decimal ValorUnitario { get; set; } //NOVO

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {


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
            Venda.NomeProduto = produtoSelecionado.NomeProduto;

            // Validar o estado do modelo novamente
            ModelState.Clear(); // alterou
            TryValidateModel(Venda); // alterou

            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Vendas.Add(Venda);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
        //public async Task<IActionResult> OnGetProductValue(int productId)//novo novo
        public async Task<JsonResult> OnGetProductValue(int productId)//novo novo
        {
            var produto = await _context.Produtos.FindAsync(productId);
            if (produto == null)
            {
                return new JsonResult(new { success = false, message = "Produto não encontrado." });
                //return new JsonResult(new { valorUnitario = 0 });
                //return NotFound();
            }

            //return new JsonResult(new { valorUnitario = produto.ValorUnitario });
            return new JsonResult(new { success = true, valorUnitario = produto.ValorUnitario });
        }

        /*public JsonResult OnGetProductValue(int productId) //novo novo
        {
            var produto = _context.Produtos.FirstOrDefault(p => p.IdProduto == productId);
            if (produto == null)
            {
                return new JsonResult(new { success = false, message = "Produto não encontrado." });
            }

            return new JsonResult(new { success = true, valorUnitario = produto.ValorUnitario });
        }*/
    }
}
