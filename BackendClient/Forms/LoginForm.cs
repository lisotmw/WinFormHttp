using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BackendClient.Code;
using BackendClient.Code.Util;
using BackendClient.Code.Service.interf;
using BackendClient.Code.Service.abs;
using BackendClient.Code.Support.Bean;
using BackendClient.Code.Service.config;

namespace BackendClient
{
    public partial class LoginForm : Sunny.UI.UIForm, IHttpDelegate
    {
        private LoginService loginService;

        public LoginForm()
        {
            InitializeComponent();
            loginService = new LoginService();
        }

        // TODO liz httpdelegate instance
        public HttpDelegate getHttpDelegate()
        {
            return HttpDelegate.getInstance();
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            // TODO 192.168.101.157:3000
            Config.Set("serverIp", serverAddressText.Text);
            // Test
            string userName = userNameText.Text;
            string password = passwordTextBox.Text;

            userName = "admin";
            password = "123456";

            if(serverAddressText.Text == "")
            {
                MessageBox.Show("please fill serverAddress");
                return;
            }
            if (userName == "")
            {
                MessageBox.Show("please fill userName");
                return;
            }
            if (password == "")
            {
                MessageBox.Show("please fill password");
                return;
            }

            loginService.RequestLoginDelegate<ResBody>(userName, password, getHttpDelegate(),(object res)=> {
                ResBody res0 = (ResBody)res;
                showView(res0);
            });

            //  TODO loading
            //string res = loginService.RequsetLoginAsync(serverAdres, userName, password).Result;
            //var jsonRes = JsonConvert.DeserializeObject<Dictionary<string, Object>>(res);

            //Dictionary<string, string> jsonResData = JsonConvert.DeserializeObject < Dictionary<string, string> > (jsonRes["data"].ToString());
            //string tocken = jsonResData["token"];
            //string userInfoRes = loginService.RequestUserInfoAsync(serverAdres, tocken).Result;
            //Console.WriteLine(userInfoRes);
            //Console.WriteLine(res);
            //MessageBox.Show(userInfoRes);
        }
        private void showView(ResBody res)
        {
            serverAddressText.Text = res.ToString();
        }

    }

   
}
