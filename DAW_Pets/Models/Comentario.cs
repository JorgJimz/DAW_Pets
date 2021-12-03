using System;
using System.Collections.Generic;

#nullable disable

namespace DAW_Pets.Models
{
    public partial class Comentario
    {
        public int Id { get; set; }
        public int UsuarioId { get; set; }
        public int MascotaId { get; set; }
        public DateTime Fecha { get; set; }
        public string Comentario1 { get; set; }

        public virtual Mascota Mascota { get; set; }
        public virtual Usuario Usuario { get; set; }
    }
}
