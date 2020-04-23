using Nest;
using Newtonsoft.Json;
using RestSharp;
using ServiceMercadoPago.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using static ServiceMercadoPago.Models.MercadoPago;

namespace ServiceMercadoPago.Controllers
{
    public class ValuesController : ApiController
    {
        MercadoPago mercado = new MercadoPago();
        // GET api/values
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }   

        
        [AcceptVerbs("POST")]
        [Route("Mpnotification")]
        public IHttpActionResult Mpnotification(MercadoPago mercado,string identificador, int tp)
        {
            int ret = 0;
            try
            {

                if (identificador != null)
                {

                    bool retorno = true;
                        ///ValidaLogin(user, senha);
                    if (retorno)
                    {
                        BuscaPagamento(mercado.data.id,tp);

                        dao.daoNotification ApiDao = new dao.daoNotification();
                       ret =   ApiDao.set_Notification(Convert.ToInt32(identificador), mercado.data.id, mercado.type,tp);
                        return Ok();
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
        public void BuscaPagamento(string cd_transacao,int tp)
        {

            var client = new RestClient("https://api.mercadopago.com/v1/payments/" + cd_transacao.ToString() + "?access_token=TEST-3032679469980340-021220-badbd7c18996ca6faeac8caf7b7206e4-494726291");
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            IRestResponse response = client.Execute(request);
            //string data = response.Content;
            //object myOjbect = JsonConvert.DeserializeObject(data);

            var customerMCP = JsonConvert.DeserializeObject<RetMercado>(response.Content);

            if (customerMCP.status == "approved")
            {
                dao.daoNotification ApiDao = new dao.daoNotification();
                ApiDao.set_Aprovacao(Convert.ToInt32(customerMCP.external_reference), cd_transacao, customerMCP.payment_method_id, customerMCP.transaction_details.total_paid_amount.ToString(), customerMCP.status, customerMCP.installments,tp);
            }
            else
            {
                dao.daoNotification ApiDao = new dao.daoNotification();
                ApiDao.set_Reprovado(Convert.ToInt32(customerMCP.external_reference), cd_transacao, customerMCP.status_detail, customerMCP.transaction_details.total_paid_amount.ToString());
            }

            Console.WriteLine(response.Content);
        }
        // GET api/values/5
        //[AcceptVerbs("POST")]
        //[Route("MpnotificationNNN/{user}/{senha}/{pedido}/{data_id}/{type}")]
        //public IHttpActionResult MpnotificationNNN(string user, string senha, string pedido,string data_id,string type)
        //{
        //    try
        //    {

        //        if (user != null && senha != null && pedido != null)
        //        {

        //            bool retorno = ValidaLogin(user, senha);
        //            if (retorno)
        //            {
        //                dao.daoNotification ApiDao = new dao.daoNotification();
        //                return Ok(ApiDao.set_Notification(Convert.ToInt32(pedido),data_id,type));
        //            }
        //            else
        //            {
        //                return BadRequest("Usuário e senha invalida");
        //            }
        //        }
        //        else
        //        {
        //            return BadRequest("Favor preencher todos os dados");
        //        }
        //    }
        //    catch (Exception ex)
        //    {

        //        return BadRequest(ex.ToString());
        //    }

        //}
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
