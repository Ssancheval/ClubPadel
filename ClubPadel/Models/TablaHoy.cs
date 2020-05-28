using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace ClubPadel.Models
{
    public class TablaHoy
    {
        [Key]
        public int Id { get; set; }
        public string reserva { get; set; }
        [Required]
        public string hora { get; set; }
        [Required]
        public string fecha { get; set; }
    }
}
