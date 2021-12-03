using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAW_Pets.Models.Helpers
{
    public class WS_Response<T>
    {
        public Header Header { get; set; }
        public string Url { get; set; }
        public List<T> Listado { get; set; }
        public T Objeto { get; set; }
    }
}
