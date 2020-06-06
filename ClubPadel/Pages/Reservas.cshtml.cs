using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClubPadel.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace ClubPadel.Pages
{
    public class ReservasModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        [BindProperty]
        public Reserva Reserva { get; set; }
        [BindProperty]
        public Cliente Cliente { get; set; }

        private readonly ILogger<ReservasModel> _logger;

        public ReservasModel(ILogger<ReservasModel> logger, ApplicationDbContext db)
        {
            _logger = logger;
            _db = db;
        }
        public IEnumerable<Reserva> Reservas { get; set; }
        public IEnumerable<Cliente> Clientes { get; set; }

        public async Task OnGet()
        {
            Reservas = await _db.Reserva.ToListAsync();
        }

        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            return RedirectToPage("Reservas");
        }

        public async Task<IActionResult> OnPostCambio(int id, string usuario, string nombre, int idCli)
        {
            var tablita = await _db.Reserva.FindAsync(id);//busca en la base de datos el registro
            if (tablita == null)//si no encuentra el registro no hace nada
            {
                return Page();
            }
            if (tablita != null)
            {
                if (tablita.IdCliente.Equals(null))
                {
                    tablita.IdCliente = idCli;
                }
                else if (tablita.IdCliente.Equals(idCli))
                {
                    tablita.IdCliente = null;
                }
            }
            _db.Entry(tablita).State = EntityState.Modified;//Modifica
            await _db.SaveChangesAsync();//Actualiza
            return RedirectToPage("Reservas");//recarga la página
        }
    }
}