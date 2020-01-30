using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoDicampus.Entidades
{
    public class Usuario
    {
        public int ID { get; set; }
        [Required]
        [MaxLength(100)]
        public String Username { get; set; }
        [Required]
        [MaxLength(100)]
        public String Password { get; set; }
        [Required]
        public Boolean Genero { get; set; } //True -> Hombre, False -> Mujer
        [Required]
        [Range(0, 99999)]
        public int Puntuacion { get; set; }
    }
}