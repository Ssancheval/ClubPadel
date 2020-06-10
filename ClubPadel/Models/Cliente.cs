
using System.ComponentModel.DataAnnotations;

namespace ClubPadel.Models
{
    public class Cliente
    {
        [Key]
        public int Id { get; set; }
        [Required (ErrorMessage = "Los datos introducidos son incorrectos. Por favor intentelo de nuevo")]
        public string User { get; set; }
        [Required (ErrorMessage ="Los datos introducidos son incorrectos. Por favor intentelo de nuevo")]
        public string Password { get; set; }
    }
}
