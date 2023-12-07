using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public class Unidad
    {
        public int IdUnidad { get; set; }
        public string NumeroPlaca { get; set; }
        public string Modelo { get; set; }
        public string Marca { get; set; }
        public int AnioFabricacion { get; set; }
        public EstatusUnidad EstatusUnidad { get; set; }
        public List<ML.Unidad> Unidades { get; set; }
    }
}
