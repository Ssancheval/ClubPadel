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
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        //-----------------------------------

        [BindProperty]
        public Cliente Cliente { get; set; }

        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger, ApplicationDbContext db)
        {
            _logger = logger;
            _db = db;
        }

        public IEnumerable<Cliente> Clientes { get; set; }

        public async Task OnGet()
        {
            Clientes = await _db.Cliente.ToListAsync();
        }

        
        public async Task<IActionResult> OnPost(string nombreUsuario, string contraseñaUsuario)
        {
            try
            {
                var cb = new SqlConnectionStringBuilder();
                var clientito = _db.Cliente;

                cb.DataSource = "Server=localhost\\CLUBPADEL";
                using (var connection = new SqlConnection(cb.ConnectionString))
                {
                    //connection.Open(); --> esta de más
                    foreach (Cliente item in clientito)
                    {
                        if (item != null)
                        {
                            if (item.User == nombreUsuario && item.Password == contraseñaUsuario)
                            {
                                return RedirectToPage("ReservasPistaA");
                            }
                        }
                    }
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.ToString());
            }

            return Page();
        }

        //si se añade el metodo onPost() es para añadir los datos a la base de datos      
        //Opción con for

        /* public async Task<IActionResult> OnPost(String nombreUsuario,String contraseñaUsuario)
         {
              string nombreUsu = nombreUsuario;
              string contraseñaUsu = contraseñaUsuario;
              if (!ModelState.IsValid)
              {
                  for (int i = 1; i <= 5; i++)//no me reconoce Clientes 
                  {//cambiar el i<= 5 por los numero id maximo de la base de datos

                      var clientito = await _db.Cliente.FindAsync(i);
                      if (clientito != null)
                      {
                          if (clientito.User == nombreUsu && clientito.Password == contraseñaUsu)
                          {
                              return RedirectToPage("ReservasPista");
                          }
                      }
                  }
              }
              return Page();    
         }*/
    }
}
