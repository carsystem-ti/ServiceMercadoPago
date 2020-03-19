using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace ServiceMercadoPago.dao
{
    public class daoNotification
    {
        ConnectionStringSettings getString = WebConfigurationManager.ConnectionStrings["cnxMaxiPago"] as ConnectionStringSettings;
        public int set_Notification(int id_pedido)
        {
            int retorno = 0;
            DataTable dt_acordo = new DataTable();
            if (getString != null)
            {
                try
                {
                    using (SqlConnection conn = new SqlConnection(getString.ConnectionString))
                    {
                        conn.Open();
                        SqlCommand cmd = new SqlCommand("[Venda].[pro_setNotificationMercadoPago]", conn);
                        cmd.CommandTimeout = 300;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@id_pedido", id_pedido);
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        retorno = cmd.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    throw new global::System.Data.StrongTypingException(ex.ToString(), ex);
                }
            }
            return retorno;
        }
    }
}