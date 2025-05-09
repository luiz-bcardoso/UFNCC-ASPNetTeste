using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace UFNCC_DotNetASPTeste.Pages
{
    public class ProdutoModel : PageModel
    {
        public List<Produto>? Produtos { get; set; }
 
        public void OnGet()
        {
            //Lógica para requisição GET
            Produtos = new List<Produto>
            {
                new Produto{ Descricao = "Coca-Cola", Preco = 8.99m},
                new Produto{ Descricao = "Pepsi-Cola", Preco = 6.99m},
                new Produto{ Descricao = "Feijão", Preco = 3.49m},
                new Produto{ Descricao = "Arroz", Preco = 4.95m},
                new Produto{ Descricao = "Carne Moida", Preco = 23.59m}
            };
        }
    }

    public class Produto
    {
        public string Descricao { get; set; }
        public decimal Preco { get; set; }
    }
}
