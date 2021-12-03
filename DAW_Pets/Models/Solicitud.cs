using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace DAW_Pets.Models
{
    public partial class Solicitud
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; } = DateTime.Now;
        public int UsuarioId { get; set; }
        public int MascotaId { get; set; }
        public string Detalle { get; set; } = "Pendiente de Revisión";
        public int QPersonas { get; set; }
        public string TipoDomicilio { get; set; }
        public string Ubicacion { get; set; }        
        
        public int? Cubierto { get; set; }
        public int? Bebe { get; set; }
        public int? Alergia { get; set; }
        public int? Mudanza { get; set; }
        public int? Estado { get; set; } = 58;
        public DateTime? FechaModificacion { get; set; }
        public string UsuarioModificacion { get; set; }

        [NotMapped]
        public List<Maestro> Habitat { get; set; }

        public virtual Maestro EstadoNavigation { get; set; }
        public virtual Mascota Mascota { get; set; }
        public virtual Usuario Usuario { get; set; }
    }
}
