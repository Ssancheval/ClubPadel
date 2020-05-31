using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ClubPadel.Models
{
    public class TablaMañana
    {
        [Key]
        public int Id { get; set; }
        public int idCliente { get; set; }
        public string nomCliente { get; set; }
        public string estado { get; set; }
        [Required]
        public string hora { get; set; }
        [Required]
        public string fecha { get; set; }
    }

}
