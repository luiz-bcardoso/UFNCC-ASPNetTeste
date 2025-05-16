using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UFNCC_DotNetASPTeste.Models;

namespace UFNCC_DotNetASPTeste.Pages.Usuarios
{
    public class CriarModel : PageModel
    {
        [BindProperty]
        public Usuario usuario {get; set;}

        public void OnGet()
        {
        }
        public IActionResult OnPost()
        {
            if(!ModelState.IsValid)
                return Page();
            else
            {
                using (var writer = new StreamWriter("usuarios.txt", true)) //Grava em arquivo (o true não sobreescreve)
                {
                    writer.WriteLine(usuario);
                    return RedirectToPage("/Usuarios/Index");
                }
            }
        }
    }
}
