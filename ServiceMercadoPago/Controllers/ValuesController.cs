using ServiceMercadoPago.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ServiceMercadoPago.Controllers
{
    public class ValuesController : ApiController
    {
        // GET api/values
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [AcceptVerbs("POST")]
        [Route("Mpnotification/{user}/{senha}/{pedido}")]
        public IHttpActionResult Mpnotification(string user, string senha, string pedido)
        {
            try
            {

                if (user != null && senha != null && pedido != null)
                {

                    bool retorno = ValidaLogin(user, senha);
                    if (retorno)
                    {
                        dao.daoNotification ApiDao = new dao.daoNotification();
                        return Ok(ApiDao.set_Notification(Convert.ToInt32(pedido)));
                    }
                    else
                    {
                        return BadRequest("Usuário e senha invalida");
                    }
                }
                else
                {
                    return BadRequest("Favor preencher todos os dados");
                }
            }
            catch (Exception ex)
            {

                return BadRequest(ex.ToString());
            }

        }
        private bool ValidaLogin(string ds_usuario, string ds_senha)
        {
            Models.Cliente cliente = new Cliente();
            cliente.wsLogin = System.Web.Configuration.WebConfigurationManager.AppSettings["ds_login"].ToString().ToUpper();
            cliente.ws_Senha = System.Web.Configuration.WebConfigurationManager.AppSettings["ds_senha"].ToString().ToUpper();
            if (ds_usuario.ToUpper() == cliente.wsLogin && ds_senha.ToUpper() == cliente.ws_Senha)
                return true;
            else
                return false;
        }
        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
