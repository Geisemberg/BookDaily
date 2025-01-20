namespace BookDaily.Models
{
    public class Tarea
    {

        public int Id { get; set; }
        public required string Descripcion { get; set; }
        public DateOnly FechaVencimiento { get; set; }
        public required String Prioridad { get; set; }
        public bool EstaIncompleta { get; set; }

    }
}
