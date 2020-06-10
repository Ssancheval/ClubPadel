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

        public int prueba { get; set; }

        private readonly ILogger<ReservasModel> _logger;

        public ReservasModel(ILogger<ReservasModel> logger, ApplicationDbContext db)
        {
            _logger = logger;
            _db = db;
        }
        public IEnumerable<Reserva> Reservas { get; set; }
        public IEnumerable<Cliente> Clientes { get; set; }

        public async Task OnGet(int idCli)
        {
            Reservas = await _db.Reserva.ToListAsync();

            var fechaHoy = DateTime.Now;
            var fechaMañana = fechaHoy.AddDays(1);
            var maxFecha = fechaMañana.ToString("yyyy-MM-dd");

            var fecha = from m in _db.Reserva select m;
            prueba = fecha.Where(s => s.Fecha.Contains(maxFecha)).Count();
            if (prueba == 0)
            {
                //_db.Database.ExecuteSqlRaw("execute InsertarRegistros");
            }
        }

        public async Task<IActionResult> OnPostCambio(int id, int idCli)
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

        public async Task<IActionResult> OnPostRecargar(string nombre, int idCli, string fecha)
        {
            return Redirect("Reservas/" + nombre + "/" + idCli + "/" + fecha);
        }
    }
}