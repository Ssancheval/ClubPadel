using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClubPadel.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace ClubPadel.Pages
{
    public class ReservasPistaModel : PageModel
    {
        [BindProperty]
        public Cliente Cliente { get; set; }

        private readonly ILogger<IndexModel> _logger;

        public ReservasPistaModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {

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
