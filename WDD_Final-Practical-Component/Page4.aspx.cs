using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WDD_Final_Practical_Component {
    public partial class Page4 : Page {
        private const string USER_CHOICE_KEY = "userChoice";
        private const string FULL_NAME_COOKIES_KEY = "fullname";
        private const string CONFIRM = "confirm";
        private const string CANCEL = "cancel";

        protected void Page_Load(object sender, EventArgs e) {
            // when loaded the page, these have to be done:
            // 1. Fetch the complete name from Cookies
            // 2. Fetch the selection the user did in Page3.aspx from Cookies
            string fullname = null == Request.Cookies[FULL_NAME_COOKIES_KEY] ? 
                                                "TestName" : Request.Cookies[FULL_NAME_COOKIES_KEY].Value;
            string choice = Request.Cookies[USER_CHOICE_KEY].Value;
            
            if (choice.Equals(CONFIRM)) {
                DisplayThankUserMessage($"Thank you {fullname}, you have {choice}ed the order. Our delivery team will head soon to your address!");
            } else if(choice.Equals(CANCEL)) {
                DisplayThankUserMessage($"Thank you {fullname}, you have {choice}led the order. SET Pizza Shop hope to see you back soon!");
            }
            Request.Cookies.Clear();
        }

        private void DisplayThankUserMessage(string userMsg) {
            ThankYouMsg.InnerText = userMsg;
        }
    }
}