
using System.ComponentModel.DataAnnotations;

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
      public int? IdCliente { get; set; }
    }
}
