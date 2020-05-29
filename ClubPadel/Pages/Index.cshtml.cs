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
                          if (clientito.user == nombreUsu && clientito.password==contraseñaUsu)
                          {
                              return RedirectToPage("ReservasPista");
                          }
                      }
                  }
              }
              return Page();    
         }*/

        public async Task<IActionResult> OnPost(string nombreUsuario, string contraseñaUsuario)
        {
            try
            {
                var cb = new SqlConnectionStringBuilder();

                cb.DataSource = "Server=localhost\\CLUBPADEL";
                using (var connection = new SqlConnection(cb.ConnectionString))
                {
                    connection.Open();
                    foreach (Cliente item in Clientes)//da error en Clientes nullreference exception
                    {
                        if (item != null)
                        {
                            if (item.user == nombreUsuario && item.password == contraseñaUsuario)
                            {
                                return RedirectToPage("ReservasPistas");
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

       /*también me da error en la conexión
        *public async Task<IActionResult> OnPost(string nombreUsu, string contraseñaUsu)
        {

            if (!ModelState.IsValid)
            {
                using (SqlConnection conexionconsql = new SqlConnection(ConfigurationManager.ConnectionStrings["ConexionInicioSesion"].ConnectionString))
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "Cliente";
                    cmd.Connection = conexionconsql;
                    conexionconsql.Open();
                    foreach (Cliente item in Clientes)
                    {
                        if (item != null)
                        {
                            if (item.Usuario == nombreUsu && item.Contraseña == contraseñaUsu)
                            {
                                return RedirectToPage("PaginaInicial");
                            }
                        }
                    }
                    conexionconsql.Close();
                }

                return RedirectToPage();//cuando se guarde nos lleva a la página indice
            }*/
        }
}
