using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.BaseDatos.Modelos
{
    public class Reserva
    {
        [Key]
        public int ReservaId { get; set; }
        public int TeatroId { get; set; }
        public int ClienteId { get; set; }
        public DateTime FechaReserva { get; set; }


        //-------------------------------------
        public Clientes cliente { get; set; }
        public Teatros teatro { get; set; }
    }
}
