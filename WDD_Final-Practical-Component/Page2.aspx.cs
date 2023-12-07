using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Services.Description;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WDD_Final_Practical_Component
{
  

    public partial class page2 : System.Web.UI.Page
    {
        private double totalPrice;
        private const string TOTAL_PRICE_COOKIES_KEY = "total_price";
        private const string FULL_NAME_COOKIES_KEY = "fullname";
        private const string PAGE3_URL = "Page3.aspx";

        protected void Page_Load(object sender, EventArgs e)
        {
            // get user name and display here
            string fullName = Request.Cookies[FULL_NAME_COOKIES_KEY].Value;
            string[] nameCollection = fullName.Split(' ');
            userName.Text = nameCollection[0];
            totalPrice = 10.0;
            //Price.Text = "10.0";
        }


        [WebMethod]
        public static string TestMethod(string currentPrice, string price, bool status)
        {
            double.TryParse(currentPrice, out double totalPrice);
            double.TryParse(price, out double toppingPrice);
            if (status) // true -> +
            { totalPrice += toppingPrice; }
            else { totalPrice -= toppingPrice; }


            // pepperoni, mushrooms, green olives, green peppers and double cheese
            // bool array[] = [true, false, false, true, true]

            return JsonConvert.SerializeObject(new { totalPrice = totalPrice });
        }

        protected void NextBtn_Click(object sender, EventArgs e)
        {
            Response.Cookies[TOTAL_PRICE_COOKIES_KEY].Value = Price.InnerText;
            Response.Cookies[TOTAL_PRICE_COOKIES_KEY].Expires = DateTime.Now.AddHours(1);
            Response.Redirect(PAGE3_URL);
        }
    }
}