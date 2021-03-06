using DAW_Pets.Models.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace DAW_Pets.Models
{
    public partial class Usuario
    {
        public Usuario()
        {
            Comentario = new HashSet<Comentario>();
            Solicitud = new HashSet<Solicitud>();
        }

        [NotMapped]
        public Header Header { get; set; }
        public int Id { get; set; }
        public string Login { get; set; }
        public string Sal { get; set; }
        public string Password { get; set; }
        public int? PersonaId { get; set; }
        public int RolId { get; set; }
        public int Estado { get; set; }

        public virtual Persona Persona { get; set; }
        public virtual Rol Rol { get; set; }
        public virtual ICollection<Comentario> Comentario { get; set; }
        public virtual ICollection<Solicitud> Solicitud { get; set; }
    }
}
