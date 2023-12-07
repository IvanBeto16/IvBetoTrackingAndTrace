using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Unidad
    {
        public static bool Add(ML.Unidad unidad)
        {
            bool result = false;
            try
            {
                using (SqlConnection conexion = new SqlConnection(DL.Conexion.GetConectionString()))
                {
                    //unidad.EstatusUnidad = new ML.EstatusUnidad();
                    string cmd = "UnidadEntregaAdd";
                    SqlCommand query = new SqlCommand(cmd, conexion);
                    query.CommandType = CommandType.StoredProcedure;

                    SqlParameter[] parameters = new SqlParameter[5];
                    parameters[0] = new SqlParameter("@NumeroPlaca", SqlDbType.VarChar);
                    parameters[0].Value = unidad.NumeroPlaca;
                    parameters[1] = new SqlParameter("@Modelo", SqlDbType.VarChar);
                    parameters[1].Value = unidad.Modelo;
                    parameters[2] = new SqlParameter("@Marca", SqlDbType.VarChar);
                    parameters[2].Value = unidad.Marca;
                    parameters[3] = new SqlParameter("@AnioFabricacion", SqlDbType.Int);
                    parameters[3].Value = unidad.AnioFabricacion;
                    parameters[4] = new SqlParameter("@IdEstatus", SqlDbType.Int);
                    parameters[4].Value = unidad.EstatusUnidad.IdEstatus;

                    query.Parameters.AddRange(parameters);
                    query.Connection.Open();
                    int inserciones = query.ExecuteNonQuery();
                    if(inserciones > 0)
                    {
                        result = true;
                    }
                    else
                    {
                        result = false;
                    }
                }
            }
            catch (Exception ex)
            {
                result =false;
            }
            return result;
        }

        public static bool Update(ML.Unidad unidad)
        {
            bool correct = false;
            try
            {
                using (SqlConnection conexion = new SqlConnection(DL.Conexion.GetConectionString()))
                {
                    //unidad.EstatusUnidad = new ML.EstatusUnidad();
                    string cmd = "UnidadEntregaUpdate";
                    SqlCommand query = new SqlCommand(cmd, conexion);
                    query.CommandType = CommandType.StoredProcedure;

                    SqlParameter[] parametros = new SqlParameter[6];
                    parametros[0] = new SqlParameter("@IdUnidad", SqlDbType.Int);
                    parametros[0].Value = unidad.IdUnidad;
                    parametros[1] = new SqlParameter("@NumeroPlaca", SqlDbType.VarChar);
                    parametros[1].Value = unidad.NumeroPlaca;
                    parametros[2] = new SqlParameter("@Modelo", SqlDbType.VarChar);
                    parametros[2].Value = unidad.Modelo;
                    parametros[3] = new SqlParameter("@Marca", SqlDbType.VarChar);
                    parametros[3].Value = unidad.Marca;
                    parametros[4] = new SqlParameter("@AnioFabricacion", SqlDbType.Int);
                    parametros[4].Value = unidad.AnioFabricacion;
                    parametros[5] = new SqlParameter("@IdEstatus", SqlDbType.Int);
                    parametros[5].Value = unidad.EstatusUnidad.IdEstatus;

                    query.Parameters.AddRange(parametros);
                    query.Connection.Open();

                    int cambios = query.ExecuteNonQuery();
                    if(cambios > 0)
                    {
                        correct = true;
                    }
                    else
                    {
                        correct = false;
                    }
                }
            }catch (Exception ex)
            {
                string error = ex.Message;
                correct = false;
            }
            return correct;
        }


        public static bool Delete(ML.Unidad unidad)
        {
            bool correct = false;
            try
            {
                using (SqlConnection conexion = new SqlConnection(DL.Conexion.GetConectionString()))
                {
                    string cmd = "UnidadEntregaDelete";
                    SqlCommand query = new SqlCommand(cmd, conexion);
                    query.CommandType = CommandType.StoredProcedure;

                    SqlParameter[] param = new SqlParameter[1];
                    param[0] = new SqlParameter("@IdUnidad", SqlDbType.Int);
                    param[0].Value = unidad.IdUnidad;

                    query.Parameters.AddRange(param);
                    query.Connection.Open();

                    int eliminaciones = query.ExecuteNonQuery();
                    if (eliminaciones > 0)
                    {
                        correct = true;
                    }
                    else
                    {
                        correct = false;
                    }
                }
            }
            catch (Exception ex)
            {
                correct = false;
            }
            return correct;
        }

        public static List<ML.Unidad> GetAll()
        {
            List<ML.Unidad> Objects = new List<ML.Unidad>();
            using(SqlConnection conexion = new SqlConnection(DL.Conexion.GetConectionString()))
            {
                string cmd = "UnidadEntregaGetAll";
                SqlCommand query = new SqlCommand (cmd, conexion);
                query.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter adapter = new SqlDataAdapter(query);
                DataTable tabla = new DataTable();
                adapter.Fill(tabla);

                if(tabla.Rows.Count > 0)
                {
                    foreach(DataRow row in tabla.Rows)
                    {
                        ML.Unidad unidad = new ML.Unidad();
                        unidad.EstatusUnidad = new ML.EstatusUnidad();
                        unidad.IdUnidad = int.Parse(row[0].ToString());
                        unidad.NumeroPlaca = row[1].ToString();
                        unidad.Modelo = row[2].ToString();
                        unidad.Marca = row[3].ToString();
                        unidad.AnioFabricacion = int.Parse(row[4].ToString());
                        unidad.EstatusUnidad.IdEstatus = int.Parse(row[5].ToString());
                        unidad.EstatusUnidad.Estatus = row[6].ToString();

                        Objects.Add(unidad);
                    }
                }
                else
                {
                    string error = "No se encontraron registros";
                }
                return Objects;
            }
        }

        public static ML.Unidad GetById(ML.Unidad unidad)
        {
            ML.Unidad resultado = new ML.Unidad();
            try
            {
                using (SqlConnection conexion = new SqlConnection(DL.Conexion.GetConectionString()))
                {
                    string cmd = "UnidadEntregaGetById";
                    SqlCommand query = new SqlCommand(cmd, conexion);
                    query.CommandType = CommandType.StoredProcedure;

                    SqlParameter[] param = new SqlParameter[1];
                    param[0] = new SqlParameter("@IdUnidad", SqlDbType.Int);
                    param[0].Value = unidad.IdUnidad;

                    query.Parameters.AddRange(param);

                    SqlDataAdapter adapter = new SqlDataAdapter(query);
                    DataTable table = new DataTable();
                    adapter.Fill(table);

                    if (table.Rows.Count > 0)
                    {
                        DataRow fila = table.Rows[0];
                        ML.Unidad result = new ML.Unidad();
                        result.EstatusUnidad = new ML.EstatusUnidad();

                        result.IdUnidad = int.Parse(fila[0].ToString());
                        result.NumeroPlaca = fila[1].ToString();
                        result.Modelo = fila[2].ToString();
                        result.Marca = fila[3].ToString();
                        result.AnioFabricacion = int.Parse(fila[4].ToString());
                        result.EstatusUnidad.IdEstatus = int.Parse((fila[5].ToString()));
                        result.EstatusUnidad.Estatus = fila[6].ToString();

                        resultado = result;
                    }

                }
            }catch(Exception ex)
            {
                string mensaje = ex.Message;
            }
            return resultado;
        }

    }
}
