using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Formvisible
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_MouseClick(object sender, MouseEventArgs e)
        {
            //隐藏当前窗答口
            this.Visible = false;
            Form2 f2 = new Form2();
            //显示Form2
            f2.ShowDialog();
            //显示当前窗口 
            this.Visible = true;
        }
    }
}
