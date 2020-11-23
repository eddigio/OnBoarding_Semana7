using System;
using System.Collections.Generic;
using System.Text;
using SQLite;


namespace OnBoarding.Models
{
   public class Estudiante
    {
        [PrimaryKey, AutoIncrement]
        public int id { get; set; }
        [MaxLength(255)]
        public string Nombre { get; set; }
        [MaxLength(255)]
        public string Usuario { get; set; }
        [MaxLength(255)]
        public string Contrasenia { get; set; }

    }
}
