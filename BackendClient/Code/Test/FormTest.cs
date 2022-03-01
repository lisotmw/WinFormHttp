using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;


/*
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *                                                 *
 *                                                                                 *
 * Author $zho.li$                                                                 *
 *                                                                                 *
 * Time 2022/2/16 19:54:15                                                                     *
 *                                                                                 *
 * Describe $Used to do something$                                                 *
 *                                                                                 *
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * 
 */
namespace BackendClient.Code.Test
{
    public class FormTest : Form
    {
        private System.Windows.Forms.Timer timer1;
        private System.ComponentModel.IContainer components;

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            this.timer1.Start();
            // 
            // FormTest
            // 
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Name = "FormTest";
            this.ResumeLayout(false);

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Console.WriteLine("lizzzzzzzzzzz: " + Thread.CurrentThread.ManagedThreadId);
            this.timer1.Stop();
        }

        public void Test()
        {
            InitializeComponent();
        }
    }

    
}
