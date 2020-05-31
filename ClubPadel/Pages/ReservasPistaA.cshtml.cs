﻿using System;
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
        public async Task<IActionResult> OnPost(string btnreserva)
        {
            String valorreserva = btnreserva;

            if (!ModelState.IsValid)
            {
                return Page();
            }
            return RedirectToPage("ReservaPistaB");
            /* public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            { //Busca la informmación de esa Persona por su ID
                var PersonadelaDb = await _db.Persona.FindAsync(Persona.ID);
                PersonadelaDb.Nombre = Persona.Nombre;
                PersonadelaDb.Apellido = Persona.Apellido;

                await _db.SaveChangesAsync();
                return RedirectToPage("Indice");
            }
            return RedirectToPage();
        }*/
        }
    }
}
