using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoDicampus.Entidades
{
    public class Pregunta
    {
        public int ID { get; set; }
        [Required]
        [MaxLength(100)]
        public String Nombre { get; set; }
        [Required]
        [MaxLength(100)]
        public String Respuesta1 { get; set; }
        [Required]
        [MaxLength(100)]
        public String Respuesta2 { get; set; }
        [Required]
        [MaxLength(100)]
        public String Respuesta3 { get; set; }
        [Required]
        [MaxLength(100)]
        public String Respuesta4 { get; set; }
        [Required]
        public int Correcta { get; set; }

        //Relación
        public int UsuarioID { get; set; }
        public Usuario Usuario { get; set; }
    }
}