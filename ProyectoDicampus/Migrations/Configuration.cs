namespace ProyectoDicampus.Migrations
{
    using ProyectoDicampus.Entidades;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ProyectoDicampus.Modelos.Modelo>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        //Datos de prueba
        protected override void Seed(ProyectoDicampus.Modelos.Modelo context)
        {
            List<Usuario> lUsuarios = new List<Usuario>()
            {
                new Usuario() { Username = "Acebo98", Password = "lupo21", Genero = true, Puntuacion = 12},
                new Usuario() { Username = "Topin98", Password = "umineko", Genero = true, Puntuacion = 53},
            };
            lUsuarios.ForEach(user => context.Usuarios.Add(user));
            context.SaveChanges();
        }
    }
}