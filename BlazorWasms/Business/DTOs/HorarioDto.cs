

namespace Business.DTOs
{
    public  class HorarioDto
    {
        public int IdHorario { get; set; }
        public int IdSala { get; set; }
        public int IdPelicula { get; set; }
        public DateTime FechaYHora { get; set; }
        public string NombreSala { get; set; }
        public string NombrePelicula { get; set; }
        // Constructor para inicializar el DTO con datos
        // Método opcional para manipular los datos antes de enviarlos
        public void PrepararParaEnvio()
        {
            // Ejemplo de conversión de la fecha y hora a UTC antes de enviarla
            FechaYHora = FechaYHora.ToUniversalTime();

            // Otros ajustes que podrías necesitar hacer antes de enviar los datos
        }
    }
    
}
