using ECPAY.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using ECPay.Payment.Integration;
using System.Web;
using System.Security.Cryptography;
using System.Text;
using System.ComponentModel;

namespace ECPAY.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        
        private string BuildCheckMacValue(string HashKey, string HashIV,string parameters, int encryptType = 0)
        {
            string szCheckMacValue = String.Empty;
            string reshash = String.Empty;
            // 產生檢查碼。
            szCheckMacValue = String.Format("HashKey={0}{1}&HashIV={2}", HashKey, parameters, HashIV);
            szCheckMacValue = HttpUtility.UrlEncode(szCheckMacValue).ToLower();
            if (encryptType == 1)
            {
                using (SHA256 sha256 = SHA256.Create())
                {
                    byte[] hashValue = sha256.ComputeHash(Encoding.UTF8.GetBytes(szCheckMacValue));
                    foreach (byte b in hashValue) {
                        reshash += $"{b:X2}";
                    }
                }
            }
            else
            {
                throw new Exception("please input one at EncryptType");
            }
            return szCheckMacValue;
        }

        [HttpPost]
        public IActionResult CreateOrder([FromBody] ECPayOrderCreateData data) {
            foreach (PropertyDescriptor desc in TypeDescriptor.GetProperties(data)) {
                string name = desc.Name;
                object value = desc.GetValue(data);
                Console.WriteLine("{0}={1}", name, value);
            }


            //Console.WriteLine(data.MerchantID);
            //Console.WriteLine(data.MerchantID);
            //Console.WriteLine(data.MerchantTradeNo);
            //Console.WriteLine(data);
            //using (AllInOne oPayment = new AllInOne()) {
            //    oPayment.ServiceMethod = ECPay.Payment.Integration.HttpMethod.HttpPOST;
            //    oPayment.ServiceURL
            //}
            //return View();
            return Json(data);
        }
        
        public IActionResult OrderReturn() {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}