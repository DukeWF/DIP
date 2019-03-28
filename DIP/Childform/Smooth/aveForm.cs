using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DIP.Childform.Smooth
{
    public partial class aveForm : Form
    {
        public bool flag = false;
        public bool color = true;

        public aveForm()
        {
            InitializeComponent();
        }

        private void buttonConfirm_Click(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToInt32(textBox_value.Text) % 2 != 1)
                {
                    MessageBox.Show("请输入奇数值！", "错误提示", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
                else
                {
                    flag = true;
                    this.Close();
                }
            }
            catch(Exception ex)
            {
                //错误提示
                MessageBox.Show(ex.Message, "错误提示", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            flag = false;
            this.Close();
        }

        //黑白图像
        private void radioButton_one_CheckedChanged(object sender, EventArgs e)
        {
            color = false;
        }
        //彩色图像
        private void radioButton_two_CheckedChanged(object sender, EventArgs e)
        {
            color = true;
        }
    }
}
