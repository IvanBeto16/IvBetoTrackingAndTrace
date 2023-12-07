using Microsoft.Ajax.Utilities;
using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PL.Controllers
{
    public class UsuarioController : Controller
    {
        // GET: Usuario
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string email, string password)
        {
            ML.Usuario usuario = new ML.Usuario();
            usuario.Email = email;
            usuario.Password = BL.Usuario.ComputeSHA256(password);
            ML.Usuario auxiliar = BL.Usuario.GetByEmail(email);
            if (auxiliar.Email != email) //Caso incorrecto
            {
                ViewBag.Message = "El correo no existe dentro de la base";
            }
            else //Caso correcto
            {
                Session["tipoUsuario"] = auxiliar.Rol.Tipo;
                return RedirectToAction("Index", "Home");
            }
            return PartialView("Modal");
        }

        //En desuso debido a que se quito el registro de usuarios por login
        [HttpPost]
        public ActionResult Signup(ML.Usuario usuario)
        {
            usuario.Rol = new ML.Rol();
            usuario.Rol.IdRol = 1;
            ML.Usuario result = BL.Usuario.GetByEmail(usuario.Email);
            if (result.Email != usuario.Email)
            {
                bool correct = BL.Usuario.Add(usuario);
                if (correct)
                {
                    ViewBag.Message = "Se ha creado correctamente tu nuevo usuario";
                }
                else
                {
                    ViewBag.Message = "Ha ocurrido un error en la creación de tu usuario";
                }
            }
            return PartialView("Modal");
        }

        [HttpGet]
        public ActionResult GetAll()
        {
            ML.Usuario usuario = new ML.Usuario();
            usuario.Usuarios = new List<ML.Usuario>();
            usuario.Usuarios = BL.Usuario.GetAll();
            return View(usuario);
        }

        [HttpGet]
        public ActionResult Form(int? idUsuario)
        {
            ML.Usuario usuario = new ML.Usuario();
            usuario.Rol = new ML.Rol();
            usuario.Rol.Roles = new List<ML.Rol>();

            if (idUsuario == null || idUsuario == 0) //Add
            {
                usuario.Rol.Roles = BL.Rol.GetAll();
            }
            else  //Update
            {
                ML.Usuario result = BL.Usuario.GetById(idUsuario.Value);
                if (result != null)
                {
                    usuario = result;
                    usuario.Rol.Roles = BL.Rol.GetAll();
                }
            }

            return View(usuario);
        }

        [HttpPost]
        public ActionResult Form(ML.Usuario usuario)
        {

            if (usuario.IdUsuario == 0)  //Add
            {
                bool Correct = BL.Usuario.Add(usuario);
                if (Correct)
                {
                    ViewBag.Message = "Se ha creado y guardado correctamente el nuevo usuario";
                }
            }
            else   //Update
            {
                bool Correct = BL.Usuario.Update(usuario);
                if(Correct)
                {
                    ViewBag.Message = "Se ha actualizado correctamente el usuario seleccionado";
                }
            }
            return PartialView("Modal");
        }
    }
}