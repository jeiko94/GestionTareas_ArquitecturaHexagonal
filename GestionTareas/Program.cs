using Aplicacion.Interfaces;
using Aplicacion.Servicios;
using Dominio.Interfaces;
using Infraestructura.Adaptadores;

class Program
{
    static void Main(string[] args)
    {
        //Configurar dependencias
        IRepositorioTareas repositorioTareas = new RepositorioTareasEnMemoria();
        IServicioTareas servicioTareas = new ServicioTareas(repositorioTareas);

        bool salir = false;

        while (!salir)
        {

            Console.WriteLine("=== Gestión de tareas ===");
            Console.WriteLine("1. Crear una tarea");
            Console.WriteLine("2. Listar tareas pendientes");
            Console.WriteLine("3. Completar tarea");
            Console.WriteLine("4. Listar tareas completas");
            Console.WriteLine("5. Eliminar tarea");
            Console.WriteLine("0. Salir");

            var opcion = Console.ReadLine();

            switch(opcion)
            {
                case "1":
                    Console.WriteLine("Ingrese la descripción de la tarea: ");

                    var descripcion = Console.ReadLine();

                    servicioTareas.CrearTarea(descripcion);

                    Console.WriteLine("Tarea creada con éxito.");

                break;

                case "2":
                    var tareasPendientes = servicioTareas.ObtenerTareasPendientes();

                    Console.WriteLine("=== Tareas pendientes ===");

                    foreach(var pendientes in tareasPendientes)
                    {
                        Console.WriteLine($"ID: {pendientes.Id} - {pendientes.Descripcion}");
                    }
                    break;

                case "3":
                    Console.WriteLine("Ingrese el ID de la tarea a completar: ");

                    var idCompletar = Guid.Parse(Console.ReadLine());

                    servicioTareas.CompletarTarea(idCompletar);

                    Console.WriteLine("Tarea completada.");
                break;

                case "4":
                    var tarea = servicioTareas.ObtenerTareasCompletas();

                    Console.WriteLine("=== Tareas completadas ===");

                    foreach (var completas in tarea)
                    {
                        Console.WriteLine($"ID: {completas.Id} - {completas.Descripcion}");
                    }
                 break;

                case "5":
                    Console.WriteLine("Ingrese el ID de la tarea a eliminar: ");

                    var eliminarTarea = Guid.Parse(Console.ReadLine());

                    servicioTareas.EliminarTarea(eliminarTarea);

                    Console.WriteLine("Tarea eliminada con exito.");

                break;

                case "0":
                    salir = true;
                break;

                default:
                    Console.WriteLine("Opción invalidad.");
                break;
            }
        }
    }
}