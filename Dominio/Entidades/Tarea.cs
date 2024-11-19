namespace Dominio.Entidades
{
    public class Tarea
    {
        public Guid Id { get; set; }
        public string? Descripcion { get; set; }
        public bool EstaCompleta { get; set; }
    }
}
