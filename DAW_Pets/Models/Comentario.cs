using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace DAW_Pets.Models
{
    public partial class Comentario
    {
        public int Id { get; set; }
        [Required]
        public int UsuarioId { get; set; }
        [Required]
        public int MascotaId { get; set; }
        public DateTime Fecha { get; set; }
        [Required]
        public string Comentario1 { get; set; }

        public virtual Mascota Mascota { get; set; }
        public virtual Usuario Usuario { get; set; }
    }
}
