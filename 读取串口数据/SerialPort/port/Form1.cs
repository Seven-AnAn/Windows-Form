using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace port
{
    public partial class Form1 : Form
    {
        SerialPort serialPort1 = new SerialPort("COM3", 9600, Parity.None, 8, StopBits.One);      //初始化串口设置  
        public delegate void Displaydelegate(byte[] InputBuf);
        Byte[] OutputBuf = new Byte[128];
        public Displaydelegate disp_delegate;

        public Form1()
        {
            disp_delegate = new Displaydelegate(DispUI);
            serialPort1.DataReceived += new SerialDataReceivedEventHandler(Comm_DataReceived);

            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (button1.Text == "打开")
                {
                    serialPort1.Open();
                    button1.Text = "关闭";
                }
                else
                {
                    serialPort1.Close();
                    button1.Text = "打开";
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "错误提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
        void Comm_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {

            Byte[] InputBuf = new Byte[512];

            try
            {
                serialPort1.Read(InputBuf, 0, serialPort1.BytesToRead);                                //读取缓冲区的数据直到“}”即0x7D为结束符  
                //InputBuf = UnicodeEncoding.Default.GetBytes(strRD);             //将得到的数据转换成byte的格式  
                System.Threading.Thread.Sleep(50);
                this.Invoke(disp_delegate, InputBuf);

            }
            catch (TimeoutException ex)         //超时处理  
            {
                MessageBox.Show(ex.ToString());
            }
        }
        public void DispUI(byte[] InputBuf)
        {
            //textBox1.Text = Convert.ToString(InputBuf);  

            ASCIIEncoding encoding = new ASCIIEncoding();
            richTextBox1.Text = encoding.GetString(InputBuf);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            serialPort1.Write("change");
        }

    }
}
