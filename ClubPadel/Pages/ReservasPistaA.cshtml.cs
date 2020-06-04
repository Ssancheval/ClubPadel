using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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

        [BindProperty]
        public TablaHoy TablaHoy { get; set; }

        private readonly ILogger<ReservasPistaModel> _logger;

        public ReservasPistaModel(ILogger<ReservasPistaModel> logger, ApplicationDbContext db)
        {
            _logger = logger;
            _db = db;
        }
        public IEnumerable<TablaHoy> TablaHoys { get; set; }

        public IEnumerable<TablaPrueba> TablaPruebas { get; set; }//no es lo que queremos nos da null por alguna razón 

        public async Task OnGet()
        {
            TablaPruebas = await _db.TablaPrueba.ToListAsync();
            TablaHoys = await _db.TablaHoy.ToListAsync();
           
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



        public async Task<IActionResult> OnPostCambio(string estadito)
        {
            var Pruebita = _db.TablaPrueba;

            using (var db = _db)
            {
                var estado = db.TablaPrueba.SingleOrDefault(x => x.Estado.Equals("Reservado"));
                foreach (var item in Pruebita)
                {
                    if (estado != null)
                    {
                        estado.Estado = "Libre";
                    }
                }
            }
            await _db.SaveChangesAsync();//update

            return Page();
        }

        }
}
