using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BL;

namespace LBastidaEKSSolution.Controllers
{
    [RoutePrefix("api/login")]
    public class LoginController : ApiController
    {
        [Route("GetById/{email}/{password}")]
        [HttpGet]

        public IHttpActionResult GetByIdEmail(string email, string password)
        {
            Usuario result = BL.Usuario.GetByIdEmail(email, password);
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
        public IHttpActionResult Registrar(Usuario usuario)
        {
            Usuario result = BL.Usuario.Registrar(usuario);
            if (result.Correct)
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
