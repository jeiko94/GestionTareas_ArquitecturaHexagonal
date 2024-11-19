using Dominio.Entidades;

namespace Aplicacion.Interfaces
{
    public interface IServicioTareas
    {
        void CrearTarea(string descripcion);
        void CompletarTarea(Guid id);
        void EliminarTarea(Guid id);
        IEnumerable<Tarea> ObtenerTareasPendientes();
        IEnumerable<Tarea> ObtenerTareasCompletas();
    }
}
