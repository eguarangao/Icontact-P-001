using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
