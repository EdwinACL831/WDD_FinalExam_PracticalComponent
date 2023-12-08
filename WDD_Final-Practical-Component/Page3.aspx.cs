using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WDD_Final_Practical_Component {
    public partial class Page3 : Page {
        private const string USER_CHOICE_KEY = "userChoice";
        private const string FULL_NAME_COOKIES_KEY = "fullname";
        private const string ADDED_TOPPINGS = "addedToppings";
        private const string PAGE4_URL = "Page4.aspx";
        private const string TOTAL_PRICE_COOKIES_KEY = "total_price";

        protected void Page_Load(object sender, EventArgs e) {
            // as soon as the page is loaded, update the greeting message
            string fullname = Request.Cookies[FULL_NAME_COOKIES_KEY].Value;
            string username = fullname.Split(' ')[0];
            Greeting.InnerText = $"Ciao {username}";

            // dynamically build the order summary
            string addedtoppingsStr = Request.Cookies[ADDED_TOPPINGS].Value;
            string innerHTML = BuildOrderSummary(addedtoppingsStr);
            OrderSummary.InnerHtml = innerHTML;
        }

        private string BuildOrderSummary(string addedtoppingsStr) {
            StringBuilder innerHTML = new StringBuilder();
            innerHTML.Append("<p>Cheese and Sauce (always included)....$10.00</p>");

            if (string.IsNullOrEmpty(addedtoppingsStr)) {
                innerHTML.Append("<p>No additional toppings</p>");
            } else {
                string[] toopingCouples = addedtoppingsStr.Split(' ');

                foreach (string toppingCouple in toopingCouples) {
                    string toppingName = toppingCouple.Split('=')[0].Replace('_', ' ');
                    string toppingPrice = toppingCouple.Split('=')[1];
                    innerHTML.Append($"<p>{toppingName}....${toppingPrice}</p>");
                }
            }
            innerHTML.Append($"Total Price: ${Request.Cookies[TOTAL_PRICE_COOKIES_KEY].Value}");

            return innerHTML.ToString();
        }

        protected void Confirm_Click(object sender, EventArgs e) {
            // here we have to save the confirm option and redirect to the final page (Page4)
            SaveCookie(USER_CHOICE_KEY, "confirm");
            RedirectToNextPage(PAGE4_URL);
        }

        protected void Cancel_Click(object sender, EventArgs e) {
            SaveCookie(USER_CHOICE_KEY, "cancel");
            RedirectToNextPage(PAGE4_URL);
        }

        private void RedirectToNextPage(string nextPage) {
            Response.Redirect(nextPage);
        }

        private void SaveCookie(string key, string value) {
            Response.Cookies[key].Value = value;
            Response.Cookies[key].Expires = DateTime.Now.AddHours(1);
        }
    }
}