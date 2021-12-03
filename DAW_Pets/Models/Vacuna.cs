using System;
using System.Collections.Generic;

#nullable disable

namespace DAW_Pets.Models
{
    public partial class Vacuna
    {
        public int Id { get; set; }
        public int MascotaId { get; set; }
        public int VacunaId { get; set; }
        public DateTime Fecha { get; set; }

        public virtual Mascota Mascota { get; set; }
        public virtual Maestro VacunaNavigation { get; set; }
    }
}
