using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace DAW_Pets.Models
{
    public partial class Persona
    {
        public Persona()
        {
            Usuario = new HashSet<Usuario>();
        }

        public int Id { get; set; }
        [Required(ErrorMessage = "Este campo es obligatorio.")]
        [Display(Name = "Tipo de Documento")]
        public string TipDoc { get; set; }
        [Required(ErrorMessage = "Este campo es obligatorio.")]
        [Display(Name = "Número de Documento")]
        public string NumDoc { get; set; }
        [Required(ErrorMessage = "Este campo es obligatorio.")]
        [Display(Name = "Nombres")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "Este campo es obligatorio.")]
        [Display(Name = "Apellido Paterno")]
        public string Paterno { get; set; }
        [Required(ErrorMessage = "Este campo es obligatorio.")]
        [Display(Name = "Apellido Materno")]
        public string Materno { get; set; }
        [Required(ErrorMessage = "Este campo es obligatorio.")]
        [Display(Name = "Teléfono Fijo")]
        public string Fijo { get; set; }
        [Required(ErrorMessage ="Este campo es obligatorio.")]
        [Display(Name = "Teléfono Móvil")]
        public string Telefono { get; set; }
        [Required(ErrorMessage = "Este campo es obligatorio.")]
        [Display(Name = "Teléfono Trabajo")]
        public string Trabajo { get; set; }
        [Required(ErrorMessage = "Este campo es obligatorio.")]
        [Display(Name = "Correo Electrónico")]
        [EmailAddress(ErrorMessage ="Ingrese un correo electrónico válido.")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Este campo es obligatorio.")]
        public string Direccion { get; set; }
        [Required(ErrorMessage = "Este campo es obligatorio.")]
        [NotMapped]
        [Display(Name = "Nueva Contraseña")]
        public string Pwd { get; set; }
        [NotMapped]
        [Display(Name = "Confirmar Contraseña")]
        [Compare("Pwd", ErrorMessage ="Las contraseñas no coinciden.")]
        public string ConfirmPwd { get; set; }
        public virtual ICollection<Usuario> Usuario { get; set; }
    }
}
