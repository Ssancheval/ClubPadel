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


        private readonly ILogger<ReservasPistaModel> _logger;

        public ReservasPistaModel(ILogger<ReservasPistaModel> logger, ApplicationDbContext db)
        {
            _logger = logger;
            _db = db;
        }
      
        public IEnumerable<TablaPrueba> TablaPruebas { get; set; }//no es lo que queremos nos da null por alguna razón 

        public async Task OnGet()
        {
            TablaPruebas = await _db.TablaPrueba.ToListAsync();
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


        public async Task<IActionResult> OnPostCambio(int ideito)
        {
            int idd = ideito;

            var tablita = await _db.TablaPrueba.FindAsync(idd);//busca en la base de datos el registro
            if (tablita == null)//si no encuentra el registro no hace nada
            {
                return Page();
            }
            if (tablita != null)
            {
                if (tablita.Estado.Equals("Libre     "))//NO SE PORQUE EL LIBRE TIENE ESPACIOS PERO ENTRA
                {
                    tablita.Estado = "Ocupadoooo";
                    return Page();
                }
                else if (tablita.Estado.Equals("Ocupadoooo"))//ENTRA EN LOS DOS IFs
                {
                    tablita.Estado = "Libre     ";
                    return Page(); ;
                }
            }
            //_db.Entry(tablita).State = EntityState.Modified;
            await _db.SaveChangesAsync();//update
            return Page();



            //NO BORRAR --> PRUEBAS QUE HARÉ LUEGO
            /*var cb = new SqlConnectionStringBuilder();
            var Pruebita = _db.TablaPrueba;

            cb.DataSource = "localhost\\CLUBPADEL";
            using (var connection = new SqlConnection(cb.ConnectionString))
            {
                foreach (var item in Pruebita)
                {
                    if (item.Estado == estadito)
                    {                       
                        item.Estado = "Reservado";
                        //_db.Entry(item.Estado).State = EntityState.Modified;//nose pa que sirve
                    }
                    if (item.Estado == "Reservado")
                    {
                        item.Estado = "Libre";
                    }
                }
            }*/

        }
    }
}
