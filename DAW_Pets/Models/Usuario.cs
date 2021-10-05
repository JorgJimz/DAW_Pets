using System;
using System.Collections.Generic;

#nullable disable

namespace DAW_Pets.Models
{
    public partial class Usuario
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public int? PersonaId { get; set; }
        public int? RolId { get; set; }

        public virtual Persona Persona { get; set; }
        public virtual Rol Rol { get; set; }
    }
}
