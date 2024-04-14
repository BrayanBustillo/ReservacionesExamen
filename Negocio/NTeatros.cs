using Datos.BaseDatos.Modelos;
using Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class NTeatros
    {
        private DTeatros dvariable;

        public NTeatros()
        {
            dvariable = new DTeatros();
        }

        public List<Teatros> obtener()
        {
            return dvariable.RegistrosTodos();
        }

        public int Agregar(Teatros agregar)
        {
            return dvariable.Guardar(agregar);
        }

        public int Editar(Teatros aceptar)
        {
            return dvariable.Guardar(aceptar);
        }

        public int EliminarRegistro(int registroId)
        {
            return dvariable.Eliminar(registroId);
        }

        public List<Teatros> RegistrosActivos()
        {
            return dvariable.RegistrosTodos().Where(c => c.Estado == true).ToList();
        }

        public List<Teatros> RegistrosInactivos()
        {
            return dvariable.RegistrosTodos().Where(c => c.Estado == false).ToList();
        }
    }
}
