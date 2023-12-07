using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Rol
    {
        public static List<ML.Rol> GetAll()
        {
            List<ML.Rol> Roles = new List<ML.Rol>();
            try
            {
                using (DL.IvBetoTrackingAndTraceEntities context = new DL.IvBetoTrackingAndTraceEntities())
                {
                    var query = context.RolGetAll();
                    if(query != null) 
                    { 
                        foreach(var item in query)
                        {
                            ML.Rol rol = new ML.Rol();
                            rol.IdRol = item.IdRol;
                            rol.Tipo = item.Tipo;

                            Roles.Add(rol);
                        }
                    }
                }
            }catch (Exception ex)
            {
                string msg = ex.Message;
            }
            return Roles;
        }
    }
}
