using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net.Http;


namespace WinAppCallWebAPIClient
{
    public partial class Form1 : Form
    {
        static HttpClient client = new HttpClient();
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ListAllProducts();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ListProduct(1);
        }

         void ListAllProducts()
        {
            HttpResponseMessage resp = client.GetAsync("http://maming.fx-func.com:8056/api/products/GetAllProducts").Result;
            resp.EnsureSuccessStatusCode();

            var products = resp.Content.ReadAsAsync<IEnumerable<WinAppForSelfHostWebAPI.Models.Product>>().Result;
            foreach (var p in products)
            {
                this.richTextBox1.Text +="\r\n"+string.Format("{0} {1} {2} ({3})", p.Id, p.Name, p.Price, p.Category);
            }
        }
         void ListProduct(int id)
         {
             var resp = client.GetAsync(string.Format("http://maming.fx-func.com:8056/api/products/GetProductById/{0}", id)).Result;
             resp.EnsureSuccessStatusCode();

             var product = resp.Content.ReadAsAsync<WinAppForSelfHostWebAPI.Models.Product>().Result;
             this.richTextBox1.Text += "\r\n" + string.Format("ID {0}: {1}", id, product.Name);
         }


    }
}
