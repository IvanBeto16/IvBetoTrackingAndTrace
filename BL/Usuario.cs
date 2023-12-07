using System;
using System.Collections.Generic;
using System.Data.Entity.Core.EntityClient;
using System.Data.Entity.Core.Objects;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Usuario
    {
        public static string ComputeSHA256(string s)
        {
            string hash = String.Empty;

            // Initialize a SHA256 hash object
            using (SHA256 sha256 = SHA256.Create())
            {
                // Compute the hash of the given string
                byte[] hashValue = sha256.ComputeHash(Encoding.UTF8.GetBytes(s));

                // Convert the byte array to string format
                foreach (byte b in hashValue)
                {
                    hash += $"{b:X2}";
                }
            }

            return hash;
        }

        public static bool Add(ML.Usuario usuario)
        {
            bool Correct = false;
            try
            {
                using (DL.IvBetoTrackingAndTraceEntities context = new DL.IvBetoTrackingAndTraceEntities())
                {
                    usuario.Password = ComputeSHA256(usuario.Password);
                    ObjectParameter filasInsertadas = new ObjectParameter("filasInsertadas", typeof(int));
                    var query = context.UsuarioAdd(usuario.Username, usuario.Password,
                        usuario.Email, usuario.Nombre, usuario.ApellidoPaterno, usuario.ApellidoMaterno, usuario.Rol.IdRol,
                        filasInsertadas);

                    if (query > 0)
                    {
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
                Correct =false;
            }
            return Correct;
        }


        public static bool Update(ML.Usuario usuario)
        {
            bool Correct = false;
            try
            {
                using (DL.IvBetoTrackingAndTraceEntities context = new DL.IvBetoTrackingAndTraceEntities())
                {
                    usuario.Password = ComputeSHA256(usuario.Password);
                    ObjectParameter filasActualizadas = new ObjectParameter("filasActualizadas", typeof(int));
                    var query = context.UsuarioUpdate(usuario.IdUsuario, usuario.Username, usuario.Password,
                        usuario.Email, usuario.Nombre, usuario.ApellidoPaterno, usuario.ApellidoMaterno,
                        usuario.Rol.IdRol, filasActualizadas);

                    if (query > 0)
                    {
                        Correct = true;
                    }
                    else
                    {
                        Correct = false;
                    }
                }
            }catch (Exception e)
            {
                Correct = false;
            }
            return Correct;
        }

        public static bool Delete(int idUsuario)
        {
            bool Correct = false;
            try
            {
                using (DL.IvBetoTrackingAndTraceEntities context = new DL.IvBetoTrackingAndTraceEntities())
                {
                    ObjectParameter filasEliminadas = new ObjectParameter("filasEliminadas", typeof(int));
                    var query = context.UsuarioDelete(idUsuario, filasEliminadas);
                    if(query > 0)
                    {
                        Correct = true;
                    }
                    else
                    {
                        Correct = false;
                    }
                }
            }catch (Exception e)
            {
                Correct = false;
            }
            return Correct;
        }

        public static List<ML.Usuario> GetAll()
        {
            List<ML.Usuario> Objects = new List<ML.Usuario>();
            try
            {
                using (DL.IvBetoTrackingAndTraceEntities context = new DL.IvBetoTrackingAndTraceEntities())
                {
                    var query = context.UsuarioGetAll();
                    if(query != null)
                    {
                        foreach(var item in query)
                        {
                            ML.Usuario usuario = new ML.Usuario();
                            usuario.Rol = new ML.Rol();
                            usuario.IdUsuario = item.IdUsuario;
                            usuario.Username = item.Username;
                            usuario.Email = item.Email;
                            usuario.Password = item.Password.ToString();
                            usuario.Nombre = item.Nombre;
                            usuario.ApellidoPaterno = item.ApellidoPaterno;
                            usuario.ApellidoMaterno = item.ApellidoMaterno;
                            usuario.Rol.IdRol = item.IdRol;
                            usuario.Rol.Tipo = item.Tipo;

                            Objects.Add(usuario);
                        }
                    }
                }
            }catch (Exception e)
            {
                string msg = e.Message;
            }
            return Objects;
        }

        public static ML.Usuario GetByEmail(string email)
        {
            ML.Usuario result = new ML.Usuario();
            try
            {
                using (DL.IvBetoTrackingAndTraceEntities context = new DL.IvBetoTrackingAndTraceEntities())
                {
                    var query = context.UsuarioGetByEmail(email);
                    if(query != null)
                    {
                        foreach(var entity in query)
                        {
                            ML.Usuario usuario = new ML.Usuario();
                            usuario.Rol = new ML.Rol();

                            usuario.IdUsuario = entity.IdUsuario;
                            usuario.Username = entity.Username;
                            usuario.Email = entity.Email;
                            usuario.Password = entity.Password.ToString();
                            usuario.Nombre = entity.Nombre;
                            usuario.ApellidoPaterno = entity.ApellidoPaterno;
                            usuario.ApellidoMaterno = entity.ApellidoMaterno;
                            usuario.Rol.IdRol = entity.IdRol;
                            usuario.Rol.Tipo = entity.Tipo;

                            result = usuario;
                        }
                    }
                }
            }catch (Exception e)
            {
                string msg = e.Message;
            }
            return result;
        }

        public static ML.Usuario GetById(int idUsuario)
        {
            ML.Usuario result = new ML.Usuario();
            using (DL.IvBetoTrackingAndTraceEntities context = new DL.IvBetoTrackingAndTraceEntities())
            {
                var query = context.UsuarioGetById(idUsuario);
                if(query != null)
                {
                    foreach(var entity in query)
                    {
                        ML.Usuario usuario = new ML.Usuario();
                        usuario.Rol = new ML.Rol();

                        usuario.IdUsuario = entity.IdUsuario;
                        usuario.Nombre = entity.Nombre;
                        usuario.ApellidoPaterno = entity.ApellidoPaterno;
                        usuario.ApellidoMaterno = entity.ApellidoMaterno;
                        usuario.Username = entity.Username;
                        usuario.Email = entity.Email;
                        usuario.Password = entity.Password.ToString();
                        usuario.Rol.IdRol = entity.IdRol;
                        usuario.Rol.Tipo = entity.Tipo;

                        result = usuario;
                    }
                }
                return result;
            }
        }
    }
}
