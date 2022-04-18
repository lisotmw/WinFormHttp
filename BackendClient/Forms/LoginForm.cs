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

        //返回数据：{"code":0,"message":"success","data":{"token":"Bearer e86585728b914771b793f1fb05e49676","ref0":"ae213e3e-baa6-4379-928a-5f3692e0ffd6"}}
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

            loginService.RequestLoginDelegate<LoginResBody>(userName, password,(object res)=> {
                LoginResBody res0 = (LoginResBody)res;
                Config.Set("token", res0.Data.token);
                showView(res0);
            });

        }
        private void showView(LoginResBody res)
        {
            serverAddressText.Text = res.ToString();
        }

    }

   
}
