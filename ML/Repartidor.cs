using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public class Repartidor
    {
        public int IdRepartidor { get; set; }
        public string Nombre { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public string Telefono { get; set; }
        public DateTime FechaIngreso { get; set; }
        public string Fotografia { get; set; }

        //Propiedad de Navegación
        public Unidad UnidadAsignada { get; set; }

        public List<ML.Repartidor> Repartidores { get; set; }
    }
}
