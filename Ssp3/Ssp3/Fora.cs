using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Ssp3
{
    public class Fora : System.Windows.Forms.Form

    {
        private System.ComponentModel.Container components = null;

        Random rand;      // объект, для получения случайных чисел
        float height;
        float width;
        float x1, x2, rad, y1, y2,x3,y3;
        float finish_width, finish_height;
        float speedx1, speedx2;
        float speedy1, speedy2;
        bool goUp = false;
        bool goUp2 = true;
        bool goUp3 = true;
        bool right1 = true;
        bool right2 = true;
        bool right3 = true;
        public bool th1 = true;
        public bool th2 = true;
        public bool th3 = true;

        private Font fnt = new Font("Arial", 40);
       
        ArrayList list = new ArrayList();

        public Fora()
        {
            InitializeComponent();
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()

        {
            rand = new Random();
            this.components = new System.ComponentModel.Container();
            this.Size = new System.Drawing.Size(600, 600);
            rad = 40;
            height = this.Size.Height;
            width = this.Size.Width;
            x1 = x2 = x3 = 0;
            y1 = height / 2 ;
            y2 = height / 3 ;
            y3 = 2 * height / 3;
            finish_height = height - 2 * rad;
            finish_width = width - 3 * rad / 2;
            speedx1 = (float)rand.Next(1, 10) / 5;
            speedy1 = (float)rand.Next(1, 10) / 5;
            speedx2 = (float)rand.Next(1, 10) / 5;
            speedy2 = (float)rand.Next(1, 10) / 5;

            this.Text = "FORA";
            this.BackColor = System.Drawing.Color.Bisque;
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.painting);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.painting1);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.painting2);
            //this.Paint += new System.Windows.Forms.PaintEventHandler(this.painting);
        }

        public void painting(object sender, System.Windows.Forms.PaintEventArgs e)

        {
            e.Graphics.FillEllipse(Brushes.Red, x1, y1, rad, rad);
            if (list.Count == 3)
            {
                e.Graphics.DrawString("win " + list[0],
        fnt, System.Drawing.Brushes.Blue, new Point(300, 300));

            }

        }
        public void painting1(object sender, System.Windows.Forms.PaintEventArgs e)

        {
            
            e.Graphics.FillEllipse(Brushes.Purple, x2, y2, rad, rad);
            if (list.Count == 3)
            {
                e.Graphics.DrawString("win " + list[0],
        fnt, System.Drawing.Brushes.Blue, new Point(300, 300));

            }

        }
        public void painting2(object sender, System.Windows.Forms.PaintEventArgs e)

        {
            e.Graphics.FillEllipse(Brushes.Yellow, x3, y3, rad, rad);
            if (list.Count == 3)
            {
                e.Graphics.DrawString("win " + list[0],
        fnt, System.Drawing.Brushes.Blue, new Point(300, 300));
            }

        }

        public void cycl1()
        {
            while (x1 < finish_width)
            {

                this.Invalidate();
                Thread.Sleep(1);
                double cRedYellow = Math.Sqrt(Math.Pow(Math.Abs(x1 - x3), 2) + Math.Pow(Math.Abs(y1 - y3), 2));
                double cRedPurple = Math.Sqrt(Math.Pow(Math.Abs(x1 - x2), 2) + Math.Pow(Math.Abs(y1 - y2), 2));

                if (cRedYellow <= rad)
                {
                    if (x1 < x3)
                    {
                        right1 = false;
                    }
                    if (goUp) { goUp = false; }
                    else { goUp = true; }
                }
                if (cRedPurple <= rad)
                {
                    if (x1 < x2)
                    {
                        right1 = false;
                    }
                    if (goUp) { goUp = false; }
                    else { goUp = true; }
                }
                if (goUp)
                {
                    if (y1 > 0) { y1 -= speedy1; }
                    else { goUp = false; y1 += speedy1; }
                }else
                {
                    if (y1 < finish_height) { y1 += speedy1; }
                    else { goUp = true; y1 -= speedy1; }
                }
                if (right1) { x1 += speedx1; }
                else { if (x1 > 0) { x1 -= speedx1; }
                    else { right1 = true; x1 += speedx1; }
                }
                
                continue;
            }
            //x1 -= speedx1;
            //if (goUp) { y1 += speedy1; }
            //else
            //{
            //    { y1 -= speedy1; }
            //}
            list.Add("Red");
        }
        public void cycl2()
        {
            while (x2 < finish_width)
            {
                this.Invalidate();
                Thread.Sleep(1);
                double cPurpleYellow = Math.Sqrt(Math.Pow(Math.Abs(x2 - x3), 2) + Math.Pow(Math.Abs(y2 - y3), 2));
                double cPurpleRed = Math.Sqrt(Math.Pow(Math.Abs(x1 - x2), 2) + Math.Pow(Math.Abs(y1 - y2), 2));

                if (cPurpleYellow <= rad)
                {
                    if (x2 < x3)
                    {
                        right2 = false;
                    }
                    if (goUp2) { goUp2 = false; }
                    else { goUp2 = true; }
                } else if (cPurpleRed <= rad)
                {
                    if (x2 < x1)
                    {
                        right2 = false;
                    }
                    if (goUp2) { goUp2 = false; }
                    else { goUp2 = true; }
                }
                if (goUp2)
                {
                    if (y2 > 0) { y2 -= speedy2; }
                    else { goUp2 = false; y2 += speedy2; }
                }
                else
                {
                    if (y2 < finish_height) { y2 += speedy2; }
                    else { goUp2 = true; y2 -= speedy2; }
                }
                if (right2) { x2 += speedx2; }
                else
                {
                    if (x2 > 0) { x2 -= speedx2; }
                    else { right2 = true; x2 += speedx2; }
                }
                continue;
            }
            list.Add("Purple");
            //x2 -= speedx2;
            //if (goUp) { y2 += speedy2; }
            //else
            //{
            //    { y2 -= speedy2; }
            //}
        }
        public void cycl3()
        {
            while (x3 < finish_width)
            {
                this.Invalidate();
                Thread.Sleep(1);
                double cYellowRed = Math.Sqrt(Math.Pow(Math.Abs(x1 - x3), 2) + Math.Pow(Math.Abs(y1 - y3), 2));
                double cYellowPurple = Math.Sqrt(Math.Pow(Math.Abs(x3 - x2), 2) + Math.Pow(Math.Abs(y3 - y2), 2));
                if (cYellowPurple <= rad)
                {
                    if (x3 < x2)
                    {
                        right3 = false;
                    }
                    if (goUp3) { goUp3= false; }
                    else { goUp3 = true; }
                }
                if (cYellowRed <= rad)
                {
                    if (x3 < x1)
                    {
                        right3 = false;
                    }
                    if (goUp3) { goUp3 = false; }
                    else { goUp3 = true; }
                }
                if (goUp3)
                {
                    if (y3 > 0) { y3 -= speedy2; }
                    else { goUp3 = false; y3 += speedy2; }
                }
                else
                {
                    if (y3 < finish_height) { y3 += speedy2; }
                    else { goUp3 = true; y3 -= speedy2; }
                }
                if (right3) { x3 += speedx2; }
                else
                {
                    if (x3 > 0) { x3 -= speedx2; }
                    else { right3 = true; x3 += speedx2; }
                }
                continue;
            }
            list.Add("Yellow");
            //x3 -= speedx2;
            //if (goUp) { y3 += speedy2; }
            //else
            //{
            //    { y3 -= speedy2; }
            //}
        }

        public void cycl4()
        {
            bool t = true;
            while (t)
            {
                if (list.Count == 3)
                {
                    this.Invalidate();
                    t = false;
                }
                
            }
            
        }

    }
}
