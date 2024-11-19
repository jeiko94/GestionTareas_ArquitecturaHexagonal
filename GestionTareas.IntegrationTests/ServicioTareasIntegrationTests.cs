using Aplicacion.Servicios;
using Infraestructura.Adaptadores;

namespace GestionTareas.IntegrationTests
{
    public class ServicioTareasIntegrationTests
    {
        [Fact]
        public void CrearTarea_TareaEsAgregadaCorrectamente()
        {
            //Arrange
            var repositorio = new RepositorioTareasEnMemoria();
            var servicio = new ServicioTareas(repositorio);

            string descripcion = "Tarea de prueba";

            //Act
            servicio.CrearTarea(descripcion);

            //Assert
            var tareasPendientes = servicio.ObtenerTareasPendientes();
            Assert.Single(tareasPendientes);

            var tarea = tareasPendientes.First();
            Assert.Equal(descripcion, tarea.Descripcion);
        }

        [Fact]
        public void CompletarTarea_TareaCambiaAEstadoCompletada()
        {
            //Arrange
            var repositorio = new RepositorioTareasEnMemoria();
            var servicio = new ServicioTareas(repositorio);

            servicio.CrearTarea("Tarea a completar");
            var tarea = servicio.ObtenerTareasPendientes().First();

            //Act
            servicio.CompletarTarea(tarea.Id);

            //Assert
            var tareasPendientes = servicio.ObtenerTareasPendientes();
            Assert.Empty(tareasPendientes);

            var tareasCompletadas = servicio.ObtenerTareasCompletas();
            Assert.Single(tareasCompletadas);

            var tareaCompleta = tareasCompletadas.First();
            Assert.Equal(tarea.Id, tareaCompleta.Id);
            Assert.True(tareaCompleta.EstaCompleta);
        }

        [Fact]
        public void EliminarTarea_TareaEsEliminada()
        {
            //Arrange
            var repositorio = new RepositorioTareasEnMemoria();
            var servicio = new ServicioTareas(repositorio);

            servicio.CrearTarea("Tarea a eliminar");
            var tarea = servicio.ObtenerTareasPendientes().First();

            //Act
            servicio.EliminarTarea(tarea.Id);

            //Asert
            var tareasPendientes = servicio.ObtenerTareasPendientes();
            Assert.Empty(tareasPendientes);
        }

        [Fact]
        public void GestionDeTareas_EscenarioCompleto()
        {
            // Arrange
            var repositorio = new RepositorioTareasEnMemoria();
            var servicio = new ServicioTareas(repositorio);

            servicio.CrearTarea("Tarea 1");
            servicio.CrearTarea("Tarea 2");
            servicio.CrearTarea("Tarea 3");

            var tareasPendientes = servicio.ObtenerTareasPendientes();
            Assert.Equal(3, tareasPendientes.Count());

            // Act
            var tarea2 = tareasPendientes.First(t => t.Descripcion == "Tarea 2");
            servicio.CompletarTarea(tarea2.Id);

            // Assert
            tareasPendientes = servicio.ObtenerTareasPendientes();
            Assert.Equal(2, tareasPendientes.Count());

            var tareasCompletadas = servicio.ObtenerTareasCompletas();
            Assert.Single(tareasCompletadas);
            Assert.Equal("Tarea 2", tareasCompletadas.First().Descripcion);
        }
    }
}