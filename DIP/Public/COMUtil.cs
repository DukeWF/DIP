using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DIP.Public
{
    public class COMUtil
    {
        //获取文件类型（传入：文件名.扩展名， 返回：扩展名）
        public static string getType(string file)
        {
            string[] type = file.Split('.');
            return type[type.Length - 1];
        }
        //获取对象指针（传入：原对象， 返回：对象指针）
        public static IntPtr GetPtr(Object obj)
        {
            RuntimeTypeHandle handle = obj.GetType().TypeHandle;
            IntPtr ptr = handle.Value;
            return ptr;
        }

        /// <summary>
        /// 计算矩形绕中心任意角度旋转后所占区域矩形宽高
        /// </summary>
        /// <param name="width">原矩形的宽</param>
        /// <param name="height">原矩形高</param>
        /// <param name="angle">顺时针旋转角度</param>
        /// <returns></returns>
        public static Rectangle GetRotateRectangle(int width, int height, float angle)
        {
            double radian = angle * Math.PI / 180; ;
            double cos = Math.Cos(radian);
            double sin = Math.Sin(radian);
            //只需要考虑到第四象限和第三象限的情况取大值(中间用绝对值就可以包括第一和第二象限)
            int newWidth = (int)(Math.Max(Math.Abs(width * cos - height * sin), Math.Abs(width * cos + height * sin)));
            int newHeight = (int)(Math.Max(Math.Abs(width * sin - height * cos), Math.Abs(width * sin + height * cos)));
            return new Rectangle(0, 0, newWidth, newHeight);
        }

        /// <summary>
        /// 获取原图像绕中心任意角度旋转后的图像
        /// </summary>
        /// <param name="rawImg"></param>
        /// <param name="angle"></param>
        /// <returns></returns>
        public static Bitmap GetRotateImage(Bitmap srcImage, int angle)
        {
            angle = angle % 360;
            //原图的宽和高
            int srcWidth = srcImage.Width;
            int srcHeight = srcImage.Height;
            //图像旋转之后所占区域宽和高
            Rectangle rotateRec = GetRotateRectangle(srcWidth, srcHeight, angle);
            int rotateWidth = rotateRec.Width;
            int rotateHeight = rotateRec.Height;
            //目标位图
            Bitmap destImage = null;
            Graphics graphics = null;
            try
            {
                //定义画布，宽高为图像旋转后的宽高
                destImage = new Bitmap(rotateWidth, rotateHeight);
                //graphics根据destImage创建，因此其原点此时在destImage左上角
                graphics = Graphics.FromImage(destImage);
                //要让graphics围绕某矩形中心点旋转N度，分三步
                //第一步，将graphics坐标原点移到矩形中心点,假设其中点坐标（x,y）
                //第二步，graphics旋转相应的角度(沿当前原点)
                //第三步，移回（-x,-y）
                //获取画布中心点
                Point centerPoint = new Point(rotateWidth / 2, rotateHeight / 2);
                //将graphics坐标原点移到中心点
                graphics.TranslateTransform(centerPoint.X, centerPoint.Y);
                //graphics旋转相应的角度(绕当前原点)
                graphics.RotateTransform(angle);
                //恢复graphics在水平和垂直方向的平移(沿当前原点)
                graphics.TranslateTransform(-centerPoint.X, -centerPoint.Y);
                //此时已经完成了graphics的旋转

                //计算:如果要将源图像画到画布上且中心与画布中心重合，需要的偏移量
                Point Offset = new Point((rotateWidth - srcWidth) / 2, (rotateHeight - srcHeight) / 2);
                //将源图片画到rect里（rotateRec的中心）
                graphics.DrawImage(srcImage, new Rectangle(Offset.X, Offset.Y, srcWidth, srcHeight));
                //重至绘图的所有变换
                graphics.ResetTransform();
                graphics.Save();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (graphics != null)
                    graphics.Dispose();
            }
            return destImage;
        }

        //平滑处理相关操作

        public static int[] init_templt(int size)
        {
            int square = size * size;
            int[] template = new int[square];
            for (int i=0;i< square; i++)
            {
                template[i] = 1;
            }
            
            return template;
        }
        public static int[] Templatable(int x, int y, int[] template, Bitmap bitmap, int neighborhood_size, bool flag)
        {
            int[] m = new int[3];

            int width = bitmap.Width;
            int height = bitmap.Height;
            int px, py;

            //彩色
            if (flag == true)
            {
                int[] t = new int[3] { 0, 0, 0 };
                for (int i = 0; i < neighborhood_size; i++)
                {
                    for (int j = 0; j < neighborhood_size; j++)
                    {
                        py = y - neighborhood_size / 2 + i;
                        px = x - neighborhood_size / 2 + j;
                        Color color = bitmap.GetPixel(px, py);
                        int r = color.R;
                        t[0] += r * template[i * neighborhood_size + j];
                        int g = color.G;
                        t[1] += g * template[i * neighborhood_size + j];
                        int b = color.B;
                        t[2] += b * template[i * neighborhood_size + j];
                    }
                }
                for (int i=0;i< m.Length; i++)
                {
                    m[i] = t[i];
                }
                
                return m;
            }
            //黑白
            else if(flag == false)
            {
                int t = 0;

                for (int i = 0; i < neighborhood_size; i++)
                {
                    for (int j = 0; j < neighborhood_size; j++)
                    {
                        py = y - neighborhood_size / 2 + i;
                        px = x - neighborhood_size / 2 + j;
                        Color color = bitmap.GetPixel(px, py);
                        int s = (color.R + color.G + color.B) / 3;
                        t += s * template[i * neighborhood_size + j];
                    }
                }
                for (int i=0;i< m.Length; i++)
                {
                    m[i] = t;
                }
                
                return m;
            }
            else
            {
                for(int i = 0; i < m.Length; i++)
                {
                    m[i] = 0;
                }
                return m;
            }
        }
        public static int operation_simple(int r, int size)
        {
            r /= (size * size);
            r = r > 255 ? 255 : r;
            r = r < 0 ? 0 : r;
            return r;
        }

        public static int[] init_gauss()
        {
            int []template = new int[9] { 1, 2, 1, 2, 4, 2, 1, 2, 1 };
            return template;
        }
        //锐化相关方法
        public static Color Convolution(int[] template, int base_value, int x, int y, Bitmap bitmap)
        {
            int r = 0, g = 0, b = 0;
            int Index = 0;
            Color pixel;
            for (int col = -base_value / 2; col <= base_value / 2; col++)
                for (int row = -base_value / 2; row <= base_value / 2; row++)
                {
                    pixel = bitmap.GetPixel(x + row, y + col);
                    r += pixel.R * template[Index];
                    g += pixel.G * template[Index];
                    b += pixel.B * template[Index];
                    Index++;
                }
            //处理颜色值溢出
            r = r > 255 ? 255 : r;
            r = r < 0 ? 0 : r;
            g = g > 255 ? 255 : g;
            g = g < 0 ? 0 : g;
            b = b > 255 ? 255 : b;
            b = b < 0 ? 0 : b;
            return Color.FromArgb(r, g, b);
        }
        public static Bitmap Sharpen_operation(int base_value, int[] template, Bitmap bitmap)
        {
            int Height = bitmap.Height;
            int Width = bitmap.Width;
            Bitmap newBitmap = new Bitmap(Width, Height);
            for (int x = 1; x < Width - 1; x++)
                for (int y = 1; y < Height - 1; y++)
                {
                    newBitmap.SetPixel(x - 1, y - 1, Convolution(template, base_value, x, y, bitmap));
                }
            return newBitmap;
        }
        public static Bitmap Sharpen_copy(int base_value, int[] template, Bitmap bitmap)
        {
            int Height = bitmap.Height;
            int Width = bitmap.Width;
            Bitmap newBitmap = new Bitmap(Width, Height);
            for (int x = 1; x < Width - 1; x++)
                for (int y = 1; y < Height - 1; y++)
                {
                    newBitmap.SetPixel(x - 1, y - 1, Convolution(template, base_value, x, y, bitmap));
                }
            return newBitmap;
        }
        public static int Binaryzation(Color color)
        {
            int a = (int)(0.7 * color.R + 0.2 * color.G + 0.1 * color.B);
            a = a > 128 ? 255 : 0;
            return a;

        }

        //形态学处理相关方法
        public static Bitmap Corrosion(Bitmap bitmap)
        {
            int width = bitmap.Width;
            int height = bitmap.Height;
            Bitmap newBitmap = new Bitmap(width, height);

            for (int i = 1; i < width - 1; i++)
            {
                for (int j = 1; j < height - 1; j++)
                {
                    int a = Binaryzation(bitmap.GetPixel(i, j));
                    int x1 = Binaryzation(bitmap.GetPixel(i - 1, j));
                    int x2 = Binaryzation(bitmap.GetPixel(i, j + 1));
                    int x3 = Binaryzation(bitmap.GetPixel(i + 1, j));
                    int x4 = Binaryzation(bitmap.GetPixel(i, j - 1));
                    if (x1 == 255 || x2 == 255 || x3 == 255 || x4 == 255 && a == 0)
                    {
                        newBitmap.SetPixel(i, j, Color.FromArgb(255, 255, 255));
                    }
                    else
                    {
                        newBitmap.SetPixel(i, j, Color.FromArgb(0, 0, 0));
                    }
                }
            }
            return newBitmap;
        }

        public static Bitmap Expansion(Bitmap bitmap)
        {
            int width = bitmap.Width;
            int height = bitmap.Height;
            Bitmap newBitmap = new Bitmap(width, height);

            for (int i = 1; i < width - 1; i++)
            {
                for (int j = 1; j < height - 1; j++)
                {
                    int a = Binaryzation(bitmap.GetPixel(i, j));
                    int x1 = Binaryzation(bitmap.GetPixel(i - 1, j));
                    int x2 = Binaryzation(bitmap.GetPixel(i, j + 1));
                    int x3 = Binaryzation(bitmap.GetPixel(i + 1, j));
                    int x4 = Binaryzation(bitmap.GetPixel(i, j - 1));
                    if (x1 == 0 || x2 == 0 || x3 == 0 || x4 == 0 && a == 0)
                    {
                        newBitmap.SetPixel(i, j, Color.FromArgb(0, 0, 0));
                    }
                    else
                    {
                        newBitmap.SetPixel(i, j, Color.FromArgb(255, 255, 255));
                    }

                }
            }
            return newBitmap;
        }
        public static int getAshETV(Bitmap bitmap, int x, int y)
        {
            Color color = bitmap.GetPixel(x, y);
            int a = (color.R + color.G + color.B) / 3;
            return a;
        }

        public static unsafe void* memset(void* buf, byte c, int size)
        {
            byte* p = (byte*)buf;
            while (size > 0)
            {
                *p = c;
                size--;
                p++;
            }
            return buf;
        }

        /// <summary>  
        /// 边缘检测  
        /// </summary>  
        /// <param name="srcBmp">原始图像</param>  
        /// <param name="edgeDetectors">边缘检测算子</param>  
        /// <param name="dstBmp">目标图像</param>  
        /// <param name="mask">模板</param>  
        /// <param name="T">阈值，当算子为拉普拉斯时有用</param>  
        /// <returns>处理成功 true 失败 false</returns>  
        public static bool Edge(Bitmap srcBmp, String edgeDetectors, out Bitmap dstBmp, int[] mask = null, int T = 0)
        {
            if (srcBmp == null)
            {
                dstBmp = null;
                return false;
            }
            int[] template = new int[25];
            if (mask != null) { template = mask; }
            Bitmap tempSrcBmp = new Bitmap(srcBmp);//为形态学边缘检测所用  
            dstBmp = new Bitmap(srcBmp);
            BitmapData bmpDataSrc = srcBmp.LockBits(new Rectangle(0, 0, srcBmp.Width, srcBmp.Height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
            BitmapData bmpDataDst = dstBmp.LockBits(new Rectangle(0, 0, dstBmp.Width, dstBmp.Height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
            //double[] laplacianArray = new double[bmpDataSrc.Stride * bmpDataSrc.Height];//存储拉普拉斯算子中间结果   
            unsafe
            {
                byte* ptrSrc = (byte*)bmpDataSrc.Scan0;
                byte* ptrDst = (byte*)bmpDataDst.Scan0;
                double gradX, gradY, grad;
                switch (edgeDetectors)
                {
                    case "Roberts"://Roberts算子  
                        for (int i = 0; i < srcBmp.Height; i++)
                        {
                            for (int j = 0; j < srcBmp.Width; j++)
                            {
                                gradX = ptrSrc[i * bmpDataSrc.Stride + j * 3] - ptrSrc[(i + 1) % srcBmp.Height * bmpDataSrc.Stride + (j + 1) % srcBmp.Width * 3];
                                gradY = ptrSrc[i * bmpDataSrc.Stride + (j + 1) % srcBmp.Width * 3] - ptrSrc[(i + 1) % srcBmp.Height * bmpDataSrc.Stride + j * 3];
                                grad = Math.Sqrt(gradX * gradX + gradY * gradY);
                                grad = grad > 255 ? 255 : grad;
                                ptrDst[i * bmpDataDst.Stride + j * 3] = ptrDst[i * bmpDataDst.Stride + j * 3 + 1] = ptrDst[i * bmpDataDst.Stride + j * 3 + 2] = (byte)grad;
                            }
                        }
                        break;
                    case "Prewitt"://prewitt算子  
                        for (int i = 0; i < srcBmp.Height; i++)
                        {
                            for (int j = 0; j < srcBmp.Width; j++)
                            {
                                gradX = ptrSrc[Math.Abs(i - 1) % srcBmp.Height * bmpDataSrc.Stride + (j + 1) % srcBmp.Width * 3] +
                                        ptrSrc[i * bmpDataSrc.Stride + (j + 1) % srcBmp.Width * 3] +
                                        ptrSrc[(i + 1) % srcBmp.Height * bmpDataSrc.Stride + (j + 1) % srcBmp.Width * 3] -
                                        ptrSrc[Math.Abs(i - 1) % srcBmp.Height * bmpDataSrc.Stride + Math.Abs(j - 1) % srcBmp.Width * 3] -
                                        ptrSrc[i * bmpDataSrc.Stride + Math.Abs(j - 1) % srcBmp.Width * 3] -
                                        ptrSrc[(i + 1) % srcBmp.Height * bmpDataSrc.Stride + Math.Abs(j - 1) % srcBmp.Width * 3];
                                gradY = ptrSrc[Math.Abs(i - 1) % srcBmp.Height * bmpDataSrc.Stride + Math.Abs(j - 1) % srcBmp.Width * 3] +
                                        ptrSrc[Math.Abs(i - 1) % srcBmp.Height * bmpDataSrc.Stride + j * 3] +
                                        ptrSrc[Math.Abs(i - 1) % srcBmp.Height * bmpDataSrc.Stride + (j + 1) % srcBmp.Width * 3] -
                                        ptrSrc[(i + 1) % srcBmp.Height * bmpDataSrc.Stride + Math.Abs(j - 1) % srcBmp.Width * 3] -
                                        ptrSrc[(i + 1) % srcBmp.Height * bmpDataSrc.Stride + j * 3] -
                                        ptrSrc[(i + 1) % srcBmp.Height * bmpDataSrc.Stride + (j + 1) % srcBmp.Width * 3];
                                grad = Math.Sqrt(gradX * gradX + gradY * gradY);
                                grad = grad > 255 ? 255 : grad;
                                ptrDst[i * bmpDataDst.Stride + j * 3] = ptrDst[i * bmpDataDst.Stride + j * 3 + 1] = ptrDst[i * bmpDataDst.Stride + j * 3 + 2] = (byte)grad;
                            }
                        }
                        break;
                    case "Sobel"://solbel算子  
                        for (int i = 0; i < srcBmp.Height; i++)
                        {
                            for (int j = 0; j < srcBmp.Width; j++)
                            {
                                gradX = ptrSrc[Math.Abs(i - 1) % srcBmp.Height * bmpDataSrc.Stride + (j + 1) % srcBmp.Width * 3] +
                                        2 * ptrSrc[i * bmpDataSrc.Stride + (j + 1) % srcBmp.Width * 3] +
                                        ptrSrc[(i + 1) % srcBmp.Height * bmpDataSrc.Stride + (j + 1) % srcBmp.Width * 3] -
                                        ptrSrc[Math.Abs(i - 1) % srcBmp.Height * bmpDataSrc.Stride + Math.Abs(j - 1) % srcBmp.Width * 3] -
                                        2 * ptrSrc[i * bmpDataSrc.Stride + Math.Abs(j - 1) % srcBmp.Width * 3] -
                                        ptrSrc[(i + 1) % srcBmp.Height * bmpDataSrc.Stride + Math.Abs(j - 1) % srcBmp.Width * 3];
                                gradY = ptrSrc[Math.Abs(i - 1) % srcBmp.Height * bmpDataSrc.Stride + Math.Abs(j - 1) % srcBmp.Width * 3] +
                                        2 * ptrSrc[Math.Abs(i - 1) % srcBmp.Height * bmpDataSrc.Stride + j * 3] +
                                        ptrSrc[Math.Abs(i - 1) % srcBmp.Height * bmpDataSrc.Stride + (j + 1) % srcBmp.Width * 3] -
                                        ptrSrc[(i + 1) % srcBmp.Height * bmpDataSrc.Stride + Math.Abs(j - 1) % srcBmp.Width * 3] -
                                        2 * ptrSrc[(i + 1) % srcBmp.Height * bmpDataSrc.Stride + j * 3] -
                                        ptrSrc[(i + 1) % srcBmp.Height * bmpDataSrc.Stride + (j + 1) % srcBmp.Width * 3];
                                grad = Math.Sqrt(gradX * gradX + gradY * gradY);
                                grad = grad > 255 ? 255 : grad;
                                ptrDst[i * bmpDataDst.Stride + j * 3] = ptrDst[i * bmpDataDst.Stride + j * 3 + 1] = ptrDst[i * bmpDataDst.Stride + j * 3 + 2] = (byte)grad;
                            }
                        }
                        break;
                    default:
                        break;
                }
            }
            srcBmp.UnlockBits(bmpDataSrc);
            dstBmp.UnlockBits(bmpDataDst);

            return true;
        }
        /// <summary>
        /// 色彩转换公共方法
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="c"></param>
        /// <returns></returns>
        public static int getMax(int a, int b, int c)
        {
            int temp = 0;
            if (a < b)
            {
                temp = b;
            }
            else { temp = a; }
            if (temp < c)
            {
                temp = c;
            }
            return temp;
        }

        public static int getMin(int a, int b, int c)
        {
            int temp = 0;
            if (a > b)
            {
                temp = b;
            }
            else { temp = a; }
            if (temp > c)
            {
                temp = c;
            }
            return temp;
        }

    }
}

