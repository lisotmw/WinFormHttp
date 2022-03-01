
namespace BackendClient
{
    partial class LoginForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.uiLabel1 = new Sunny.UI.UILabel();
            this.uiLabel2 = new Sunny.UI.UILabel();
            this.uiLabel3 = new Sunny.UI.UILabel();
            this.serverAddressText = new Sunny.UI.UITextBox();
            this.userNameText = new Sunny.UI.UITextBox();
            this.passwordTextBox = new Sunny.UI.UITextBox();
            this.loginButton = new Sunny.UI.UIButton();
            this.exitButton = new Sunny.UI.UIButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.uiLabel4 = new Sunny.UI.UILabel();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // uiLabel1
            // 
            this.uiLabel1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel1.Location = new System.Drawing.Point(25, 31);
            this.uiLabel1.Name = "uiLabel1";
            this.uiLabel1.Size = new System.Drawing.Size(100, 23);
            this.uiLabel1.Style = Sunny.UI.UIStyle.Custom;
            this.uiLabel1.TabIndex = 0;
            this.uiLabel1.Text = "服务器地址";
            this.uiLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // uiLabel2
            // 
            this.uiLabel2.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel2.Location = new System.Drawing.Point(25, 75);
            this.uiLabel2.Name = "uiLabel2";
            this.uiLabel2.Size = new System.Drawing.Size(100, 23);
            this.uiLabel2.Style = Sunny.UI.UIStyle.Custom;
            this.uiLabel2.TabIndex = 1;
            this.uiLabel2.Text = "用户名";
            this.uiLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // uiLabel3
            // 
            this.uiLabel3.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel3.Location = new System.Drawing.Point(25, 118);
            this.uiLabel3.Name = "uiLabel3";
            this.uiLabel3.Size = new System.Drawing.Size(100, 23);
            this.uiLabel3.Style = Sunny.UI.UIStyle.Custom;
            this.uiLabel3.TabIndex = 2;
            this.uiLabel3.Text = "密码";
            this.uiLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // serverAddressText
            // 
            this.serverAddressText.ButtonSymbol = 61761;
            this.serverAddressText.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.serverAddressText.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            this.serverAddressText.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.serverAddressText.Location = new System.Drawing.Point(132, 28);
            this.serverAddressText.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.serverAddressText.Maximum = 2147483647D;
            this.serverAddressText.Minimum = -2147483648D;
            this.serverAddressText.MinimumSize = new System.Drawing.Size(1, 16);
            this.serverAddressText.Name = "serverAddressText";
            this.serverAddressText.Size = new System.Drawing.Size(248, 29);
            this.serverAddressText.Style = Sunny.UI.UIStyle.Custom;
            this.serverAddressText.TabIndex = 3;
            this.serverAddressText.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.serverAddressText.Watermark = "127.0.0.1:10086";
            // 
            // userNameText
            // 
            this.userNameText.ButtonSymbol = 61761;
            this.userNameText.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.userNameText.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            this.userNameText.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.userNameText.Location = new System.Drawing.Point(132, 73);
            this.userNameText.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.userNameText.Maximum = 2147483647D;
            this.userNameText.Minimum = -2147483648D;
            this.userNameText.MinimumSize = new System.Drawing.Size(1, 16);
            this.userNameText.Name = "userNameText";
            this.userNameText.Size = new System.Drawing.Size(248, 29);
            this.userNameText.Style = Sunny.UI.UIStyle.Custom;
            this.userNameText.TabIndex = 4;
            this.userNameText.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // passwordTextBox
            // 
            this.passwordTextBox.ButtonSymbol = 61761;
            this.passwordTextBox.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.passwordTextBox.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            this.passwordTextBox.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.passwordTextBox.Location = new System.Drawing.Point(132, 116);
            this.passwordTextBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.passwordTextBox.Maximum = 2147483647D;
            this.passwordTextBox.Minimum = -2147483648D;
            this.passwordTextBox.MinimumSize = new System.Drawing.Size(1, 16);
            this.passwordTextBox.Name = "passwordTextBox";
            this.passwordTextBox.PasswordChar = '*';
            this.passwordTextBox.Size = new System.Drawing.Size(248, 29);
            this.passwordTextBox.Style = Sunny.UI.UIStyle.Custom;
            this.passwordTextBox.TabIndex = 5;
            this.passwordTextBox.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // loginButton
            // 
            this.loginButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.loginButton.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.loginButton.Location = new System.Drawing.Point(55, 178);
            this.loginButton.MinimumSize = new System.Drawing.Size(1, 1);
            this.loginButton.Name = "loginButton";
            this.loginButton.Size = new System.Drawing.Size(100, 35);
            this.loginButton.TabIndex = 6;
            this.loginButton.Text = "登录";
            this.loginButton.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.loginButton.Click += new System.EventHandler(this.loginButton_Click);
            // 
            // exitButton
            // 
            this.exitButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.exitButton.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.exitButton.Location = new System.Drawing.Point(280, 178);
            this.exitButton.MinimumSize = new System.Drawing.Size(1, 1);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(100, 35);
            this.exitButton.TabIndex = 7;
            this.exitButton.Text = "退出";
            this.exitButton.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.serverAddressText);
            this.groupBox1.Controls.Add(this.exitButton);
            this.groupBox1.Controls.Add(this.uiLabel1);
            this.groupBox1.Controls.Add(this.loginButton);
            this.groupBox1.Controls.Add(this.uiLabel2);
            this.groupBox1.Controls.Add(this.passwordTextBox);
            this.groupBox1.Controls.Add(this.uiLabel3);
            this.groupBox1.Controls.Add(this.userNameText);
            this.groupBox1.Location = new System.Drawing.Point(39, 57);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(409, 232);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            // 
            // uiLabel4
            // 
            this.uiLabel4.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel4.Location = new System.Drawing.Point(444, 291);
            this.uiLabel4.Name = "uiLabel4";
            this.uiLabel4.Size = new System.Drawing.Size(48, 23);
            this.uiLabel4.TabIndex = 9;
            this.uiLabel4.Text = "1.0.0";
            this.uiLabel4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // LoginForm
            // 
            this.ClientSize = new System.Drawing.Size(495, 314);
            this.Controls.Add(this.uiLabel4);
            this.Controls.Add(this.groupBox1);
            this.Name = "LoginForm";
            this.Text = "Game Backend";
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Sunny.UI.UILabel uiLabel1;
        private Sunny.UI.UILabel uiLabel2;
        private Sunny.UI.UILabel uiLabel3;
        private Sunny.UI.UITextBox serverAddressText;
        private Sunny.UI.UITextBox userNameText;
        private Sunny.UI.UITextBox passwordTextBox;
        private Sunny.UI.UIButton loginButton;
        private Sunny.UI.UIButton exitButton;
        private System.Windows.Forms.GroupBox groupBox1;
        private Sunny.UI.UILabel uiLabel4;
    }
}

