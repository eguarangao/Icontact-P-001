using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DTOs
{
    public class HorarioUpdateDto
    {
        public int IdSala { get; set; }
        public DateTime FechaYHora { get; set; }
    }
}
