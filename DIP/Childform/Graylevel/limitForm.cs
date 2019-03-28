using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DIP.Childform.Graylevel
{
    public partial class limitForm : Form
    {
        public bool flag = false;
        public int value = 1;

        public limitForm()
        {
            InitializeComponent();
        }

        private void buttonConfirm_Click(object sender, EventArgs e)
        {
            flag = true;
            this.Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //选择固定阈值：隐藏参数2
        private void radioButton_one_CheckedChanged(object sender, EventArgs e)
        {
            value = 1;
            labelb.Visible = false;
            textBoxb.Visible = false;
            groupBox_double_method.Visible = false;
        }
        //选择双固定阈值：显示参数2
        private void radioButton_two_CheckedChanged(object sender, EventArgs e)
        {
            value = 2;
            labelb.Visible = true;
            textBoxb.Visible = true;
            groupBox_double_method.Visible = true;
        }
    }
}
