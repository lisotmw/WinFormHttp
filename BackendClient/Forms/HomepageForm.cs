using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Sunny.UI;

namespace BackendClient.Forms
{
    public partial class HomepageForm : UIAsideMainFrame
    {
        public HomepageForm()
        {
            InitializeComponent();

            int pageIndex = 1000;
            UIPage pageHome = AddPage(new HomePage(), ++pageIndex);
            TreeNode nodeHome = Aside.CreateNode(pageHome);
            nodeHome.Text = "首页";
            Aside.SetNodeItem(nodeHome, new NavMenuItem(pageHome));
            Aside.SetNodeSymbol(nodeHome, 61818);

            pageIndex = 2000;
            UIPage pageUser = AddPage(new UserManagerPage(), ++pageIndex);
            TreeNode nodeUser = Aside.CreateNode(pageUser);
            nodeUser.Text = "用户管理";
            Aside.SetNodeItem(nodeUser, new NavMenuItem(pageUser));
            Aside.SetNodeSymbol(nodeUser, 61451);

            pageIndex = 3000;
            TreeNode parent = Aside.CreateNode("运维管理", 61950, 24, pageIndex);
            TreeNode nodeMachine = Aside.CreateChildNode(parent, AddPage(new MachineManagePage(), ++pageIndex));
            nodeMachine.Text = "主机管理";
            TreeNode nodeGameServer = Aside.CreateChildNode(parent, AddPage(new GameServerManager(), ++pageIndex));
            nodeGameServer.Text = "游戏服管理";
        }
    }
}
