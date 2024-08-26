

namespace Business.Entities
{
    public class Pelicula
    {
        public int IdPelicula { get; set; }
        public string? NombrePelicula { get; set; }
        public string? Clasificacion { get; set; }
        public int DuracionMin { get; set; }
        public ICollection<Horario> Horarios { get; set; }
    }
}
