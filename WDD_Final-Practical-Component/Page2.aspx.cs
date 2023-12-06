using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WDD_Final_Practical_Component
{
    public partial class page2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void Select_topping(object sender, EventArgs e)
        {
            Price.Text = "ss";
            
        }
        public static string TestMethod()
        {
            return "Message sent to the server!";
        }
    }
}