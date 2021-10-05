using System;
using System.Collections.Generic;

#nullable disable

namespace DAW_Pets.Models
{
    public partial class ModuloRol
    {
        public int? RolId { get; set; }
        public int? ModuloId { get; set; }

        public virtual Modulo Modulo { get; set; }
        public virtual Rol Rol { get; set; }
    }
}
