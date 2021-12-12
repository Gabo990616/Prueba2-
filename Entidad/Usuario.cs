using System;
using System.ComponentModel.DataAnnotations;

namespace Entidad
{
    public class Usuario
    {
        [Key]
        public string Identificacion { get; set; }
        public string Nombre { get; set; }
        public string User { get; set; }
        public string Password { get; set; }
        public string Rol { get; set; }


        public Evento Evento { get; set; }
    }
}
