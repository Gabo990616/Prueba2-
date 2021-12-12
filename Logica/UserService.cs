using Datos;
using Entidad;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Logica
{
    public class UserService
    {
        private readonly PruebaFinal2Context _context;

        public UserService(PruebaFinal2Context context) => _context = context;

        public Usuario Validate(string userName, string password)
        {
            return _context.Usuarios.FirstOrDefault(t => t.User == userName && t.Password == password);
        }

        public UsuarioLogResponse Register(Usuario usuario)
        {
            try
            {
                if (_context.Usuarios.Find(usuario.Identificacion) == null)
                {
                    if (_context.Usuarios.Where(u => u.User == usuario.User).FirstOrDefault() == null)
                    {
                        _context.Usuarios.Add(usuario);
                        _context.SaveChanges();
                        return new UsuarioLogResponse(usuario);
                    }
                    return new UsuarioLogResponse("El nombre de usuario ya se encuentra registrado");
                }
                return new UsuarioLogResponse("El usuario ya se encuentra registrado con esta identificacion");
            }
            catch (Exception e) { return new UsuarioLogResponse($"Se presento lo siguiente al Registrar: { e.Message}"); }
        }

        public UsuarioLogResponse Inscripcion(string identificacion, int CodEvento)
        {
            try
            {
                var evento = _context.Eventos.Find(CodEvento);
                var usuario = _context.Usuarios.Find(identificacion);

                if (usuario != null)
                {
                    if(evento != null)
                    {
                        evento.CantidadInscrita = evento.CantidadInscrita + 1;
                        usuario.Evento = evento;
                        _context.Update(evento);
                        _context.Update(usuario);
                        _context.SaveChanges();
                        return new UsuarioLogResponse(usuario);
                    }
                    return new UsuarioLogResponse("El Evento no se pudo encontrar");

                }
                return new UsuarioLogResponse("El usuario no se pudo encontrar");
            }
            catch (Exception e) { return new UsuarioLogResponse($"Se presento lo siguiente al Registrar: { e.Message}"); }
        }

        public UsuarioConsultaResponse Consult()
        {
            try
            {
                var usuarios = _context.Usuarios.Include(u => u.Evento).ToList();
                if (usuarios != null)
                {
                    return new UsuarioConsultaResponse(usuarios);
                }

                return new UsuarioConsultaResponse($"Error al Consultar: Eventos No Registrado");
            }
            catch (Exception e) { return new UsuarioConsultaResponse($"Error al Guardar: Se presento lo siguiente {e.Message}"); }
        }

        public UsuarioConsultaResponse ConsultIncritos()
        {
            try
            {
                var usuarios = _context.Usuarios.Where(e=> e.Rol.Equals("ESTUDIANTE") && e.Evento != null).ToList();
                if (usuarios != null)
                {
                    return new UsuarioConsultaResponse(usuarios);
                }

                return new UsuarioConsultaResponse($"Error al Consultar: No se encontraron Inscritos");
            }
            catch (Exception e) { return new UsuarioConsultaResponse($"Error al Guardar: Se presento lo siguiente {e.Message}"); }
        }
    }
    public class UsuarioLogResponse
    {
        public string Mensaje { get; set; }
        public bool Error { get; set; }
        public Usuario Usuario { get; set; }

        public UsuarioLogResponse(string mensaje)
        {
            Error = true;
            Mensaje = mensaje;
        }

        public UsuarioLogResponse(Usuario usuario)
        {
            Error = false;
            Usuario = usuario;
        }
    }

    public class UsuarioConsultaResponse
    {
        public string Mensaje { get; set; }
        public bool Error { get; set; }
        public List<Usuario> Usuarios { get; set; }

        public UsuarioConsultaResponse(string mensaje)
        {
            Error = true;
            Mensaje = mensaje;
        }

        public UsuarioConsultaResponse(List<Usuario> usuarios)
        {
            Error = false;
            Usuarios = usuarios;
        }
    }
}
