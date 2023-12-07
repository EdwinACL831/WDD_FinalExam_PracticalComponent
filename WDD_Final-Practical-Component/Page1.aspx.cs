using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace WDD_Final_Practical_Component
{
    public partial class Page1 : Page
    {
        private const int EXPECTED_NUMBER_OF_WORDS = 2;
        private const string PAGE2_URL = "Page2.aspx";
        private const string FULL_NAME_COOKIES_KEY = "fullname";
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void NextBtn_Click(object sender, EventArgs e)
        {
            // validate that:
            // The input box isn't empty
            // only alphabetic letters

            string fullName = FullName.Value;
            if (string.IsNullOrEmpty(fullName))
            {
                // write to the user the error
                FeedBack.InnerHtml = "*This field cannot be empty";
                return;
            }

            int result = CheckNameFormat(fullName);
            switch (result)
            {
                case 0:
                    FeedBack.InnerHtml = "";
                    Response.Cookies[FULL_NAME_COOKIES_KEY].Value = fullName;
                    Response.Cookies[FULL_NAME_COOKIES_KEY].Expires = DateTime.Now.AddHours(1);
                    Response.Redirect(PAGE2_URL);
                    break;
                case 1:
                    FeedBack.InnerHtml = "*Please, type First and Last name separated by a space";
                    break;
                case 2:
                    FeedBack.InnerHtml = "*First name can only contain letters (i.e. Sally)";
                    break;
                case 3:
                    FeedBack.InnerHtml = "*Last name can only contain letters (i.e. Smith)";
                    break;
                default:
                    FeedBack.InnerHtml = "";
                    break;
            }
        }

        private int CheckNameFormat(string fullName)
        {
            // get the first and last name by separate
            // check that we fetched ONLY 2 words   ->  First name and Last name
            string[] nameCollection = fullName.Split(' ');
            if (nameCollection.Length != EXPECTED_NUMBER_OF_WORDS)
            {
                return 1;
            }

            string firstName = nameCollection[0];
            string lastName = nameCollection[1];

            if (!firstName.All(Char.IsLetter))
            {
                return 2;
            }
            else if (!lastName.All(Char.IsLetter))
            {
                return 3;
            }
            else
            {
                return 0;
            }
        }
    }
}