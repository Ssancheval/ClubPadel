using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ClubPadel.Models
{
    public class Reserva
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Fecha { get; set; }
        public int Pista { get; set; }
        [Required]
        public string Hora { get; set; }
      //  [Required]
       // public string Estado { get; set; }
        public int? IdCliente { get; set; }
    }
}
