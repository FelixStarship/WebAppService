using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebAppService
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            ServiceReference2.MyWebServiceSoapClient _client = new ServiceReference2.MyWebServiceSoapClient();
            var int1 = int.Parse(this.TextBox1.Text.Trim());
            var int2 = int.Parse(this.TextBox2.Text.Trim());
            this.TextBox3.Text = _client.Multiplier(int1, int2).ToString();
        }
    }
}