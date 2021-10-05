using System;
using System.Collections.Generic;

#nullable disable

namespace DAW_Pets.Models
{
    public partial class Rol
    {
        public Rol()
        {
            Usuario = new HashSet<Usuario>();
        }

        public int Id { get; set; }
        public string Descripcion { get; set; }

        public virtual ICollection<Usuario> Usuario { get; set; }
    }
}
