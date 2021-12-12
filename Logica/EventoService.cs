using Datos;
using Entidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
   public class EventoService
    {
        private readonly PruebaFinal2Context _context;

        public EventoService(PruebaFinal2Context context)
        {
            _context = context;
        }

        public EventoLogResponse Save(Evento evento)
        {
            try
            {
                if (_context.Eventos.Find(evento.Codigo) == null)
                {
                    _context.Eventos.Add(evento);
                    _context.SaveChanges();
                    return new EventoLogResponse(evento);
                }

                return new EventoLogResponse($"Error al Guardar: Evento Existente");
            }
            catch (Exception e) { return new EventoLogResponse($"Error al Guardar: Se presento lo siguiente {e.Message}"); }
        }

        public EventoConsultaResponse Consult()
        {
            try
            {
                var eventos = _context.Eventos.ToList();
                if (eventos != null)
                {
                    return new EventoConsultaResponse(eventos);
                }

                return new EventoConsultaResponse($"Error al Consultar: Eventos No Registrado");
            }
            catch (Exception e) { return new EventoConsultaResponse($"Error al Guardar: Se presento lo siguiente {e.Message}"); }
        }

        public EventoConsultaResponse ConsultAforoPermitido()
        {
            try
            {
                var eventos = _context.Eventos.Where(e=> e.AforoPermitido > e.CantidadInscrita).ToList();
                if (eventos != null)
                {
                    return new EventoConsultaResponse(eventos);
                }

                return new EventoConsultaResponse($"Error al Consultar: Eventos han llegado a su limite");
            }
            catch (Exception e) { return new EventoConsultaResponse($"Error al Guardar: Se presento lo siguiente {e.Message}"); }
        }

    }
    public class EventoLogResponse
    {
        public Evento Evento { get; set; }
        public string Mensaje { get; set; }
        public bool Error { get; set; }

        public EventoLogResponse(Evento evento)
        {
            Evento = evento;
            Error = false;
        }

        public EventoLogResponse(string mensaje)
        {
            Mensaje = mensaje;
            Error = true;
        }
    }

    public class EventoConsultaResponse
    {
        public List<Evento> Eventos{ get; set; }
        public string Mensaje { get; set; }
        public bool Error { get; set; }
        public EventoConsultaResponse(List<Evento> eventos)
        {
            Eventos = eventos;
            Error = false;
        }
        public EventoConsultaResponse(string mensaje)
        {
            Mensaje = mensaje;
            Error = true;
        }
    }
}
