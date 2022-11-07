using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ssp3
{
    public partial class Form1 : Form
    {
        Graphics gr;       //объявляем объект - графику, на которой будем рисовать
        Pen p;             //объявляем объект - карандаш, которым будем рисовать контур
        SolidBrush fon;    //объявляем объект - заливки, для заливки соответственно фона
        SolidBrush fig;    //и внутренности рисуемой фигуры


        int rad;          // переменная для хранения радиуса рисуемых кругов
        Random rand;      // объект, для получения случайных чисел
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Dock the PictureBox to the form and set its background to white.
           // pictureBox1.Dock = DockStyle.Fill;
            pictureBox1.BackColor = Color.Black;
            // Connect the Paint event of the PictureBox to the event handler method.
            pictureBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox1_Paint);
            pictureBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox1_Paint);

            // Add the PictureBox control to the Form.
            this.Controls.Add(pictureBox1);

        }
        private void pictureBox1_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
        {
            gr = e.Graphics;
            p = new Pen(Color.Lime);           // задали цвет для карандаша 
            fon = new SolidBrush(Color.Black); // и для заливки
            fig = new SolidBrush(Color.Purple);

            rad = 40;                          //задали радиус для круга
            rand = new Random();               //инициализируем объект для рандомных числе



            // вызываем написанную нами функцию, для прорисовки круга
            // случайным образом выбрав перед этим координаты центра
            //paint();
           // Thread myThread1 = new Thread(paint);
            //myThread1.Start();

        }

        public void paint()
        {
            int x, y;

            for (int i = 0; i < 3; i++)
            {
                x = rand.Next(pictureBox1.Width);
                y = rand.Next(pictureBox1.Height);
                DrawCircle(x, y);
            }
        }


        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        //опишем функцию, которая будет рисовать круг по координатам его центра
        void DrawCircle(int x, int y)
        {
            int xc, yc;
            xc = x - rad;
            yc = y - rad;
            gr.FillEllipse(fig, xc, yc, rad, rad);
            gr.DrawEllipse(p, xc, yc, rad, rad);

        }
        public void cycl1()
        {
            int i = 0;
            while (i < 50)
            {
                
                Thread.Sleep(400);
                i++;
                continue;
            }
        }
        public void cycl2()
        {
            int i = 0;
            while (i < 50)
            {
                this.Invalidate();
                Thread.Sleep(100);
                i++;
                continue;
            }
        }
    }
}
  