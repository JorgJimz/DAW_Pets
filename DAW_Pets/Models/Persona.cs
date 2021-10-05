using System;
using System.Collections.Generic;

#nullable disable

namespace DAW_Pets.Models
{
    public partial class Persona
    {
        public Persona()
        {
            Usuario = new HashSet<Usuario>();
        }

        public int Id { get; set; }
        public string TipDoc { get; set; }
        public string NumDoc { get; set; }
        public string Nombre { get; set; }
        public string Paterno { get; set; }
        public string Materno { get; set; }
        public string Telefono { get; set; }
        public string Direccion { get; set; }

        public virtual ICollection<Usuario> Usuario { get; set; }
    }
}
