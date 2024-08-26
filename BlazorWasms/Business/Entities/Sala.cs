
namespace Business.Entities
{
    public class Sala
    {
        public int IdSala { get; set; }
        public string? CodigoSala { get; set; }
        public string? NombreSala { get; set; }
        public ICollection<Horario> Horarios { get; set; }
    }
}
