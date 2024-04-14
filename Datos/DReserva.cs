using Datos.BaseDatos.Modelos;
using Datos.Core;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class DReserva
    {
        UnitOfWork _unitOfWork;

        public DReserva()
        {
            _unitOfWork = new UnitOfWork();
        }

        public int ReservaId { get; set; }
        public int TeatroId { get; set; }
        public int ClienteId { get; set; }
        public DateTime FechaReserva { get; set; }

        public List<Reserva> RegistrosTodos()
        {
            return _unitOfWork.Repository<Reserva>().Consulta().Include(c => c.teatro)
                                                  .Include(c => c.cliente).ToList();
        }

        public int Guardar(Reserva guardar)
        {
            if (guardar.ReservaId == 0)
            {
                _unitOfWork.Repository<Reserva>().Agregar(guardar);
                return _unitOfWork.Guardar();
            }
            else
            {
                var ActualizarInDB = _unitOfWork.Repository<Reserva>().Consulta().FirstOrDefault(c => c.ReservaId == guardar.ReservaId);

                if (ActualizarInDB != null)
                {
                    ActualizarInDB.TeatroId = guardar.TeatroId;
                    ActualizarInDB.ClienteId = guardar.ReservaId;
                    ActualizarInDB.FechaReserva = guardar.FechaReserva;

                    _unitOfWork.Repository<Reserva>().Editar(ActualizarInDB);
                    return _unitOfWork.Guardar();
                }
                return 0;
            }
        }

        public int Eliminar(int EliminarPorID)
        {
            var RegistroInDb = _unitOfWork.Repository<Reserva>().Consulta().FirstOrDefault(c => c.ReservaId == EliminarPorID);
            if (RegistroInDb != null)
            {
                _unitOfWork.Repository<Reserva>().Eliminar(RegistroInDb);
                return _unitOfWork.Guardar();
            }
            return 0;
        }
    }
}
