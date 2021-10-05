using System;
using System.Collections.Generic;

#nullable disable

namespace DAW_Pets.Models
{
    public partial class Mascota
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Raza { get; set; }
        public string Color { get; set; }
        public int Edad { get; set; }
        public string Tipo { get; set; }
        public string Descripcion { get; set; }
        public string Direccion { get; set; }
    }
}
