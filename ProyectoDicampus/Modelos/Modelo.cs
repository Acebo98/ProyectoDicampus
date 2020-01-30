using ProyectoDicampus.Entidades;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoDicampus.Modelos
{
    public class Modelo : DbContext
    {
        private static readonly string cadena = 
            ConfigurationManager.ConnectionStrings["cadenaconexion"].ConnectionString;

        //Tablas
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Pregunta> Preguntas { get; set; }

        public Modelo() : base(cadena) { }
    }

    public class DAOUsuarios : Modelo
    {
        public DAOUsuarios() : base() { }

        //Registro de usuario
        public bool Insert(Usuario nuevo)
        {
            bool vof = true;

            try
            {
                base.Usuarios.Add(nuevo);   //Lo añadimos
                base.SaveChanges();
            }
            catch(Exception)
            {
                vof = !vof;
            }

            return vof;
        }

        //Comprobar existencia de un nombre de usuario
        public bool ComprobarExistencia(string username)
        {
            bool vof = true;

            try
            {
                if (base.Usuarios != null)
                {
                    vof = base.Usuarios.Where(usuario => usuario.Username == username).Any();
                }      
                else
                {
                    throw new Exception();
                }
            }
            catch (Exception)
            {
                vof = !vof;
            }

            return vof;
        }

        //Verificar inicio de sesión
        public bool IniciarSesion(Usuario entrante)
        {
            bool vof = true;

            try
            {
                vof = base.Usuarios.Where(user => user.Username == entrante.Username && user.Password == entrante.Password).Any();
            }
            catch (Exception)
            {
                vof = !vof;
            }

            return vof;
        }

        //Sacar datos a partir del nombre
        public Usuario SacarInfo(string username)
        {
            Usuario usuario = new Usuario();

            try
            {
                usuario = base.Usuarios.Where(user => user.Username == username).SingleOrDefault();
            }
            catch (Exception)
            {
                usuario = null;
            }

            return usuario;
        }
    }
}