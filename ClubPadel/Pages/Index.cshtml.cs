using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClubPadel.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
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
        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            // _db.Add(Cliente);
            //  await _db.SaveChangesAsync();
            return RedirectToPage("ReservasPistas");
        }
    }
}
