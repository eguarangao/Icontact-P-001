

namespace Business.Entities
{
    public class Horario
    {
        public int IdHorario { get; set; }
        public int IdSala { get; set; }
        public int IdPelicula { get; set; }
        public DateTime FechaYHora { get; set; }

        public Sala Sala { get; set; }
        public Pelicula Pelicula { get; set; }

    }
}
