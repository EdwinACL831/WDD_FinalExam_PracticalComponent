using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Services;
using System.Web.Services.Description;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WDD_Final_Practical_Component
{
    public partial class page2 : Page
    {
        private const string TOTAL_PRICE_COOKIES_KEY = "total_price";
        private const string FULL_NAME_COOKIES_KEY = "fullname";
        private const string ADDED_TOPPINGS = "addedToppings";
        private const string PAGE3_URL = "Page3.aspx";

        protected void Page_Load(object sender, EventArgs e)
        {
            // get user name and display here
            string fullName = Request.Cookies[FULL_NAME_COOKIES_KEY].Value;
            string[] nameCollection = fullName.Split(' ');
            userName.Text = nameCollection[0];
        }


        [WebMethod]
        public static string ProcessToppingPrice(string currentPrice, string price, bool status)
        {
            double.TryParse(currentPrice, out double totalPrice);
            double.TryParse(price, out double toppingPrice);

            // true -> adds
            if (status) { 
                totalPrice += toppingPrice;
            }
            else { 
                totalPrice -= toppingPrice;
            }

            return JsonConvert.SerializeObject(new { totalPrice = totalPrice });
        }

        protected void NextBtn_Click(object sender, EventArgs e)
        {
            ListItemCollection items = Toppings_Options.Items;
            string selectedToppingsString = BuildSelectedToppingsString(items);
            SaveCookie(ADDED_TOPPINGS, selectedToppingsString);
            SaveCookie(TOTAL_PRICE_COOKIES_KEY, Price.InnerText);
            Response.Redirect(PAGE3_URL);
        }

        private string BuildSelectedToppingsString(ListItemCollection items) {
            StringBuilder sb = new StringBuilder();

            foreach (ListItem item in items) {
                if (item.Selected) {
                    sb.Append(item.Text.Replace(' ', '_'));
                    sb.Append("=");
                    sb.Append(item.Value);
                    sb.Append(" ");
                }
            }

            return sb.ToString().Trim();
        }

        private void SaveCookie(string key, string value) {
            Response.Cookies[key].Value = value;
            Response.Cookies[key].Expires = DateTime.Now.AddHours(1);
        }
    }
}