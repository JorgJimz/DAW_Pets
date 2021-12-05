using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        [Display(Name = "Número de Familiares")]
        public int QPersonas { get; set; }
        [Display(Name = "Tipo de Domicilio")]
        public string TipoDomicilio { get; set; }
        public string Ubicacion { get; set; }
        [Display(Name = "Predio Cubierto")]
        public int? Cubierto { get; set; }
        [Display(Name = "¿Hay bebés?")]
        public int? Bebe { get; set; }
        [Display(Name = "¿Alergicos?")]
        public int? Alergia { get; set; }
        [Display(Name = "Plan de Mudanza")]
        public int? Mudanza { get; set; }

        public int? Estado { get; set; } = 58;
        public DateTime? FechaModificacion { get; set; }
        public string UsuarioModificacion { get; set; }

        [NotMapped]
        public List<Maestro> Habitat { get; set; }

        [Display(Name = "Estado")]
        public virtual Maestro EstadoNavigation { get; set; }
        public virtual Mascota Mascota { get; set; }
        public virtual Usuario Usuario { get; set; }
    }
}
