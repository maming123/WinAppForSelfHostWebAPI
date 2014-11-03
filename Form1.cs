using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Web.Http;
using System.Web.Http.SelfHost;
using System.Windows.Forms;

namespace WinAppForSelfHostWebAPI
{
    public partial class Form1 : Form
    {
        HttpSelfHostServer server =null;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var config = new HttpSelfHostConfiguration(this.txtUrl.Text.Trim());

            config.Routes.MapHttpRoute(
                "API Default", "api/{controller}/{action}/{id}",
                new { id = RouteParameter.Optional });

            server = new HttpSelfHostServer(config);
            
            server.OpenAsync().Wait();
               // Console.WriteLine("Press Enter to quit.");
               // Console.ReadLine();
            //在url中输入：http://maming.fx-func.com:8056/api/products/GetAllProducts
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (server != null)
            {
                server.CloseAsync().Wait();
            }
        }
    }

}
