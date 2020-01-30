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
        protected DbSet<Usuario> Usuarios { get; set; }
        protected DbSet<Pregunta> Preguntas { get; set; }

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
            }
            catch (Exception err)
            {
                vof = !vof;
            }

            return vof;
        }
    }
}
