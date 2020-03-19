using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServiceMercadoPago.Models
{
    public class Cliente
    {
        public string wsLogin;
        public string ws_Senha;


        public Cliente()
        {
            this.WsLogin = wsLogin;
            this.Ws_Senha = ws_Senha;
        }

        public string WsLogin
        {
            get { return wsLogin; }
            set { wsLogin = value; }
        }


        public string Ws_Senha
        {
            get { return ws_Senha; }
            set { ws_Senha = value; }
        }
    }
}