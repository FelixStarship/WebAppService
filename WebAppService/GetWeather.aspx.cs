using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebAppService
{
    public partial class GetWeather : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Weather.WeatherWebService client = new Weather.WeatherWebService();
            var s = client.getWeatherbyCityName(this.TextBox1.Text.Trim());
            if (s[8] == "")
            {
                this.Label1.Text = "暂时不支持你查询的城市!";
            }
            else
            {
                string ImgUrl = @"/weather/weather/"+s[8];
                string General = s[1] + "   " + s[6];
                string Actually = s[10];
                this.Label2.Text = Actually;
                this.Image1.ImageUrl = ImgUrl;
                this.Label3.Text = General;
            }
        }
    }
}