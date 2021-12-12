using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidad
{
    public class Evento
    {
        [Key]
        public int Codigo { get; set; }
        public DateTime Fecha { get; set; }
        public string Descripcion{ get; set; }
        public int AforoPermitido { get; set; }
        public int CantidadInscrita { get; set; }

    }
}
