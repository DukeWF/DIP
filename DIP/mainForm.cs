using DIP.Childform;
using DIP.Childform.Graylevel;
using DIP.Childform.Smooth;
using DIP.Public;
using CCS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DIP.Childform.Help;

namespace DIP
{
    public partial class mainForm : Form
    {

        //定义：文件名
        private string curFileName;
        //定义：Bitmap对象
        private Bitmap opeBitmap = null;//原始图像（左）
        private Bitmap curBitmap = null;//当前图像（右）
        private Bitmap objBitmap = null;//操作图像
        //定义：其他变量
        private Rectangle cursize = new Rectangle(0, 0, 0, 0);//获取图片显示尺寸
        int width, height;


        /// <summary>
        /// 获取PictureBox在Zoom下显示的位置和大小
        /// </summary>
        /// <param name="p_PictureBox">Picture 如果没有图形或则非ZOOM模式 返回的是PictureBox的大小</param>
        /// <returns>如果p_PictureBox为null 返回 Rectangle(0, 0, 0, 0)</returns>
        public Rectangle GetPictureBoxZoomSize(PictureBox p_PictureBox)
        {
            if (p_PictureBox != null)
            {
                PropertyInfo _ImageRectanglePropert = p_PictureBox.GetType().GetProperty("ImageRectangle", BindingFlags.Instance | BindingFlags.NonPublic);

                return (Rectangle)_ImageRectanglePropert.GetValue(p_PictureBox, null);
            }
            return new Rectangle(0, 0, 0, 0);
        }

        //主窗体：加载
        public mainForm()
        {
            InitializeComponent();
        }

        //主窗体：关闭动作
        private void mainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("确认退出？", "退出", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                e.Cancel = false;
            }
            else
            {
                e.Cancel = true;
            }
        }
        private void mainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            //遍历关闭所有子窗口
            foreach (Form item in Application.OpenForms)
            {
                if (item.Name != "数字图像处理") item.Close();
            }
        }

        //选项：帮助-关于
        private void ToolStripMenuItem_about_Click(object sender, EventArgs e)
        {
            try
            {
                AboutBox aboutBox = new AboutBox();
                aboutBox.Owner = this;
                aboutBox.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "错误提示", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }

        }
        //选项：文件-退出
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        //选项：文件-打开
        private void ToolStripMenuItem_openimg_Click(object sender, EventArgs e)
        {
            try
            {
                //打开窗口初始化
                OpenFileDialog open = new OpenFileDialog();
                open.InitialDirectory = ".";
                open.Filter = "BMP文件(*.bmp)|*.bmp|JPG文件(*.jpg)|*.jpg|BMP文件(*.gif)|*.gif|PNG文件(*.png)|*.png";
                open.RestoreDirectory = true;
                //如果为”打开“选定文件
                if (open.ShowDialog() == DialogResult.OK)
                {
                    //读取当前文件名
                    curFileName = open.FileName;

                    //使用Image.FromFile创建图像对象
                    try
                    {
                        //创建临时Bitmap对象来获取图像数据
                        Bitmap img = (Bitmap)Image.FromFile(curFileName);
                        //利用临时Bitmap对象构造objBitmap对象
                        objBitmap = new Bitmap(img);
                        curBitmap = new Bitmap(img);
                        //左侧窗口显示图像
                        this.pictureBox_old.Image = objBitmap;

                        //销毁临时Bitmap对象，解除文件占用
                        img.Dispose();
                        //获取图像大小
                        cursize = GetPictureBoxZoomSize(pictureBox_old);
                        //右侧窗口显示图像
                        //pictureBox_new.Image = opeBitmap;
                        if (ToolStripMenuItem_composition_open.Checked)
                        {
                            opeBitmap = curBitmap;
                        }
                        else if (ToolStripMenuItem_composition_close.Checked)
                        {
                            opeBitmap = objBitmap;
                        }
                        else
                        {
                            MessageBox.Show("逻辑错误", "错误提示", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "错误提示", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    }
                }
                //对窗体进行重新绘制
                Invalidate();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "错误提示", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        //选项：文件-保存
        private void ToolStripMenuItem_saveimg_Click(object sender, EventArgs e)
        {
            try
            {
                //如果picturebox_new内有图像
                if (this.pictureBox_new.Image != null)
                {
                    //确认是否覆盖原文件
                    if (MessageBox.Show("您确定覆盖原图吗？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                    {
                        //获取源文件扩展名
                        string strFilExtn = System.IO.Path.GetExtension(curFileName);

                        try
                        {
                            if (File.Exists(curFileName))
                            {

                                //如果存在则删除
                                File.Delete(curFileName);
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "错误提示", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        }
                        switch (strFilExtn)
                        {
                            case ".bmp":
                                this.pictureBox_new.Image.Save(curFileName, System.Drawing.Imaging.ImageFormat.Bmp);
                                break;
                            case ".jpg":
                                this.pictureBox_new.Image.Save(curFileName, System.Drawing.Imaging.ImageFormat.Jpeg);
                                break;
                            case ".png":
                                this.pictureBox_new.Image.Save(curFileName, System.Drawing.Imaging.ImageFormat.Png);
                                break;
                            case ".gif":
                                this.pictureBox_new.Image.Save(curFileName, System.Drawing.Imaging.ImageFormat.Gif);
                                break;
                            default:
                                break;
                        }
                    }
                }
                else
                {
                    MessageBox.Show("您还没有对原图进行操作，无需保存！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "错误提示", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        //选项：文件-另存为
        private void ToolStripMenuItem_savenewimg_Click(object sender, EventArgs e)
        {
            try
            {
                //如果新picturebox内有图像
                if (this.pictureBox_new.Image != null)
                {
                    //调用SaveFileDialog
                    SaveFileDialog save = new SaveFileDialog();
                    save.Title = "另存为";
                    //改写已存在文件提示
                    save.OverwritePrompt = true;
                    save.Filter = "BMP文件(*.bmp)|*.bmp|JPG文件(*.jpg)|*.jpg|GIF文件(*.gif)|*.gif|PNG文件(*.png)|*.png";

                    //保存图像
                    if (save.ShowDialog() == DialogResult.OK)
                    {
                        //获取文件路径与扩展名
                        string newFileName = save.FileName;
                        string strFilExtn = System.IO.Path.GetExtension(newFileName);
                        MessageBox.Show(strFilExtn);
                        switch (strFilExtn)
                        {
                            case ".bmp":
                                this.pictureBox_new.Image.Save(newFileName, System.Drawing.Imaging.ImageFormat.Bmp);
                                break;
                            case ".jpg":
                                this.pictureBox_new.Image.Save(newFileName, System.Drawing.Imaging.ImageFormat.Jpeg);
                                break;
                            case ".png":
                                this.pictureBox_new.Image.Save(newFileName, System.Drawing.Imaging.ImageFormat.Png);
                                break;
                            case ".gif":
                                this.pictureBox_new.Image.Save(newFileName, System.Drawing.Imaging.ImageFormat.Gif);
                                break;
                            default:
                                break;
                        }
                    }
                }
                else
                {
                    MessageBox.Show("您还没有对原图进行操作，无需保存！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "错误提示", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        //选项：文件-重置
        private void ToolStripMenuItem_resetimg_Click(object sender, EventArgs e)
        {
            try
            {
                curBitmap = new Bitmap(objBitmap);
                pictureBox_new.Image = curBitmap;
                //重绘
                Invalidate();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "错误提示", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        //选项：基本处理-几何变换-平移
        private void ToolStripMenuItem_translation_Click(object sender, EventArgs e)
        {
            try
            {
                //加载窗体transForm
                transForm transfrm = new transForm();

                //定义窗体所有者
                transfrm.Owner = this;

                transfrm.ShowDialog();
                if (transfrm.flag)
                {

                    int temp_x = Convert.ToInt32(transfrm.textBoxX.Text);
                    int temp_y = Convert.ToInt32(transfrm.textBoxY.Text);

                    //图像处理操作
                    int width = opeBitmap.Width;
                    int height = opeBitmap.Height;
                    Bitmap bitmap = new Bitmap(width + temp_x, height + temp_y);

                    for (int x = 0; x < width; x++)
                    {
                        for (int y = 0; y < height; y++)
                        {
                            bitmap.SetPixel(x + temp_x, y + temp_y, opeBitmap.GetPixel(x, y));
                        }
                    }
                    curBitmap = new Bitmap(bitmap);
                    bitmap.Dispose();
                    this.pictureBox_new.Image = curBitmap;
                }

            }
            catch (Exception ex)
            {
                //错误提示
                MessageBox.Show(ex.Message, "错误提示", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }

        }

        //选项：基本处理-几何变换-镜像-水平镜像
        private void ToolStripMenuItem_mirror_X_Click(object sender, EventArgs e)
        {
            try
            {
                int width = opeBitmap.Width;
                int height = opeBitmap.Height;
                Bitmap bitmap = new Bitmap(width, height);

                for (int x = 0; x < width; x++)
                {
                    for (int y = 0; y < height; y++)
                    {
                        bitmap.SetPixel(x, y, opeBitmap.GetPixel(width - x - 1, y));
                    }
                }
                curBitmap = new Bitmap(bitmap);
                bitmap.Dispose();
                this.pictureBox_new.Image = curBitmap;
            }
            catch (Exception ex)
            {
                //错误提示
                MessageBox.Show(ex.Message, "错误提示", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        //选项：基本处理-几何变换-镜像-垂直镜像
        private void ToolStripMenuItem_mirror_Y_Click(object sender, EventArgs e)
        {
            try
            {
                int width = opeBitmap.Width;
                int height = opeBitmap.Height;
                Bitmap bitmap = new Bitmap(width, height);

                for (int x = 0; x < width; x++)
                {
                    for (int y = 0; y < height; y++)
                    {
                        bitmap.SetPixel(x, y, opeBitmap.GetPixel(x, height - 1 - y));
                    }
                }
                curBitmap = new Bitmap(bitmap);
                bitmap.Dispose();
                this.pictureBox_new.Image = curBitmap;
            }
            catch (Exception ex)
            {
                //错误提示
                MessageBox.Show(ex.Message, "错误提示", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        //选项：基本处理-几何变换-缩放
        private void ToolStripMenuItem_zoom_Click(object sender, EventArgs e)
        {
            try
            {
                zoomForm zoomfrm = new zoomForm();

                zoomfrm.ShowDialog();
                if (zoomfrm.flag)
                {
                    double bilvX = Convert.ToDouble(zoomfrm.textBoxX.Text);
                    double bilvY = Convert.ToDouble(zoomfrm.textBoxY.Text);
                    int width = opeBitmap.Width;
                    int height = opeBitmap.Height;

                    Bitmap bitmap = new Bitmap((int)(width * bilvX) + 1, (int)(height * bilvY) + 1);

                    for (int x = 0; x < width * bilvX; x++)
                    {
                        for (int y = 0; y < height * bilvY; y++)
                        {
                            bitmap.SetPixel(x, y, opeBitmap.GetPixel((int)(x / bilvX), (int)(y / bilvY)));
                        }
                    }
                    curBitmap = new Bitmap(bitmap);
                    bitmap.Dispose();
                    this.pictureBox_new.Image = curBitmap;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "错误提示", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        //选项：基本处理-几何变换-转置
        private void ToolStripMenuItem_transposition_Click(object sender, EventArgs e)
        {
            try
            {
                int width = opeBitmap.Width;
                int height = opeBitmap.Height;
                Bitmap bitmap = new Bitmap(height, width);

                for (int x = 0; x < width; x++)
                {
                    for (int y = 0; y < height; y++)
                    {
                        bitmap.SetPixel(y, x, opeBitmap.GetPixel(x, y));
                    }
                }
                curBitmap = new Bitmap(bitmap);
                bitmap.Dispose();
                this.pictureBox_new.Image = curBitmap;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "错误提示", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        //选项：基本处理-几何变换-旋转
        private void ToolStripMenuItem_rotation_Click(object sender, EventArgs e)
        {
            try
            {
                rotationForm rotationfrm = new rotationForm();
                rotationfrm.ShowDialog();
                if (rotationfrm.flag)
                {
                    int angle = Convert.ToInt32(rotationfrm.textBox_degree.Text);
                    Bitmap bitmap = COMUtil.GetRotateImage(opeBitmap, angle);
                    curBitmap = new Bitmap(bitmap);
                    bitmap.Dispose();
                    this.pictureBox_new.Image = curBitmap;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "错误提示", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }

        }

        //选项：基本处理-灰度变换-非线性变换-对数变换
        private void ToolStripMenuItem_gray_log_Click(object sender, EventArgs e)
        {
            try
            {
                height = opeBitmap.Height;
                width = opeBitmap.Width;
                Color color;
                int[] bMap = new int[256];
                Bitmap bitmap = new Bitmap(width, height);
                for (int i = 0; i < 256; i++)
                {
                    bMap[i] = (int)(Math.Log((double)i + 1.0) / (double)(25 * 0.001) + 0);
                    if (bMap[i] < 0)
                    {
                        bMap[i] = 0;
                    }
                    else if (bMap[i] > 255)
                    {
                        bMap[i] = 255;
                    }
                }
                for (int x = 0; x < width; x++)
                {
                    for (int y = 0; y < height; y++)
                    {
                        color = opeBitmap.GetPixel(x, y);
                        bitmap.SetPixel(x, y, Color.FromArgb(bMap[color.R], bMap[color.G], bMap[color.B]));
                    }
                }
                curBitmap = new Bitmap(bitmap);
                bitmap.Dispose();
                this.pictureBox_new.Image = curBitmap;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "错误提示", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        //选项：基本处理-灰度变换-非线性变换-指数变换
        private void ToolStripMenuItem_gray_exp_Click(object sender, EventArgs e)
        {
            try
            {
                height = opeBitmap.Height;
                width = opeBitmap.Width;
                Color color;
                int[] bMap = new int[256];
                Bitmap bitmap = new Bitmap(width, height);
                for (int i = 0; i < 256; i++)
                {
                    bMap[i] = (int)(Math.Pow(15 * 0.1, 50 * 0.001 * (i - 0)) - 1);
                    if (bMap[i] < 0)
                    {
                        bMap[i] = 0;
                    }
                    else if (bMap[i] > 255)
                    {
                        bMap[i] = 255;
                    }
                }
                for (int x = 0; x < width; x++)
                {
                    for (int y = 0; y < height; y++)
                    {
                        color = opeBitmap.GetPixel(x, y);
                        bitmap.SetPixel(x, y, Color.FromArgb(bMap[color.R], bMap[color.G], bMap[color.B]));
                    }
                }
                curBitmap = new Bitmap(bitmap);
                bitmap.Dispose();
                this.pictureBox_new.Image = curBitmap;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "错误提示", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        //选项：基本处理-灰度变换-非线性变换-幂次变换
        private void ToolStripMenuItem_gray_pow_Click(object sender, EventArgs e)
        {
            try
            {
                height = opeBitmap.Height;
                width = opeBitmap.Width;
                Color color;
                int[] bMap = new int[256];
                Bitmap bitmap = new Bitmap(width, height);
                for (int i = 0; i < 256; i++)
                {
                    bMap[i] = (int)(10 * 0.1 * Math.Pow(i / 255.0, 20 * 0.01) * 255 + 20);
                    if (bMap[i] < 0)
                    {
                        bMap[i] = 0;
                    }
                    else if (bMap[i] > 255)
                    {
                        bMap[i] = 255;
                    }
                }
                for (int x = 0; x < width; x++)
                {
                    for (int y = 0; y < height; y++)
                    {
                        color = opeBitmap.GetPixel(x, y);
                        bitmap.SetPixel(x, y, Color.FromArgb(bMap[color.R], bMap[color.G], bMap[color.B]));
                    }
                }
                curBitmap = new Bitmap(bitmap);
                bitmap.Dispose();
                this.pictureBox_new.Image = curBitmap;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "错误提示", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        //选项：基本处理-灰度变换-二值化变换-固定阈值变换
        private void ToolStripMenuItem_gray_lim_Click(object sender, EventArgs e)
        {
            try
            {
                limitForm limitfrm = new limitForm();
                limitfrm.ShowDialog();

                if (limitfrm.flag == true)
                {
                    height = opeBitmap.Height;
                    width = opeBitmap.Width;
                    //固定阈值
                    if (limitfrm.value == 1)
                    {
                        try
                        {
                            Color color = new Color();
                            int r, g, b;
                            Bitmap bitmap = new Bitmap(width, height);
                            int limit = Convert.ToInt32(limitfrm.textBoxa.Text);
                            for (int i = 0; i < bitmap.Width; i++)
                            {
                                for (int j = 0; j < bitmap.Height; j++)
                                {
                                    color = opeBitmap.GetPixel(i, j);
                                    if (color.R > limit) r = 255; else r = 0;
                                    if (color.G > limit) g = 255; else g = 0;
                                    if (color.B > limit) b = 255; else b = 0;
                                    Color cc = Color.FromArgb(r, g, b);
                                    bitmap.SetPixel(i, j, cc);
                                }
                            }
                            curBitmap = new Bitmap(bitmap);
                            bitmap.Dispose();
                            this.pictureBox_new.Image = curBitmap;
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "错误提示", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        }
                    }
                    //双固定阈值
                    else if (limitfrm.value == 2)
                    {
                        try
                        {
                            Color color = new Color();
                            int r, g, b;
                            Bitmap bitmap = new Bitmap(width, height);
                            for (int i = 0; i < bitmap.Width; i++)
                            {
                                for (int j = 0; j < bitmap.Height; j++)
                                {
                                    color = bitmap.GetPixel(i, j);
                                    if (color.R > 128) r = 255; else r = 0;
                                    if (color.G > 128) g = 255; else g = 0;
                                    if (color.B > 128) b = 255; else b = 0;
                                    Color cc = Color.FromArgb(r, g, b);
                                    bitmap.SetPixel(i, j, cc);
                                }
                            }
                            curBitmap = new Bitmap(bitmap);
                            bitmap.Dispose();
                            this.pictureBox_new.Image = curBitmap;
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "错误提示", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "错误提示", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        //选项：基本处理-灰度变换-二值化变换-0-1变换
        private void ToolStripMenuItem_gray_01_Click(object sender, EventArgs e)
        {
            try
            {
                height = opeBitmap.Height;
                width = opeBitmap.Width;
                Color color = new Color();
                Bitmap bitmap = new Bitmap(width, height);
                for (int i = 0; i < bitmap.Width; i++)
                {
                    for (int j = 0; j < bitmap.Height; j++)
                    {
                        color = opeBitmap.GetPixel(i, j);
                        if (color.R != 0 || color.G != 0 || color.B != 0)
                        {
                            bitmap.SetPixel(i, j, Color.FromArgb(255, 255, 255));
                        }
                        else
                        {
                            bitmap.SetPixel(i, j, Color.FromArgb(0, 0, 0));
                        }
                    }
                }
                curBitmap = new Bitmap(bitmap);
                bitmap.Dispose();
                this.pictureBox_new.Image = curBitmap;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "错误提示", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        //选项：基本处理-灰度变换-线性变换-反色变换
        private void ToolStripMenuItem_gray_reverse_Click(object sender, EventArgs e)
        {
            try
            {
                height = opeBitmap.Height;
                width = opeBitmap.Width;
                Bitmap bitmap = new Bitmap(opeBitmap);
                Color color;
                int r, g, b;
                for (int i = 0; i < width; i++)
                {
                    for (int j = 0; j < height; j++)
                    {
                        color = opeBitmap.GetPixel(i, j);
                        r = 255 - color.R;
                        g = 255 - color.G;
                        b = 255 - color.B;
                        bitmap.SetPixel(i, j, Color.FromArgb(r, g, b));
                    }
                }
                curBitmap = new Bitmap(bitmap);
                bitmap.Dispose();
                this.pictureBox_new.Image = curBitmap;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "错误提示", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        //选项：平滑处理-高斯滤波
        private void ToolStripMenuItem_smooth_gauss_Click(object sender, EventArgs e)
        {
            try
            {
                int width = opeBitmap.Width;
                int height = opeBitmap.Height;
                int[] m = new int[3];
                int neighborhood_size = 3;
                Bitmap bitmap = new Bitmap(width, height);
                for (int y = neighborhood_size / 2; y < height - neighborhood_size / 2; y++)
                {
                    for (int x = neighborhood_size / 2; x < width - neighborhood_size / 2; x++)
                    {
                        m = COMUtil.Templatable(x, y, COMUtil.init_gauss(), opeBitmap, neighborhood_size, true);
                        bitmap.SetPixel(x, y, Color.FromArgb(COMUtil.operation_simple(m[0], 4), COMUtil.operation_simple(m[1], 4), COMUtil.operation_simple(m[2], 4)));
                    }
                }
                curBitmap = new Bitmap(bitmap);
                bitmap.Dispose();
                this.pictureBox_new.Image = curBitmap;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "错误提示", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        //选项：平滑处理-均值滤波
        private void ToolStripMenuItem_smooth_ave_Click(object sender, EventArgs e)
        {
            try
            {
                aveForm avefrm = new aveForm();
                avefrm.ShowDialog();

                if (avefrm.flag)
                {
                    int size = Convert.ToInt32(avefrm.textBox_value.Text);
                    int neighborhood_size = (size - 1) / 2;
                    int width = opeBitmap.Width;
                    int height = opeBitmap.Height;

                    Bitmap bitmap = new Bitmap(width, height);


                    int[] map = new int[size];
                    int[] template = COMUtil.init_templt(size);

                    for (int y = neighborhood_size; y < height - neighborhood_size; y++)
                    {
                        for (int x = neighborhood_size; x < width - neighborhood_size; x++)
                        {

                            map = COMUtil.Templatable(x, y, template, opeBitmap, size, avefrm.color);
                            bitmap.SetPixel(x, y, Color.FromArgb(COMUtil.operation_simple(map[0], size), COMUtil.operation_simple(map[1], size), COMUtil.operation_simple(map[2], size)));
                        }
                    }


                    curBitmap = new Bitmap(bitmap);
                    bitmap.Dispose();
                    this.pictureBox_new.Image = curBitmap;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "错误提示", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        //选项：锐化处理-Laplace锐化
        private void ToolStripMenuItem_sharpen_laplace_Click(object sender, EventArgs e)
        {
            try
            {
                int base_value = 3;
                int[] template = new int[9] { -1, -1, -1, -1, 9, -1, -1, -1, -1 };
                Bitmap bitmap = COMUtil.Sharpen_operation(base_value, template, opeBitmap);

                curBitmap = new Bitmap(bitmap);
                bitmap.Dispose();
                this.pictureBox_new.Image = curBitmap;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "错误提示", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        //选项：锐化处理-Sobel边缘细化-水平边缘
        private void ToolStripMenuItem_sharpen_sobel_horizontal_Click(object sender, EventArgs e)
        {
            try
            {
                int base_value = 3;
                int[] template = new int[9] { -1, -2, -1, 0, 0, 0, 1, 2, 1 };
                Bitmap bitmap = COMUtil.Sharpen_copy(base_value, template, opeBitmap);

                curBitmap = new Bitmap(bitmap);
                bitmap.Dispose();
                this.pictureBox_new.Image = curBitmap;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "错误提示", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        //选项：锐化处理-Sobel边缘细化-垂直边缘
        private void ToolStripMenuItem_sharpen_sobel_vertical_Click(object sender, EventArgs e)
        {
            try
            {
                int base_value = 3;
                int[] template = new int[9] { 1, 0, -1, 2, 0, -2, 1, 0, -1 };
                Bitmap bitmap = COMUtil.Sharpen_copy(base_value, template, opeBitmap);

                curBitmap = new Bitmap(bitmap);
                bitmap.Dispose();
                this.pictureBox_new.Image = curBitmap;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "错误提示", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        //选项：图像处理-轮廓提取-种子算法
        private void ToolStripMenuItem_imgprocess_seed_Click(object sender, EventArgs e)
        {
            try
            {
                int width = opeBitmap.Width;
                int height = opeBitmap.Height;
                this.pictureBox_new.BackColor = Color.White;
                Bitmap bitmap = new Bitmap(width, height);
                for (int x = 1; x < width - 1; x++)
                {
                    for (int y = 1; y < height - 1; y++)
                    {
                        int a = COMUtil.Binaryzation(opeBitmap.GetPixel(x, y));
                        if (a == 0)
                        {
                            int a1 = COMUtil.Binaryzation(opeBitmap.GetPixel(x - 1, y - 1));
                            int a2 = COMUtil.Binaryzation(opeBitmap.GetPixel(x - 1, y));
                            int a3 = COMUtil.Binaryzation(opeBitmap.GetPixel(x - 1, y + 1));
                            int a4 = COMUtil.Binaryzation(opeBitmap.GetPixel(x, y - 1));
                            int a6 = COMUtil.Binaryzation(opeBitmap.GetPixel(x, y + 1));
                            int a7 = COMUtil.Binaryzation(opeBitmap.GetPixel(x + 1, y - 1));
                            int a8 = COMUtil.Binaryzation(opeBitmap.GetPixel(x + 1, y));
                            int a9 = COMUtil.Binaryzation(opeBitmap.GetPixel(x + 1, y + 1));
                            if (a1 + a2 + a3 + a4 + a6 + a7 + a8 + a9 == 0)
                            {
                                bitmap.SetPixel(x, y, Color.FromArgb(255, 255, 255));
                            }
                            else
                            {
                                bitmap.SetPixel(x, y, Color.FromArgb(0, 0, 0));
                            }
                        }
                    }
                }
                curBitmap = new Bitmap(bitmap);
                bitmap.Dispose();
                this.pictureBox_new.Image = curBitmap;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "错误提示", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        //选项：图像处理-轮廓提取-追踪算法
        private void ToolStripMenuItem_imgprocess_track_Click(object sender, EventArgs e)
        {
            try
            {
                int width = opeBitmap.Width;
                int height = opeBitmap.Height;
                Point currentpoint = new Point { X = -1, Y = -1 };
                int[,] GOTO = new int[8, 2] { { -1, -1 }, { 0, -1 }, { 1, -1 }, { 1, 0 }, { 1, 1 }, { 0, 1 }, { -1, 1 }, { -1, 0 } };
                Bitmap bitmap = new Bitmap(width, height);
                Point point = new Point { X = -1, Y = -1 };
                bool findpoint;
                bool isfind = false;
                int direction = 0;
                for (int j = height - 1; j >= 0 && !isfind; j--)
                {
                    for (int i = 0; i < width && !isfind; i++)
                    {
                        int a = COMUtil.Binaryzation(opeBitmap.GetPixel(i, j));
                        if (a == 0)
                        {
                            isfind = true;
                            point.X = i;
                            point.Y = j;
                            break;
                        }
                    }
                }

                currentpoint = point;

                for (int x = 0; x < width; x++)
                {
                    for (int y = 0; y < height; y++)
                    {
                        bitmap.SetPixel(x, y, Color.FromArgb(255, 255, 255));
                    }
                }

                isfind = false;
                while (!isfind)
                {
                    findpoint = false;
                    while (!findpoint)
                    {
                        int temp_x = currentpoint.X + GOTO[direction, 0];
                        int temp_y = currentpoint.Y + GOTO[direction, 1];
                        int a = COMUtil.Binaryzation(opeBitmap.GetPixel(temp_x, temp_y));
                        if (a == 0)
                        {
                            findpoint = true;
                            currentpoint.X = temp_x;
                            currentpoint.Y = temp_y;
                            if (currentpoint == point)
                            {
                                isfind = true;
                            }
                            bitmap.SetPixel(temp_x, temp_y, Color.FromArgb(0, 0, 0));
                            direction--;
                            if (direction == -1)
                                direction = 7;
                            direction--;
                            if (direction == -1)
                                direction = 7;
                        }
                        else
                        {
                            direction++;
                            if (direction == 8)
                                direction = 0;
                        }
                    }

                }
                curBitmap = new Bitmap(bitmap);
                bitmap.Dispose();
                this.pictureBox_new.Image = curBitmap;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "错误提示", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }


        private void 膨胀ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void 开运算ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Bitmap bitmap = COMUtil.Corrosion(opeBitmap);
                Bitmap bitmap_new = COMUtil.Expansion(bitmap);
                curBitmap = new Bitmap(bitmap_new);
                bitmap.Dispose();
                bitmap_new.Dispose();
                this.pictureBox_new.Image = curBitmap;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "错误提示", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void 闭运算ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Bitmap bitmap = COMUtil.Expansion(opeBitmap);
                Bitmap bitmap_new = COMUtil.Corrosion(bitmap);
                curBitmap = new Bitmap(bitmap_new);
                bitmap.Dispose();
                bitmap_new.Dispose();
                this.pictureBox_new.Image = curBitmap;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "错误提示", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void 细化处理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                int a = 0;
                int width = opeBitmap.Width;
                int height = opeBitmap.Height;
                int t1, t2;
                int count;
                bool finish = false;
                Bitmap bitmap = new Bitmap(width, height);
                int[,] nb = new int[5, 5] { { 0, 0, 0, 0, 0 }, { 0, 0, 0, 0, 0 }, { 0, 0, 0, 0, 0 }, { 0, 0, 0, 0, 0 }, { 0, 0, 0, 0, 0 } };
                for (int i = 0; i < width; i++)
                {
                    for (int j = 0; j < height; j++)
                    {
                        if (COMUtil.getAshETV(opeBitmap, i, j) < 100)
                        {
                            bitmap.SetPixel(i, j, Color.FromArgb(a, a, a));
                        }
                        else
                        {
                            bitmap.SetPixel(i, j, Color.FromArgb(255 - a, 255 - a, 255 - a));
                        }
                    }
                }


                while (!finish)
                {
                    finish = true;
                    for (int y = 2; y < height - 2; y++)
                    {
                        for (int x = 2; x < width - 2; x++)
                        {
                            if (COMUtil.getAshETV(bitmap, x, y) == 255 - a)
                                continue;
                            t1 = 0;
                            t2 = 0;
                            for (int j = 0; j < 5; j++)
                            {
                                for (int i = 0; i < 5; i++)
                                {
                                    if (COMUtil.getAshETV(bitmap, x + i - 2, y + j - 2) == a)
                                    {
                                        nb[j, i] = 1;
                                    }
                                    else
                                    {
                                        nb[j, i] = 0;
                                    }
                                }
                            }
                            count = nb[1, 1] + nb[1, 2] + nb[1, 3] + nb[2, 1] + nb[2, 3] + nb[3, 1] + nb[3, 2] + nb[3, 3];
                            if (count >= 2 && count <= 6)
                            {
                                t1 = 1;
                            }
                            else
                            {
                                continue;
                            }
                            count = 0;
                            if (nb[1, 2] == 0 && nb[1, 1] == 1)
                                count++;
                            if (nb[1, 1] == 0 && nb[2, 1] == 1)
                                count++;
                            if (nb[2, 1] == 0 && nb[3, 1] == 1)
                                count++;
                            if (nb[3, 1] == 0 && nb[3, 2] == 1)
                                count++;
                            if (nb[3, 2] == 0 && nb[3, 3] == 1)
                                count++;
                            if (nb[3, 3] == 0 && nb[2, 3] == 1)
                                count++;
                            if (nb[2, 3] == 0 && nb[1, 3] == 1)
                                count++;
                            if (nb[1, 3] == 0 && nb[1, 2] == 1)
                                count++;
                            if (count == 1)
                            {
                                t2 = 1;
                            }
                            else
                            {
                                continue;
                            }
                            if (t1 * t2 == 1)
                            {
                                bitmap.SetPixel(x, y, Color.FromArgb(255 - a, 255 - a, 255 - a));
                                finish = false;
                            }
                        }
                    }
                }
                curBitmap = new Bitmap(bitmap);
                bitmap.Dispose();
                this.pictureBox_new.Image = curBitmap;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "错误提示", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }
        //选项：形态学处理-腐蚀效果
        private void ToolStripMenuItem_Corrosion_Click(object sender, EventArgs e)
        {
            try
            {
                Bitmap bitmap = COMUtil.Corrosion(opeBitmap);
                curBitmap = new Bitmap(bitmap);
                bitmap.Dispose();
                this.pictureBox_new.Image = curBitmap;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "错误提示", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void ToolStripMenuItem_expension_Click(object sender, EventArgs e)
        {
            try
            {
                Bitmap bitmap = COMUtil.Expansion(opeBitmap);
                curBitmap = new Bitmap(bitmap);
                bitmap.Dispose();
                this.pictureBox_new.Image = curBitmap;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "错误提示", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void 灰度化处理WToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                height = opeBitmap.Height;
                width = opeBitmap.Width;
                Color color = new Color();
                Bitmap bitmap = new Bitmap(width, height);
                int r, g, b, Result = 0;
                for (int i = 0; i < bitmap.Width; i++)
                {
                    for (int j = 0; j < bitmap.Height; j++)
                    {
                        color = opeBitmap.GetPixel(i, j);
                        r = color.R;
                        g = color.G;
                        b = color.B;
                        Result = ((int)(0.11 * r) + (int)(0.59 * g) + (int)(0.3 * b));
                        bitmap.SetPixel(i, j, Color.FromArgb(Result, Result, Result));
                    }
                }
                curBitmap = new Bitmap(bitmap);
                bitmap.Dispose();
                this.pictureBox_new.Image = curBitmap;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "错误提示", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void sobelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Bitmap bitmap = new Bitmap(opeBitmap);
                COMUtil.Edge(bitmap, "Sobel", out bitmap);
                curBitmap = new Bitmap(bitmap);
                bitmap.Dispose();
                this.pictureBox_new.Image = curBitmap;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "错误提示", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void prewittToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Bitmap bitmap = new Bitmap(opeBitmap);
                COMUtil.Edge(bitmap, "Prewitt", out bitmap);
                curBitmap = new Bitmap(bitmap);
                bitmap.Dispose();
                this.pictureBox_new.Image = curBitmap;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "错误提示", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void robertsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Bitmap bitmap = new Bitmap(opeBitmap);
                COMUtil.Edge(bitmap, "Roberts", out bitmap);
                curBitmap = new Bitmap(bitmap);
                bitmap.Dispose();
                this.pictureBox_new.Image = curBitmap;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "错误提示", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void hSVToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Color color;
                int r, g, b = 0;
                height = opeBitmap.Height;
                width = opeBitmap.Width;
                Bitmap bitmap = new Bitmap(opeBitmap);
                for (int i = 0; i < width; i++)
                {
                    for (int j = 0; j < height; j++)
                    {
                        color = bitmap.GetPixel(i, j);
                        r = color.R;
                        g = color.G;
                        b = color.B;
                        int Hi, f, p, q, t;
                        int H = 0, S = 0, V = 0;
                        int max = COMUtil.getMax(r, g, b);
                        int min = COMUtil.getMin(r, g, b);
                        if (max != min)
                        {
                            if (max == r)
                            {
                                H = (g - b) / (max - min);
                            }
                            else if (max == g)
                            {
                                H = 2 + (b - r) / (max - min);
                            }
                            else if (max == b)
                            {
                                H = 4 + (r - g) / (max - min);
                            }
                        }
                        H = H * 60;
                        if (H < 0)
                        {
                            H = H + 360;
                        }
                        V = max;
                        if (max != 0)
                        {
                            S = (max - min) / max;
                        }

                        Hi = Math.Abs(H / 60);
                        f = H / 60 - Hi;
                        p = V * (1 - S);
                        q = V * (1 - f * S);
                        t = V * (1 - (1 - f) * S);
                        if (Hi == 0)
                        {
                            r = V;
                            g = t;
                            b = p;
                        }
                        else if (Hi == 1)
                        {
                            r = q;
                            g = V;
                            b = p;
                        }
                        else if (Hi == 2)
                        {
                            r = p;
                            g = V;
                            b = t;
                        }
                        else if (Hi == 3)
                        {
                            r = p;
                            g = q;
                            b = V;
                        }
                        else if (Hi == 4)
                        {
                            r = t;
                            g = p;
                            b = V;
                        }
                        else if (Hi == 5)
                        {
                            r = V;
                            g = p;
                            b = q;
                        }
                        bitmap.SetPixel(i, j, Color.FromArgb(r, g, b));
                    }
                }
                curBitmap = new Bitmap(bitmap);
                bitmap.Dispose();
                pictureBox_new.Image = curBitmap;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "错误提示", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void hSIToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Bitmap bitmap = new Bitmap(opeBitmap);
                Color color;
                int r, g, b = 0;
                for (int i = 0; i < opeBitmap.Width; i++)
                {
                    for (int j = 0; j < opeBitmap.Height; j++)
                    {
                        int H, S, I;
                        color = opeBitmap.GetPixel(i, j);
                        r = color.R;
                        g = color.G;
                        b = color.B;
                        H = S = I = 0;
                        if (g != b && r != 0 && g != 0 && b != 0)
                        {
                            double F = (2 * r - g - b) / (g - b);
                            I = (r + g + b) / 3;
                            if (g > b)
                            {
                                H = (90 - (int)Math.Tan((double)F / (int)Math.Sqrt(3.0))) / 360;
                            }
                            else
                            {
                                H = ((90 - (int)Math.Tan((double)F / Math.Sqrt(3.0))) + 180) / 360;
                            }
                            S = 1 - COMUtil.getMin(r, g, b) / (b);
                        }
                        if (H >= 0 && H < 120)
                        {
                            r = (int)(1 + S * Math.Cos(H * 1.0) / Math.Cos(1.0 * (60 - H)) / Math.Sqrt(3.0));
                            b = (1 - S) / (int)Math.Sqrt(3.0);
                            g = I * (int)Math.Sqrt(3.0) - r - b;
                        }
                        else if (H >= 120 && H < 240)
                        {
                            r = (int)(1 + S * Math.Cos(H * 1.0 - 120) / Math.Cos((180 - H) * 1.0)) / (int)Math.Sqrt(3.0);
                            b = (1 - S) / (int)Math.Sqrt(3.0);
                            g = I * (int)Math.Sqrt(3.0) - r - b;
                        }
                        else if (H >= 240 && H < 360)
                        {
                            r = (int)(1 + S * Math.Cos(H * 1.0 - 240) / Math.Cos((300 - H) * 1.0)) / (int)Math.Sqrt(3.0);
                            b = (1 - S) / (int)Math.Sqrt(3.0);
                            g = I * (int)Math.Sqrt(3.0) - r - b;
                        }
                        g = Math.Abs(g);
                        bitmap.SetPixel(i, j, Color.FromArgb(r, g, b));
                    }
                }
                curBitmap = new Bitmap(bitmap);
                bitmap.Dispose();
                pictureBox_new.Image = curBitmap;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "错误提示", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void yUVToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Bitmap bitmap = new Bitmap(opeBitmap);
                Color color;
                int r, g, b = 0;
                double Y, U, V;
                for (int i = 0; i < opeBitmap.Width; i++)
                {
                    for (int j = 0; j < opeBitmap.Height; j++)
                    {
                        color = opeBitmap.GetPixel(i, j);
                        r = color.R;
                        g = color.G;
                        b = color.B;
                        Y = U = V = 0;
                        Y = (0.299 * r + 0.587 * g + 0.114 * b);
                        U = (-0.1687 * r - 0.3313 * g + 0.5 * b);
                        V = (0.5 * r - 0.4187 * g - 0.0813 * b);
                        r = (int)(Y + 1.401 * V) / 2;
                        g = (int)(Y - 0.34414 * U - 0.71414 * V) / 2;
                        b = (int)(Y + 1.1772 * U) / 2;
                        g = Math.Abs(g);
                        bitmap.SetPixel(i, j, Color.FromArgb(r, g, b));
                    }
                }
                curBitmap = new Bitmap(bitmap);
                bitmap.Dispose();
                pictureBox_new.Image = curBitmap;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "错误提示", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void yCbCrToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Bitmap bitmap = new Bitmap(opeBitmap);
                Color color;
                int r, g, b = 0;
                double Y, Cb, Cr;
                Y = Cb = Cr = 0;
                for (int i = 0; i < opeBitmap.Width; i++)
                {
                    for (int j = 0; j < opeBitmap.Height; j++)
                    {
                        color = opeBitmap.GetPixel(i, j);
                        r = color.R;
                        g = color.G;
                        b = color.B;
                        Y = 0.299 * r + 0.587 * g + 0.114 * b;
                        Cb = -0.1687 * r - 0.3313 * g + 0.5 * b + 128;
                        Cr = 0.5 * r - 0.4187 * g - 0.0813 * b + 128;
                        r = (int)(Y + 1.402 * (Cr - 128)) / 2;
                        g = (int)(Y - 0.34414 * (Cb - 128) - 0.71414 * (Cr - 128)) / 2;
                        b = (int)(Y + 1.772 * (Cb - 128)) / 2;
                        bitmap.SetPixel(i, j, Color.FromArgb(r, g, b));
                    }
                }
                curBitmap = new Bitmap(bitmap);
                bitmap.Dispose();
                pictureBox_new.Image = curBitmap;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "错误提示", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void pictureBox_new_Paint(object sender, PaintEventArgs e)
        {
            try
            {
                if (objBitmap != null)
                {
                    if (ToolStripMenuItem_composition_close.Checked)
                    {
                        opeBitmap = new Bitmap(objBitmap);
                    }
                    else if (ToolStripMenuItem_composition_open.Checked)
                    {
                        opeBitmap = new Bitmap(curBitmap);
                    }
                    else
                    {
                        MessageBox.Show("绘图错误", "错误提示", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "错误提示", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }
        //选项：车牌识别
        private void 车牌识别ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                //加载窗体CCSForm
                CCSForm ccsfrm = new CCSForm();

                //定义窗体所有者
                ccsfrm.Owner = this;

                ccsfrm.ShowDialog();
            }
            catch (Exception ex)
            {
                //错误提示
                MessageBox.Show(ex.Message, "错误提示", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        //选项：设置-效果叠加-开启
        private void ToolStripMenuItem_composition_open_Click(object sender, EventArgs e)
        {
            try
            {
                ToolStripMenuItem_composition_close.Checked = false;
                ToolStripMenuItem_composition_open.Checked = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "错误提示", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void ToolStripMenuItem_smooth_mid_Click(object sender, EventArgs e)
        {
            try
            {
                Bitmap bitmap = new Bitmap(opeBitmap);
                height = opeBitmap.Height;
                width = opeBitmap.Width;
                Color[] pixel = new Color[9];//暂时建立一个3*3模版
                int[] red = new int[9];
                int[] green = new int[9];
                int[] blue = new int[9];
                int temp1 = 0, temp2 = 0, temp3 = 0;
                for (int i = 1; i < width - 1; i++)
                {
                    for (int j = 1; j < height - 1; j++)
                    {
                        pixel[0] = opeBitmap.GetPixel(i - 1, j - 1);
                        pixel[1] = opeBitmap.GetPixel(i - 1, j);
                        pixel[2] = opeBitmap.GetPixel(i - 1, j + 1);
                        pixel[3] = opeBitmap.GetPixel(i, j - 1);
                        pixel[4] = opeBitmap.GetPixel(i, j);
                        pixel[5] = opeBitmap.GetPixel(i, j + 1);
                        pixel[6] = opeBitmap.GetPixel(i + 1, j - 1);
                        pixel[7] = opeBitmap.GetPixel(i + 1, j);
                        pixel[8] = opeBitmap.GetPixel(i + 1, j + 1);
                        //取中值

                        for (int s = 0; s < 9; s++)
                        {
                            red[s] = pixel[s].R;
                            green[s] = pixel[s].R;
                            blue[s] = pixel[s].R;
                        }
                        //起泡排序
                        for (int x = 0; x < 8; x++)
                        {
                            for (int y = 0; y < 8 - x; y++)
                            {
                                if (red[y] < red[y + 1])
                                {
                                    temp1 = red[y];
                                    red[y] = red[y + 1];
                                    red[y + 1] = temp1;
                                }
                                if (green[y] < green[y + 1])
                                {
                                    temp2 = green[y];
                                    green[y] = green[y + 1];
                                    green[y + 1] = temp2;
                                }
                                if (blue[y] < blue[y + 1])
                                {
                                    temp3 = blue[y];
                                    blue[y] = blue[y + 1];
                                    blue[y + 1] = temp3;
                                }
                            }
                        }
                        Color cc = Color.FromArgb(red[4], green[4], blue[4]);
                        bitmap.SetPixel(i, j, cc);
                    }
                }
                curBitmap = new Bitmap(bitmap);
                bitmap.Dispose();
                pictureBox_new.Image = curBitmap;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "错误提示", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        //选项：设置-效果叠加-关闭
        private void ToolStripMenuItem_composition_close_Click(object sender, EventArgs e)
        {
            try
            {
                ToolStripMenuItem_composition_close.Checked = true;
                ToolStripMenuItem_composition_open.Checked = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "错误提示", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }
    }
}
