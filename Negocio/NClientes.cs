using Datos;
using Datos.BaseDatos.Modelos;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Common.CommandTrees;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class NClientes
    {
        private DClientes dvariable;

        public NClientes()
        {
            dvariable = new DClientes();
        }

        public List<Clientes> obtener()
        {
            return dvariable.RegistrosTodos();
        }

        public int Agregar(Clientes agregar)
        {
            return dvariable.Guardar(agregar);
        }

        public int Editar(Clientes aceptar)
        {
            return dvariable.Guardar(aceptar);
        }

        public int EliminarRegistro(int registroId)
        {
            return dvariable.Eliminar(registroId);
        }

        public List<Clientes> RegistrosActivos()
        {
            return dvariable.RegistrosTodos().Where(c => c.Estado == true).ToList();
        }

        public List<Clientes> RegistrosInactivos()
        {
            return dvariable.RegistrosTodos().Where(c => c.Estado == false).ToList();
        }
    }
}
