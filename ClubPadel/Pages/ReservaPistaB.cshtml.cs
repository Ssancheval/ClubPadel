﻿using System;
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
    public class ReservaPistaBModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        //-----------------------------------

        [BindProperty]
        public Reserva Reserva { get; set; }

        private readonly ILogger<ReservaPistaBModel> _logger;

        public ReservaPistaBModel(ILogger<ReservaPistaBModel> logger, ApplicationDbContext db)
        {
            _logger = logger;
            _db = db;
        }
        public IEnumerable<Reserva> Reservas { get; set; }

        public async Task OnGet()
        {
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
    }
}