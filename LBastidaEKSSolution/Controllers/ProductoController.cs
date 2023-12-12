using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BL;

namespace LBastidaEKSSolution.Controllers
{
    [RoutePrefix("api/producto")]
    public class ProductoController : ApiController
    {
        [Route("")]
        [HttpGet]
        public IHttpActionResult  GetAll()
        {
            Producto result = BL.Producto.GetAll();
            if (result.Correct)
            {
                return Content(HttpStatusCode.OK, result);
            }
            else
            {
                return Content(HttpStatusCode.BadRequest, result);
            }
        }

        [Route("{IdProducto}")]
        [HttpGet]
        public IHttpActionResult GetById(int IdProducto)
        {
            Producto result = BL.Producto.GetById(IdProducto);
            if (result.Correct)
            {
                return Content(HttpStatusCode.OK, result);
            }
            else
            {
                return Content(HttpStatusCode.BadRequest, result);
            }
        }

        [Route("")]
        [HttpPost]
        public IHttpActionResult Add(Producto producto)
        {
            bool result = BL.Producto.Add(producto);
            if (result)
            {
                return Content(HttpStatusCode.OK, result);
            }
            else
            {
                return Content(HttpStatusCode.BadRequest, result);
            }

        }

        [Route("{IdProducto}")]
        [HttpDelete]
        public IHttpActionResult Delete(int IdProducto)
        {
            bool result = BL.Producto.Delete(IdProducto);
            if (result)
            {
                return Content(HttpStatusCode.OK, result);
            }
            else
            {
                return Content(HttpStatusCode.BadRequest, result);
            }
        }

        [Route("{IdProducto}")]
        [HttpPut]
        public IHttpActionResult Update(int IdProducto, [FromBody] Producto producto)
        {
            producto.IdProducto = IdProducto;

            bool result = BL.Producto.Update(producto);
            if (result)
            {
                return Content(HttpStatusCode.OK, result);
            }
            else
            {
                return Content(HttpStatusCode.BadRequest, result);
            }
        }
    }
}
