using Dominio.Entidades;

namespace Dominio.Interfaces
{
    public interface IRepositorioTareas
    {
        void Agregar(Tarea tarea);
        void Actualizar(Tarea tarea);
        void Eliminar(Guid id);
        Tarea ObtenerPorId(Guid id);
        IEnumerable<Tarea> ObtenerTodas();
    }
}
