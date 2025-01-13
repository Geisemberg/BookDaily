namespace BookDaily.Models
{
    public class Tarea
    {

        public int Id { get; set; }
        public string Descripcion { get; set; }
        public DateTime FechaVencimiento { get; set; }
        public String Prioridad { get; set; }
        public bool EstaIncompleta { get; set; }

    }
}
