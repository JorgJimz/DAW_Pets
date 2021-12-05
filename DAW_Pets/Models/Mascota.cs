using DAW_Pets.Models.Helpers;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace DAW_Pets.Models
{
    public partial class Mascota
    {
        public Mascota()
        {
            Comentario = new HashSet<Comentario>();
            Solicitud = new HashSet<Solicitud>();
            Vacuna = new HashSet<Vacuna>();
        }

        public int Id { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Campo obligatorio.")]
        public string Nombre { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Campo obligatorio.")]
        public string Raza { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Campo obligatorio.")]
        public string Color { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Campo obligatorio.")]
        [Range(1, int.MaxValue, ErrorMessage = "Ingrese una edad válida.")]
        public int Edad { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Campo obligatorio.")]
        public string Tipo { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Campo obligatorio.")]
        [StringLength(100)]
        public string Descripcion { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Campo obligatorio.")]
        public string Direccion { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Campo obligatorio.")]
        public string Situacion { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Campo obligatorio.")]
        public string Observaciones { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Campo obligatorio.")]
        public string Alimentacion { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Campo obligatorio.")]
        [Range(1, int.MaxValue, ErrorMessage = "Ingrese un valor correcto.")]
        public int? EsperanzaVida { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Campo obligatorio.")]
        public string ActividadFisica { get; set; }
        [Required(ErrorMessage = "Campo obligatorio.")]
        [Range(double.Epsilon, double.MaxValue, ErrorMessage = "Ingrese un valor correcto.")]
        public decimal Peso { get; set; }
        [Required(ErrorMessage = "Campo obligatorio.")]
        [Range(double.Epsilon, double.MaxValue, ErrorMessage = "Ingrese un valor correcto.")]
        public decimal Altura { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Campo obligatorio.")]
        public string Tamaño { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Campo obligatorio.")]
        public string Clima { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Campo obligatorio.")]
        public string Habitat { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Campo obligatorio.")]
        public string Caracter { get; set; }        
        public string Imagen { get; set; }
        [NotMapped]
        public Comentario NeoComentario { get; set; }
        [NotMapped]        
        public IFormFile ImagenFile { set; get; }

        public virtual ICollection<Comentario> Comentario { get; set; }
        public virtual ICollection<Solicitud> Solicitud { get; set; }
        public virtual ICollection<Vacuna> Vacuna { get; set; }
    }
}
