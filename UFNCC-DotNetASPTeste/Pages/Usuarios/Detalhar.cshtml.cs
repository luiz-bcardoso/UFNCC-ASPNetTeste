using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UFNCC_DotNetASPTeste.Models;

namespace UFNCC_DotNetASPTeste.Pages.Usuarios
{
    public class DetalharModel : PageModel
    {
        public Usuario Usuario { get; set; }
        public IActionResult OnGet(int id)
        {
            var usuarios = CarregarUsuarios();

            Usuario = usuarios.FirstOrDefault(u => u.Id == id);

            if(Usuario == null)
            {
                return RedirectToPage("/Usuario/Index");
            }
            return Page();
        }

        public List<Usuario> CarregarUsuarios()
        {
            var Usuarios = new List<Usuario>();
            if (System.IO.File.Exists("usuarios.txt"))
            {
                var linhas = System.IO.File.ReadAllLines("usuarios.txt");

                foreach (var linha in linhas)
                {
                    var dados = linha.Split(';');
                    //dados[0] = ID
                    //dados[1] = Nome ...

                    var usuario = new Usuario()
                    {
                        Id = int.Parse(dados[0]),
                        Nome = dados[1],
                        Senha = dados[2],
                        Email = dados[3]
                    };
                    Usuarios.Add(usuario);
                }
            }
            return Usuarios;
        }
    }
}


