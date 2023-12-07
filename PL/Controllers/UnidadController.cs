using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace PL.Controllers
{
    public class UnidadController : Controller
    {
        // GET: Unidad
        public ActionResult GetAllUnidad()
        {
            ML.Unidad unidad = new ML.Unidad();
            unidad.Unidades = new List<ML.Unidad>();
            //unidad.Unidades = BL.Unidad.GetAll();

            //Usando los servicios REST
            using(var client = new HttpClient())
            {
                client.BaseAddress = new Uri(ConfigurationManager.AppSettings["WebApi"]);
                var responseTask = client.GetAsync(client.BaseAddress);
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<ML.Unidad>();
                    readTask.Wait();
                    foreach( var item in readTask.Result.Unidades)
                    {
                        ML.Unidad unit = new ML.Unidad();
                        unit.IdUnidad = item.IdUnidad;
                        unit.NumeroPlaca = item.NumeroPlaca;
                        unit.Marca = item.Marca;
                        unit.Modelo = item.Modelo;
                        unit.AnioFabricacion = item.AnioFabricacion;
                        unit.EstatusUnidad = new ML.EstatusUnidad();
                        unit.EstatusUnidad.IdEstatus = item.EstatusUnidad.IdEstatus;
                        unit.EstatusUnidad.Estatus = item.EstatusUnidad.Estatus;

                        unidad.Unidades.Add(unit);
                    }
                }
            }

            return View(unidad);
        }

        [System.Web.Mvc.HttpGet]
        public ActionResult FormUnidad(int idUnidad)
        {
            ML.Unidad unidad = new ML.Unidad();
            unidad.IdUnidad = idUnidad;
            unidad.EstatusUnidad = new ML.EstatusUnidad();
            unidad.EstatusUnidad.Estados = new List<ML.EstatusUnidad>();

            if(idUnidad == 0) //Add
            {
                unidad.EstatusUnidad.Estados = BL.EstatusUnidad.GetAll();
            }
            else  //Update
            {
                //ML.Unidad result = BL.Unidad.GetById(unidad);
                //if(result != null)
                //{
                //    unidad = result;

                //}

                //Usando los servicios REST
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(ConfigurationManager.AppSettings["WebApi"]);
                    var responseTask = client.GetAsync(client.BaseAddress + $"{idUnidad}");
                    responseTask.Wait();

                    var result = responseTask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        var readTask = result.Content.ReadAsAsync<ML.Unidad>();
                        readTask.Wait();

                        ML.Unidad resultUnidad = new ML.Unidad();
                        resultUnidad.IdUnidad = readTask.Result.IdUnidad;
                        resultUnidad.NumeroPlaca = readTask.Result.NumeroPlaca;
                        resultUnidad.Marca = readTask.Result.Marca;
                        resultUnidad.Modelo = readTask.Result.Modelo;
                        resultUnidad.AnioFabricacion = readTask.Result.AnioFabricacion;
                        resultUnidad.EstatusUnidad = new ML.EstatusUnidad();
                        resultUnidad.EstatusUnidad.IdEstatus = readTask.Result.EstatusUnidad.IdEstatus;
                        resultUnidad.EstatusUnidad.Estatus = readTask.Result.EstatusUnidad.Estatus;

                        unidad = resultUnidad;
                        unidad.EstatusUnidad.Estados = BL.EstatusUnidad.GetAll();
                    }
                }
            }
            return View(unidad);
        }

        [System.Web.Http.HttpPost]
        public ActionResult FormUnidad(ML.Unidad unidad)
        {
            if (unidad.IdUnidad == 0)   //Add
            {
                //bool correct = BL.Unidad.Add(unidad);
                //Usando el servicio de REST
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(ConfigurationManager.AppSettings["WebApi"]);
                    var responseTask = client.PostAsJsonAsync<ML.Unidad>(client.BaseAddress, unidad);
                    responseTask.Wait();

                    var correct = responseTask.Result;
                    if (correct.IsSuccessStatusCode)
                    {
                        ViewBag.Message = "Se ha registrado correctamente la unidad nueva";
                    }
                    else
                    {
                        ViewBag.Message = "Ha ocurrido un error con la nueva unidad";
                    }
                }
            }
            else
            {
                //bool correct = BL.Unidad.Update(unidad);
                //Usando el servicio de REST
                using(var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(ConfigurationManager.AppSettings["WebApi"]);
                    var responseTask = client.PutAsJsonAsync<ML.Unidad>(client.BaseAddress + $"{unidad.IdUnidad}", unidad);
                    responseTask.Wait();

                    var correct = responseTask.Result;
                    if (correct.IsSuccessStatusCode)
                    {
                        ViewBag.Message = "Se ha actualizado la informacion de la unidad correctamente";
                    }
                    else
                    {
                        ViewBag.Message = "Ha ocurrido un error en la actualización de la unidad";
                    }
                }
            }

            return PartialView("Modal");
        }

        [System.Web.Mvc.HttpDelete]
        public ActionResult Delete(int idUnidad)
        {
            ML.Unidad unidad = new ML.Unidad();
            unidad.IdUnidad = idUnidad;

            //Usando los servicios REST 
            using (var cliente = new HttpClient())
            {
                cliente.BaseAddress = new Uri(ConfigurationManager.AppSettings["WebApi"]);
                var responseTask = cliente.DeleteAsync(cliente.BaseAddress + $"{idUnidad}");
                responseTask.Wait();

                var deleteTask = responseTask.Result;
                if (deleteTask.IsSuccessStatusCode)
                {
                    ViewBag.Message = "Se ha eliminado correctamente la unidad seleccionada";
                }
                else
                {
                    ViewBag.Message = "Ha ocurrido un error que impide eliminar la unidad seleccionada";
                }
            }
            return PartialView("Modal");
        }
    }
}