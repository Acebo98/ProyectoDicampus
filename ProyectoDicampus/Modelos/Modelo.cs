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

    #region MODELO USUARIOS
    //-------------------------------
    //MODELO PARA LOS USUARIOS
    //-------------------------------
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
                vof = base.Usuarios.Where(usuario => usuario.Username == username).Any();
            }
            catch (Exception)
            {
                vof = !vof;
            }

            return vof;
        }
        public bool ComprobarExistencia(string nuevoUser, string antiguoUser)
        {
            bool vof = true;

            try
            {
                vof = base.Usuarios.Where(usuario => usuario.Username == nuevoUser 
                    && usuario.Username != antiguoUser).Any();
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
        public Usuario SacarInfo(int identificador)
        {
            Usuario usuario = new Usuario();

            try
            {
                usuario = base.Usuarios.Where(user => user.ID == identificador).SingleOrDefault();
            }
            catch (Exception)
            {
                usuario = null;
            }

            return usuario;
        }

        //Aumentar puntuacion
        public bool AumentarPuntuacion(string username, int aSumar)
        {
            bool vof = true;

            try
            {
                Usuario usuario = this.SacarInfo(username);
                usuario.Puntuacion += aSumar;
                base.SaveChanges();
            }
            catch(Exception)
            {
                vof = !vof;
            }

            return vof;
        }

        //Sacamos el ranking
        public List<Usuario> SacarRanking()
        {
            List<Usuario> lUsuarios = null;

            try
            {
                lUsuarios = base.Usuarios.OrderByDescending(user => user.Puntuacion).ToList();
            }
            catch(Exception)
            {
                lUsuarios = null;
            }

            return lUsuarios;
        }

        //Modificar perfil
        public bool ModificarPerfil(Usuario nuevo)
        {
            bool vof = true;

            try
            {
                Usuario modificar = base.Usuarios.Where(user => user.ID == nuevo.ID).Single();
                modificar.Password = nuevo.Password;
                modificar.Username = nuevo.Username;
                modificar.Genero = nuevo.Genero;

                base.SaveChanges();
            }
            catch (Exception)
            {
                vof = !vof;
            }

            return vof;
        }
    }
    #endregion

    #region MODELO PREGUNTAS
    //-------------------------------
    //MODELO PARA LAS PREGUNTAS
    //-------------------------------
    public class DAOPreguntas : Modelo
    {
        public DAOPreguntas() : base() { }

        //Propiedad para ver si hay preguntas
        public bool HayPreguntas
        {
            get
            {
                return base.Preguntas.Count() > 0;
            }
        }

        //Insertar una pregunta
        public bool InsertPregunta(Pregunta nueva)
        {
            bool vof = true;

            try
            {
                base.Preguntas.Add(nueva);
                base.SaveChanges();
            }
            catch(Exception)
            {
                vof = !vof;
            }

            return vof;
        }

        //Sacamos una pregunta al azar
        public Pregunta PreguntaAzar()
        {
            Random rnd = new Random();
            Pregunta pregunta = null;

            try
            {
                List<Pregunta> lPreguntas = base.Preguntas.ToList();
                pregunta = lPreguntas[rnd.Next(0, lPreguntas.Count)];   //Pregunta al azar
            }
            catch(Exception)
            {
                pregunta = null;
            }

            return pregunta;
        }
    }
    #endregion
}