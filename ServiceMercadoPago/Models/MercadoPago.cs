using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServiceMercadoPago.Models
{

    public class MercadoPago
    {
        public string action { get; set; }
        public string api_version { get; set; }
        public Data data { get; set; }
        public DateTime date_created { get; set; }
        public long id { get; set; }
        public bool live_mode { get; set; }
        public string type { get; set; }
        public string user_id { get; set; }

      

    }

    public class Data
    {
        public string id { get; set; }
    }


}