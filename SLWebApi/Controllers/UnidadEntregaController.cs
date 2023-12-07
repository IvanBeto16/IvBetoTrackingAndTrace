using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SLWebApi.Controllers
{
    [RoutePrefix("api/UnidadEntrega")]
    public class UnidadEntregaController : ApiController
    {
        [Route("")]
        [HttpGet]
        public IHttpActionResult GetAll()
        {
            ML.Unidad unidad = new ML.Unidad();
            unidad.Unidades = new List<ML.Unidad>();
            unidad.Unidades = BL.Unidad.GetAll();
            //if (unidad.Unidades.Count > 0)
            //{
            //    return Ok(unidad);
            //}
            //else
            //{
            //    return BadRequest();
            //}
            return Ok(unidad);

        }

        [Route("{idUnidad}")]
        [HttpGet]
        public IHttpActionResult GetById(int idUnidad)
        {
            ML.Unidad unidad = new ML.Unidad();
            unidad.IdUnidad = idUnidad;
            ML.Unidad aux = BL.Unidad.GetById(unidad);
            if(aux != null)
            {
                return Ok(aux);
            }
            else
            {
                return BadRequest();
            }

        }

        // POST api/<controller>
        [Route("")]
        [HttpPost]
        public IHttpActionResult Add([FromBody]ML.Unidad unidad)
        {
            bool correct = BL.Unidad.Add(unidad);
            if (correct)
            {
                return Ok(correct);
            }
            else
            {
                return BadRequest("Error en el uso del servicio");
            }
        }

        // PUT api/<controller>/5
        [Route("{idUnidad}")]
        [HttpPut]
        public IHttpActionResult Update(int idUnidad, [FromBody]ML.Unidad unidad)
        {
            bool correct = BL.Unidad.Update(unidad);
            if (correct)
            {
                return Ok(correct);
            }
            else
            {
                return BadRequest();
            }
        }

        // DELETE api/<controller>/5
        [Route("{idUnidad}")]
        [HttpDelete]
        public IHttpActionResult Delete(int idUnidad)
        {
            ML.Unidad unidad = new ML.Unidad();
            unidad.IdUnidad = idUnidad;
            bool correct = BL.Unidad.Delete(unidad);
            if (correct)
            {
                return Ok(correct);
            }
            else
            {
                return BadRequest();
            }
        }
    }
}