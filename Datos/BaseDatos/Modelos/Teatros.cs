using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.BaseDatos.Modelos
{
    public class Teatros
    {
        [Key]
        public int TeatroId { get; set; }

        [Required]
        [MaxLength(75)]
        public string Nombre { get; set; }

        public int Capacidad { get; set; }

        public bool Estado { get; set; }
    }
}
