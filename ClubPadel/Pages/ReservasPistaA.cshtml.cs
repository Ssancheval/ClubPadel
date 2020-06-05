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

namespace ClubPadel.Pages
{
    public class ReservasPistaModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        [BindProperty]
        public TablaPrueba TablaPrueba { get; set; }
        public Reserva Reserva { get; set; }

        private readonly ILogger<ReservasPistaModel> _logger;

        public ReservasPistaModel(ILogger<ReservasPistaModel> logger, ApplicationDbContext db)
        {
            _logger = logger;
            _db = db;
        }
        public IEnumerable<TablaPrueba> TablaPruebas { get; set; }
        public IEnumerable<Reserva> Reservas { get; set; }

        public async Task OnGet()
        {
            TablaPruebas = await _db.TablaPrueba.ToListAsync();
            Reservas = await _db.Reserva.ToListAsync();
        }

        //si se añade el metodo onPost() es para añadir los datos a la base de datos        
        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            return RedirectToPage("ReservaPistaB");          
        }

        public async Task<IActionResult> OnPostCambio(int id)
        {   
            //var nombrecito = pasar el dato de la otra página

            var tablita = await _db.TablaPrueba.FindAsync(id);//busca en la base de datos el registro
            if (tablita == null)//si no encuentra el registro no hace nada
            {
                return Page();
            }
            if (tablita != null)
            {
                if (tablita.Estado.Equals("Libre     "))
                {
                    tablita.Estado = "Ocupado   ";
                    //tablita.Nombre = nombrecito;
                }
                else if (tablita.Estado.Equals("Ocupado   "))
                {
                    tablita.Estado = "Libre     ";
                    //tablita.Nombre = "Vacio               ";
                }
            }
            _db.Entry(tablita).State = EntityState.Modified;//Modifica
            await _db.SaveChangesAsync();//Actualiza
            return RedirectToPage("ReservasPistaA");
        }
    }
}
