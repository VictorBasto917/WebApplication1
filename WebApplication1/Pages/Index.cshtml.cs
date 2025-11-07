using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApplication1.Models;
using WebApplication1.Data;

namespace WebApplication1.Pages
{
    public class IndexModel : PageModel
    {
        private readonly AppDbContext _context;

        public IndexModel(AppDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Cliente Cliente { get; set; } = new Cliente();

        public string? Mensaje { get; set; }

        public void OnPost()
        {
            if (ModelState.IsValid)
            {
                _context.Clientes.Add(Cliente);
                _context.SaveChanges();

                Mensaje = $"Usuario {Cliente.Nombre} {Cliente.Apellido} registrado correctamente.";
                ModelState.Clear();
            }
        }
    }
}



