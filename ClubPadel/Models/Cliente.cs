using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ClubPadel.Models
{
    public class Cliente
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string User { get; set; }
        [Required (ErrorMessage ="Datos incorrectos, introduzca bien los datos")]
        public string Password { get; set; }
    }
}
