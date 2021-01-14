using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NetWorkState
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_MouseClick(object sender, MouseEventArgs e)
        {
            if (checkNet())
            {
                //MessageBox.Show("网络正常！");
                pictureBox1.Image = Properties.Resources.NetLink;
            }
            else
            {
                //MessageBox.Show("网络异常，请检查网络！");
                pictureBox1.Image = Properties.Resources.NetError;
            }
        }

        private bool checkNet()
        {
            try
            {
                System.Net.NetworkInformation.Ping ping = new System.Net.NetworkInformation.Ping();
                System.Net.NetworkInformation.PingReply pr;
                pr = ping.Send("www.baidu.com");
                if (pr.Status == System.Net.NetworkInformation.IPStatus.Success)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }

    }
}
