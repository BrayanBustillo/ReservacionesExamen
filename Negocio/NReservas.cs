using Datos.BaseDatos.Modelos;
using Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class NReservas
    {
        private DReserva dvariable;

        public NReservas()
        {
            dvariable = new DReserva();
        }

        public List<Reserva> obtener()
        {
            return dvariable.RegistrosTodos();
        }

        public int Agregar(Reserva agregar)
        {
            return dvariable.Guardar(agregar);
        }

        public int Editar(Reserva aceptar)
        {
            return dvariable.Guardar(aceptar);
        }

        public int EliminarRegistro(int registroId)
        {
            return dvariable.Eliminar(registroId);
        }
    }
}
