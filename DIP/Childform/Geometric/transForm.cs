using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DIP
{
    public partial class transForm : Form
    {
        public int X = 0;
        public int Y = 0;
        public bool flag = false;
        public transForm()
        {
            InitializeComponent();
        }
        //按钮：确定
        private void buttonConfirm_Click(object sender, EventArgs e)
        {

            flag = true;
            this.Close();
            
        }
        //按钮：取消
        private void buttonCancel_Click(object sender, EventArgs e)
        {
            //关闭子窗口
            this.Close();
        }
    }
}
