using System;
using System.Collections.Generic;
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
        public string Nombre { get; set; }
        public string Raza { get; set; }
        public string Color { get; set; }
        public int Edad { get; set; }
        public string Tipo { get; set; }
        public string Descripcion { get; set; }
        public string Direccion { get; set; }
        public string Situacion { get; set; }
        public string Observaciones { get; set; }
        public string Alimentacion { get; set; }
        public int? EsperanzaVida { get; set; }
        public string ActividadFisica { get; set; }
        public decimal Peso { get; set; }
        public decimal Altura { get; set; }
        public string Tamaño { get; set; }
        public string Clima { get; set; }
        public string Habitat { get; set; }
        public string Caracter { get; set; }
        public string Imagen { get; set; }
        [NotMapped]
        public Comentario NeoComentario { get; set; }

        public virtual ICollection<Comentario> Comentario { get; set; }
        public virtual ICollection<Solicitud> Solicitud { get; set; }
        public virtual ICollection<Vacuna> Vacuna { get; set; }
    }
}
