using DL;
using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Repartidor
    {
        //Metodos de esta entidad realizados con LINQ
        public static bool Add(ML.Repartidor repartidor)
        {
            bool Correct = false;
            try
            {
                using (IvBetoTrackingAndTraceEntities context = new IvBetoTrackingAndTraceEntities())
                {
                    DL.Repartidor auxiliar = new DL.Repartidor();
                    auxiliar.IdRepartidor = repartidor.IdRepartidor;
                    auxiliar.Nombre = repartidor.Nombre;
                    auxiliar.ApellidoPaterno = repartidor.ApellidoPaterno;
                    auxiliar.ApellidoMaterno = repartidor.ApellidoMaterno;
                    auxiliar.Telefono = repartidor.Telefono;
                    auxiliar.FechaIngreso = Convert.ToDateTime(repartidor.FechaIngreso);
                    auxiliar.Fotografia = repartidor.Fotografia;
                    //auxiliar.UnidadEntrega = new DL.UnidadEntrega();
                    auxiliar.IdUnidad = repartidor.UnidadAsignada.IdUnidad;

                    context.Repartidor.Add(auxiliar);
                    context.SaveChanges();
                    Correct = true;
                }
            }catch (Exception e)
            {
                Correct = false;
            }
            return Correct;
        }

        public static bool Update(ML.Repartidor repartidor)
        {
            bool Correct = false;
            try
            {
                using (DL.IvBetoTrackingAndTraceEntities context = new DL.IvBetoTrackingAndTraceEntities())
                {
                    var query = (from i in context.Repartidor
                                 where i.IdRepartidor == repartidor.IdRepartidor
                                 select i).SingleOrDefault();

                    if (query != null)
                    {
                        query.IdRepartidor = repartidor.IdRepartidor;
                        query.Nombre = repartidor.Nombre;
                        query.ApellidoPaterno = repartidor.ApellidoPaterno;
                        query.ApellidoMaterno = repartidor.ApellidoMaterno;
                        query.FechaIngreso = Convert.ToDateTime(repartidor.FechaIngreso);
                        query.Fotografia = repartidor.Fotografia;
                        query.IdUnidad = repartidor.UnidadAsignada.IdUnidad;

                        context.SaveChanges();
                        Correct = true;
                    }
                    else
                    {
                        Correct = false;
                    }
                }
            }   
            catch (Exception e)
            {
                Correct = false;
            }
            return Correct;
        }

        public static bool Delete(ML.Repartidor repartidor)
        {
            bool Correct = false;
            try
            {
                using (DL.IvBetoTrackingAndTraceEntities context = new DL.IvBetoTrackingAndTraceEntities())
                {
                    var query = (from a in context.Repartidor
                                 where a.IdRepartidor == repartidor.IdRepartidor
                                 select a).First();

                    if (query != null)
                    {
                        context.Repartidor.Remove(query);
                        context.SaveChanges();
                        Correct = true;
                    }
                    else
                    {
                        Correct = false;
                    }
                }
            }
            catch (Exception e)
            {
                Correct = false;
            }
            return Correct;
        }

        public static List<ML.Repartidor> GetAll()
        {
            List<ML.Repartidor> Objects = new List<ML.Repartidor>();
            using (DL.IvBetoTrackingAndTraceEntities context = new DL.IvBetoTrackingAndTraceEntities())
            {
                var query = (from a in context.Repartidor
                             join unit in context.UnidadEntrega on a.IdUnidad equals unit.IdUnidad
                             select new
                             {
                                 IdRepartidor = a.IdRepartidor,
                                 Nombre = a.Nombre,
                                 ApellidoPaterno = a.ApellidoPaterno,
                                 ApellidoMaterno = a.ApellidoMaterno,
                                 FechaIngreso = a.FechaIngreso,
                                 Fotografia = a.Fotografia,
                                 Telefono = a.Telefono,
                                 IdUnidad = unit.IdUnidad,
                                 NumeroPlaca = unit.NumeroPlaca
                             });

                if (query != null && query.ToList().Count > 0)
                {
                    foreach (var item in query.ToList())
                    {
                        ML.Repartidor repartidor = new ML.Repartidor();
                        repartidor.UnidadAsignada = new ML.Unidad();

                        repartidor.IdRepartidor = item.IdRepartidor;
                        repartidor.Nombre = item.Nombre;
                        repartidor.ApellidoPaterno = item.ApellidoPaterno;
                        repartidor.ApellidoMaterno = item.ApellidoMaterno;
                        repartidor.FechaIngreso = Convert.ToDateTime(item.FechaIngreso);
                        repartidor.Fotografia = item.Fotografia;
                        repartidor.Telefono = item.Telefono;
                        repartidor.UnidadAsignada.IdUnidad = item.IdUnidad;
                        repartidor.UnidadAsignada.NumeroPlaca = item.NumeroPlaca;

                        Objects.Add(repartidor);
                    }
                }
                else
                {
                    string errorMessage = "No habia repartidores en el sistema";
                }
            }
            return Objects;
        }

        public static ML.Repartidor GetById(int idRepartidor)
        {
            ML.Repartidor result = new ML.Repartidor();
            using (DL.IvBetoTrackingAndTraceEntities context = new DL.IvBetoTrackingAndTraceEntities())
            {
                var query = (from i in context.Repartidor
                             join unit in context.UnidadEntrega on i.IdUnidad equals unit.IdUnidad
                             where i.IdRepartidor == idRepartidor
                             select new
                             {
                                 IdRepartidor = i.IdRepartidor,
                                 Nombre = i.Nombre,
                                 ApellidoPaterno = i.ApellidoPaterno,
                                 ApellidoMaterno = i.ApellidoMaterno,
                                 FechaIngreso = i.FechaIngreso,
                                 Fotografia = i.Fotografia,
                                 Telefono = i.Telefono,
                                 IdUnidad = unit.IdUnidad,
                                 NumeroPlaca = unit.NumeroPlaca
                             }).SingleOrDefault();

                if (query != null)
                {
                    ML.Repartidor repartidor = new ML.Repartidor();
                    repartidor.UnidadAsignada = new ML.Unidad();

                    repartidor.IdRepartidor = query.IdRepartidor;
                    repartidor.Nombre = query.Nombre;
                    repartidor.ApellidoPaterno = query.ApellidoPaterno;
                    repartidor.ApellidoMaterno = query.ApellidoMaterno;
                    repartidor.Telefono = query.Telefono;
                    repartidor.FechaIngreso = Convert.ToDateTime(query.FechaIngreso);
                    repartidor.Fotografia = query.Fotografia;
                    repartidor.UnidadAsignada.IdUnidad = query.IdUnidad;
                    repartidor.UnidadAsignada.NumeroPlaca = query.NumeroPlaca;

                    result = repartidor;
                }
                return result;
            }
        }
    }
}
