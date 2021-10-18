using System;
using System.Drawing;
using System.Windows.Forms;

namespace H_fractal.Forms
{
    public partial class Form1 : Form
    {
        private int height_; //высота
        private int width_; // ширина

        public Form1()
        {
            InitializeComponent();
            height_ = pictureBox.Height; 
            width_ = pictureBox.Width; 
        }

        private void H(int x, int y, int size) //функция отрисовки одной Н
        {
            var myPen = new Pen(Color.Black, 1);
            //Объявляем объект класса Graphics и предоставляем ему возможность рисования на pictureBox
            var g = Graphics.FromHwnd(pictureBox.Handle);

            g.DrawLine(myPen, x - size, y - size, x - size, y + size);
            g.DrawLine(myPen, x - size, y, x + size, y);
            g.DrawLine(myPen, x + size, y - size, x + size, y + size);
        }

        private void H_fractal(int x1, int y1, int size, int minimum)
        {
            //вершины фигуры Н
            int x11; int y11;
            int x01; int y01;
            int x00; int y00;
            int x10; int y10;
            x11 = x1 + size;
            y11 = y1 + size;
            x01 = x1 - size;
            y01 = y1 + size;
            x10 = x1 + size;
            y10 = y1 - size;
            x00 = x1 - size;
            y00 = y1 - size;

            H(x1, y1, size); //рисуем одну фигуру Н
            size /= 2; //уменьшаем размер в 2 раза
                                
            if (size >= minimum) //если размер не меньше минимального, то рисуем в 4-х вершинах
            {
                H_fractal(x11, y11, size, minimum);
                H_fractal(x01, y01, size, minimum);
                H_fractal(x10, y10, size, minimum);
                H_fractal(x00, y00, size, minimum);
            }
        }

        private void pictureBox_Click(object sender, EventArgs e)//по нажатию на pictureBox1
        {
            H_fractal(width_ / 2, height_ / 2, 128, 2);
            //H_fractal(координата центра по горизонтали,вертикали,размер первой Н, размер последней Н)
        }
    }
}
