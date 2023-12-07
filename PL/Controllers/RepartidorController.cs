using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Configuration;
using System.Web;
using System.Web.Mvc;

namespace PL.Controllers
{
    public class RepartidorController : Controller
    {
        // GET: Repartidor
        [HttpGet]
        public ActionResult GetAllRepartidor()
        {
            ML.Repartidor repart = new ML.Repartidor();
            ServiceReferenceRepartidor.RepartidorClient service = new ServiceReferenceRepartidor.RepartidorClient();
            var objects = service.GetAll();
            repart.Repartidores = objects.ToList();
            //repart.Repartidores = new List<ML.Repartidor>();
            //repart.Repartidores = BL.Repartidor.GetAll();
            return View(repart);
        }

        [HttpGet]
        public ActionResult FormRepartidor(int? idRepartidor)
        {
            ML.Repartidor repartidor = new ML.Repartidor();
            repartidor.IdRepartidor = idRepartidor.Value;
            repartidor.UnidadAsignada = new ML.Unidad();

            ServiceReferenceRepartidor.RepartidorClient service = new ServiceReferenceRepartidor.RepartidorClient();

            repartidor.UnidadAsignada.Unidades = new List<ML.Unidad>();
            if(idRepartidor == 0) //Add
            {
                repartidor.UnidadAsignada.Unidades = BL.Unidad.GetAll();
            }
            else
            {
                ML.Repartidor auxiliar = service.GetById(idRepartidor.Value);
                if(auxiliar != null)
                {
                    repartidor = auxiliar;
                    repartidor.UnidadAsignada.Unidades = BL.Unidad.GetAll();
                }
            }
            
            return View(repartidor);
        }

        [HttpPost]
        public ActionResult FormRepartidor(ML.Repartidor repartidor)
        {
            ServiceReferenceRepartidor.RepartidorClient service = new ServiceReferenceRepartidor.RepartidorClient();
            HttpPostedFileBase file = Request.Files["Imagen"];
            if(file.ContentLength > 0)
            {
                repartidor.Fotografia = ConvertirABase64(file);
            }
            if(repartidor.IdRepartidor == 0) //Add
            {
                bool Correct = service.Add(repartidor);
                if (Correct)
                {
                    ViewBag.Message = "Se ha agregado correctamente el nuevo repartidor";
                }
                else
                {
                    ViewBag.Message = "Ha ocurrido un error al agregar el repartidor";
                }
            }
            else  //Update
            {
                bool Correct = service.Update(repartidor);
                if(Correct)
                {
                    ViewBag.Message = "Se ha actualizado la informacion del repartidor correctamente";
                }
                else
                {
                    ViewBag.Message = "Ha ocurrido un fallo al actualizar el repartidor";
                }
            }
            return PartialView("Modal");
        }

        public ActionResult Delete(int idRepartidor)
        {
            ServiceReferenceRepartidor.RepartidorClient service = new ServiceReferenceRepartidor.RepartidorClient();
            ML.Repartidor repartidor = new ML.Repartidor();
            repartidor.IdRepartidor = idRepartidor;
            bool Correct = service.Delete(repartidor.IdRepartidor);
            if(Correct)
            {
                ViewBag.Message = "Se ha eliminado correctamente el elemento seleccionado";
            }
            else
            {
                ViewBag.Message = "Ha ocurrido un error al momento de eliminar el elemento";
            }
            return PartialView("Modal");
        }

        public string ConvertirABase64(HttpPostedFileBase Foto)
        {
            System.IO.BinaryReader reader = new System.IO.BinaryReader(Foto.InputStream);
            byte[] data = reader.ReadBytes((int)Foto.ContentLength);
            string imagen = Convert.ToBase64String(data);
            return imagen;
        }
    }
}