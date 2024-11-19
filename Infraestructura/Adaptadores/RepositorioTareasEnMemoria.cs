using Dominio.Entidades;
using Dominio.Interfaces;

namespace Infraestructura.Adaptadores
{
    public class RepositorioTareasEnMemoria : IRepositorioTareas
    {
        private readonly List<Tarea> tareas = new List<Tarea>();

        public void Agregar(Tarea tarea)
        {
            tareas.Add(tarea);
        }

        public void Actualizar(Tarea tarea)
        {
            var tareaExistente = ObtenerPorId(tarea.Id);

            if (tareaExistente != null)
            {
                tareaExistente.Descripcion = tarea.Descripcion;
                tareaExistente.EstaCompleta = tarea.EstaCompleta;
            }
        }

        public void Eliminar(Guid id)
        {
            var tarea = ObtenerPorId(id);
            if (tarea != null)
            {
                tareas.Remove(tarea);
            }
        }

        public Tarea ObtenerPorId(Guid id)
        {
            return tareas.FirstOrDefault(t => t.Id == id);
        }

        public IEnumerable<Tarea> ObtenerTodas()
        {
            return tareas;
        }
    }
}
