
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServiceMercadoPago.Models
{

    public class RetMercado
    {
        public object acquirer { get; set; }
        public object[] acquirer_reconciliation { get; set; }
        public Additional_Info additional_info { get; set; }
        public object authorization_code { get; set; }
        public bool binary_mode { get; set; }
        public object call_for_authorize_id { get; set; }
        public bool captured { get; set; }
        public Card card { get; set; }
        public int? collector_id { get; set; }
        public object corporation_id { get; set; }
        public object counter_currency { get; set; }
        public int? coupon_amount { get; set; }
        public string currency_id { get; set; }

        public object date_approved { get; set; }
        public DateTime date_created { get; set; }
        public DateTime date_last_updated { get; set; }
        public object date_of_expiration { get; set; }
        public string deduction_schema { get; set; }
        public string description { get; set; }
        public int? differential_pricing_id { get; set; }
        public string external_reference { get; set; }
        public object[] fee_details { get; set; }
        public int? id { get; set; }
        public int? installments { get; set; }
        public object integrator_id { get; set; }
        public string issuer_id { get; set; }
        public bool live_mode { get; set; }
        public object marketplace_owner { get; set; }
        public object merchant_account_id { get; set; }
        public object merchant_number { get; set; }
        public Metadata metadata { get; set; }
        public object money_release_date { get; set; }
        public object money_release_schema { get; set; }
        public string notification_url { get; set; }
        public string operation_type { get; set; }
        public Order order { get; set; }
        public Payer payer { get; set; }
        public string payment_method_id { get; set; }
        public string payment_type_id { get; set; }
        public object platform_id { get; set; }
        public object pos_id { get; set; }
        public string processing_mode { get; set; }
        public object[] refunds { get; set; }
        public int? shipping_amount { get; set; }
        public object sponsor_id { get; set; }
        public string statement_descriptor { get; set; }
        public string status { get; set; }
        public string status_detail { get; set; }
        public object store_id { get; set; }
        public int? taxes_amount { get; set; }
        public int? transaction_amount { get; set; }
        public int? transaction_amount_refunded { get; set; }
        public Transaction_Details transaction_details { get; set; }
    }

    public class Additional_Info
    {
        public object available_balance { get; set; }
        public string ip_address { get; set; }
        public object nsu_processadora { get; set; }
    }

    public class Card
    {
        public Cardholder cardholder { get; set; }
        public DateTime date_created { get; set; }
        public DateTime date_last_updated { get; set; }
        public int? expiration_month { get; set; }
        public int? expiration_year { get; set; }
        public string first_six_digits { get; set; }
        public object id { get; set; }
        public string last_four_digits { get; set; }
    }

    public class Cardholder
    {
        public Identification identification { get; set; }
        public string name { get; set; }
    }

    public class Identification
    {
        public string number { get; set; }
        public string type { get; set; }
    }

    public class Metadata
    {
    }

    public class Order
    {
        public string id { get; set; }
        public string type { get; set; }
    }

    public class Payer
    {
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string email { get; set; }
        public Identification1 identification { get; set; }
        public Phone phone { get; set; }
        public string type { get; set; }
        public object entity_type { get; set; }
        public string id { get; set; }
    }

    public class Identification1
    {
        public string number { get; set; }
        public string type { get; set; }
    }

    public class Phone
    {
        public string area_code { get; set; }
        public string number { get; set; }
        public string extension { get; set; }
    }

    public class Transaction_Details
    {
        public object acquirer_reference { get; set; }
        public object external_resource_url { get; set; }
        public object financial_institution { get; set; }
        public int? installment_amount { get; set; }
        public string  net_received_amount { get; set; }
        public int? overpaid_amount { get; set; }
        public object payable_deferral_period { get; set; }
        public object payment_method_reference_id { get; set; }
        public int? total_paid_amount { get; set; }
    }

}