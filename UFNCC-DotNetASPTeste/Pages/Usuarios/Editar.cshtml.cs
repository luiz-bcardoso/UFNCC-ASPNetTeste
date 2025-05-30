using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UFNCC_DotNetASPTeste.Models;

namespace UFNCC_DotNetASPTeste.Pages.Usuarios
{
    public class EditarModel : PageModel
    {
        [BindProperty]
        public Usuario Usuario { get; set; }

        public IActionResult OnGet(int id)
        {
            var usuarios = CarregarUsuarios();
            Usuario = usuarios.FirstOrDefault(u => u.Id == id);

            if (Usuario == null)
            {
                return RedirectToPage("/Usuarios/Index");
            }

            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
                return Page();

            var usuarios = CarregarUsuarios();

            var index = usuarios.FindIndex(u => u.Id == Usuario.Id);
            if (index == -1)
                return RedirectToPage("/Usuarios/Index");

            usuarios[index] = Usuario;

            SalvarUsuarios(usuarios);

            return RedirectToPage("/Usuarios/Index");
        }

        private List<Usuario> CarregarUsuarios()
        {
            var lista = new List<Usuario>();
            var path = Path.Combine(Directory.GetCurrentDirectory(), "usuarios.txt");

            if (System.IO.File.Exists(path))
            {
                var linhas = System.IO.File.ReadAllLines(path);
                foreach (var linha in linhas)
                {
                    var dados = linha.Split(';');
                    if (dados.Length == 4 && int.TryParse(dados[0], out int id))
                    {
                        lista.Add(new Usuario
                        {
                            Id = id,
                            Nome = dados[1],
                            Senha = dados[2],
                            Email = dados[3]
                        });
                    }
                }
            }

            return lista;
        }

        private void SalvarUsuarios(List<Usuario> usuarios)
        {
            var path = Path.Combine(Directory.GetCurrentDirectory(), "usuarios.txt");
            var linhas = usuarios.Select(u => $"{u.Id};{u.Nome};{u.Senha};{u.Email}");
            System.IO.File.WriteAllLines(path, linhas);
        }
    }
}


