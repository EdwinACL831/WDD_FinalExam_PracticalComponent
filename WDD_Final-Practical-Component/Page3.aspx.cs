using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WDD_Final_Practical_Component {
    public partial class Page3 : Page {
        private const string USER_CHOICE_KEY = "userChoice";
        private const string PAGE4_URL = "Page4.aspx";

        protected void Page_Load(object sender, EventArgs e) {
            // as soon as the page is loaded, update the greeting message
            string username = "Edwin";
            Greeting.InnerText = $"Ciao {username}";
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