using Datos.BaseDatos.Modelos;
using Datos.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class DTeatros
    {
        UnitOfWork _unitOfWork;

        public DTeatros()
        {
            _unitOfWork = new UnitOfWork();
        }

        public int TeatroId { get; set; }
        public string Nombre { get; set; }
        public int Capacidad { get; set; }
        public bool Estado { get; set; }

        public List<Teatros> RegistrosTodos()
        {
            return _unitOfWork.Repository<Teatros>().Consulta().ToList();
        }

        public int Guardar(Teatros guardar)
        {
            if (guardar.TeatroId == 0)
            {
                _unitOfWork.Repository<Teatros>().Agregar(guardar);
                return _unitOfWork.Guardar();
            }
            else
            {
                var ActualizarInDB = _unitOfWork.Repository<Teatros>().Consulta().FirstOrDefault(c => c.TeatroId == guardar.TeatroId);

                if (ActualizarInDB != null)
                {
                    ActualizarInDB.Nombre = guardar.Nombre;
                    ActualizarInDB.Capacidad = guardar.Capacidad;
                    ActualizarInDB.Estado = guardar.Estado;

                    _unitOfWork.Repository<Teatros>().Editar(ActualizarInDB);
                    return _unitOfWork.Guardar();
                }
                return 0;
            }
        }

        public int Eliminar(int EliminarPorID)
        {
            var RegistroInDb = _unitOfWork.Repository<Teatros>().Consulta().FirstOrDefault(c => c.TeatroId == EliminarPorID);
            if (RegistroInDb != null)
            {
                _unitOfWork.Repository<Teatros>().Eliminar(RegistroInDb);
                return _unitOfWork.Guardar();
            }
            return 0;
        }
    }
}
