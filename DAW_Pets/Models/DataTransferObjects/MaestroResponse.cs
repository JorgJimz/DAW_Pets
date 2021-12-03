using DAW_Pets.Models.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAW_Pets.Models.DataTransferObjects
{
    public class MaestroResponse
    {
        public Header Header { get; set; }
        public List<Maestro> Lista { get; set; }
        public Maestro Objecto { get; set; }
    }
}
