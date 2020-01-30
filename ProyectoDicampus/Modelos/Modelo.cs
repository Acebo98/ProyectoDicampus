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
}
