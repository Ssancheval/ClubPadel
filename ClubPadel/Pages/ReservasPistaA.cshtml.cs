﻿using System;
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
        [BindProperty]
        public Reserva Reserva { get; set; }
        [BindProperty]
        public Cliente Cliente { get; set; }

        [TempData]
        public string Usuario { get; set; }

        private readonly ILogger<ReservasPistaModel> _logger;

        public ReservasPistaModel(ILogger<ReservasPistaModel> logger, ApplicationDbContext db)
        {
            _logger = logger;
            _db = db;
        }
        public IEnumerable<TablaPrueba> TablaPruebas { get; set; }
        public IEnumerable<Reserva> Reservas { get; set; }
        public IEnumerable<Cliente> Clientes { get; set; }

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

        public async Task<IActionResult> OnPostCambio(int id, string nombreUsuario)
        {
            var usu = nombreUsuario;

            var tablita = await _db.TablaPrueba.FindAsync(id);//busca en la base de datos el registro
            var clientes = _db.Cliente;
            if (tablita == null)//si no encuentra el registro no hace nada
            {
                return Page();
            }
            if (tablita != null)
            {
                if (tablita.Estado.Equals("Libre     "))
                {
                    tablita.Estado = "Ocupado   ";
                    foreach (var item in clientes)
                    {
                        if (item.User.Equals(usu))
                        {
                            tablita.Nombre = item.User;
                        }
                    }
                }
                else if (tablita.Estado.Equals("Ocupado   "))
                {
                    tablita.Estado = "Libre     ";
                    tablita.Nombre = "Vacio";
                }
            }
            _db.Entry(tablita).State = EntityState.Modified;//Modifica
            await _db.SaveChangesAsync();//Actualiza
            return RedirectToPage("ReservasPistaA");//recarga la página
        }
    }
}
