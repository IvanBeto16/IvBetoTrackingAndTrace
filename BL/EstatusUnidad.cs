using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class EstatusUnidad
    {
        public static List<ML.EstatusUnidad> GetAll()
        {
            List<ML.EstatusUnidad> Objects = new List<ML.EstatusUnidad>();
            using (DL.IvBetoTrackingAndTraceEntities context = new DL.IvBetoTrackingAndTraceEntities())
            {
                var query = context.EstatusUnidadGetAll();
                if(query != null)
                {
                    Objects = new List<ML.EstatusUnidad>();
                    foreach(var item in query)
                    {
                        ML.EstatusUnidad estatus = new ML.EstatusUnidad();
                        estatus.IdEstatus = item.IdEstatus;
                        estatus.Estatus = item.Estatus;

                        Objects.Add(estatus);
                    }
                }
                return Objects;
            }
        }
    }
}
