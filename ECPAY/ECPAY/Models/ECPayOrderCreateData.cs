using System.ComponentModel.DataAnnotations;

namespace ECPAY.Models
{
    public class ECPayOrderCreateData
    {
        [Required]
        public string? MerchantID { get; set; }
        public string? MerchantTradeNo { get; set; }
        public DateTime MerchantTradeDate { get; set; }
        public string? PaymentType { get; set; }
        public int TotalAmount { get; set; }
        public string? TradeDesc { get; set; }
        public string? ItemName { get; set; }
        public string? ReturnURL { get; set; }
        public string? ChoosePayment { get; set; }
        public int? EncryptType { get; set; }
        public string? CheckMacValue { get; set; }
    }
}
