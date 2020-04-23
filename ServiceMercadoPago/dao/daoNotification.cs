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
        public int set_Notification(int id_pedido,string data_id,string type,int tipo)
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
                        SqlCommand cmd = new SqlCommand("[MercadoPago].[pro_setNotification]", conn);
                        cmd.CommandTimeout = 300;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@identificador", id_pedido);
                        cmd.Parameters.AddWithValue("@data_id", data_id);
                        cmd.Parameters.AddWithValue("@type", type);

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
        public int set_Aprovacao(int id_pedido, string data_id, string ds_bandeira,string valor,string status,int? parcela,int tipo)
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
                        SqlCommand cmd = new SqlCommand("[MercadoPago].[pro_setFinalizaProcess]", conn);
                        cmd.CommandTimeout = 300;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@id_identificador", id_pedido);
                        cmd.Parameters.AddWithValue("@vl_aprovado", valor);
                        cmd.Parameters.AddWithValue("@nr_parcela", parcela);
                        cmd.Parameters.AddWithValue("@authorizationcode", data_id);
                        cmd.Parameters.AddWithValue("@orderid", data_id);
                        cmd.Parameters.AddWithValue("@processorreferencenumber", data_id);
                        cmd.Parameters.AddWithValue("@processortransactionid", data_id);
                        cmd.Parameters.AddWithValue("@ds_bandeira", ds_bandeira);
                        cmd.Parameters.AddWithValue("@tipo", tipo);

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
        public int set_Reprovado(int id_pedido, string data_id, string motivo, string valor)
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
                        SqlCommand cmd = new SqlCommand("[TEF].[pro_setLogTransacao]", conn);
                        cmd.CommandTimeout = 300;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@codigoCartao", data_id);
                        cmd.Parameters.AddWithValue("@motivo", motivo);
                        cmd.Parameters.AddWithValue("@numeroEvento", id_pedido);
                        cmd.Parameters.AddWithValue("@valorTransacao", valor);
                        cmd.Parameters.AddWithValue("@processorID", 0);
                        cmd.Parameters.AddWithValue("@idTransacao", 0);
                        cmd.Parameters.AddWithValue("@processorTransaction", 0);

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