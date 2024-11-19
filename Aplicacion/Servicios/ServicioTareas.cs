
using Aplicacion.Interfaces;
using Dominio.Entidades;
using Dominio.Interfaces;

namespace Aplicacion.Servicios
{
    public class ServicioTareas : IServicioTareas
    {
        private readonly IRepositorioTareas _repositorioTareas;

        public ServicioTareas(IRepositorioTareas repositorioTareas)
        {
            _repositorioTareas = repositorioTareas;
        }
        public void CrearTarea(string descripcion)
        {
            if (string.IsNullOrWhiteSpace(descripcion))
            {
                throw new ArgumentException("La descripción de la tarea es obligatoria.");
            }

            var tarea = new Tarea { Descripcion = descripcion };
            _repositorioTareas.Agregar(tarea);
        }
        public void CompletarTarea(Guid id)
        {
            var tarea = _repositorioTareas.ObtenerPorId(id);

            if (tarea != null)
            {
                tarea.EstaCompleta = true;
                _repositorioTareas.Actualizar(tarea);
            }
        }
        public void EliminarTarea(Guid id)
        {
            _repositorioTareas.Eliminar(id);
        }
        public IEnumerable<Tarea> ObtenerTareasPendientes()
        {
            return _repositorioTareas.ObtenerTodas().Where(t => !t.EstaCompleta);
        }
        public IEnumerable<Tarea> ObtenerTareasCompletas()
        {
            return _repositorioTareas.ObtenerTodas().Where(t => t.EstaCompleta);
        }
    }
}
