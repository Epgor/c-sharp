using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace paint
{
    public partial class Form1 : Form
    {
        Color kolor;
        Pen mupen = new Pen(Color.Blue);
        int szer_old = 1;
        int wys_old = 1;

        int flag = 0;
        int pointx, szer = 1;
        int pointy, wys = 1;
        int sz, w = 0;
        public static Graphics Graphics { get; private set; }

        public Form1()
        {
            InitializeComponent();
            kolor = Color.FromArgb(255, 255, 255, 255);
            //mupen.Color = System.Drawing.kolor;
           
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
      
        private void button1_Click(object sender, EventArgs e)
        {
            int szer = panel2.ClientRectangle.Width;
            int wys = panel2.ClientRectangle.Height;
            // DrawImagePointF(0);
            flag = 1;
            //   Form1_Paint(this, null);
            panel2_Paint_1(this, null);
            
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void p(object sender, EventArgs e)
        {

        }

        public void Form1_Paint(object sender, PaintEventArgs e)
        {
    
            
     
        }

        private void panel2_MouseMove(object sender, MouseEventArgs e)
        {

            if (flag == 2)
            {
                if (e.Button == MouseButtons.Left)
                {
                    pointx = e.X;
                    pointy = e.Y;
                    panel2_Paint_1(this, null);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int a = Convert.ToInt32(numericUpDown4.Value);
            int r = Convert.ToInt32(numericUpDown1.Value);
            int g = Convert.ToInt32(numericUpDown2.Value);
            int b = Convert.ToInt32(numericUpDown3.Value);
            kolor = Color.FromArgb(a, r, g, b);
            mupen.Color = kolor;
            flag = 2;
        }

        private void colorDialog1_HelpRequest(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            
           
                flag = 3;
                panel2_Paint_1(this, null);
            
        }

        private void panel2_Resize(object sender, EventArgs e)
        {
            szer_old = panel2.ClientRectangle.Width;
            wys_old = panel2.ClientRectangle.Height;
            panel2.Refresh();
           

        }

        private void numericUpDown4_ValueChanged(object sender, EventArgs e)
        {

        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            
           
        }

        private void panel2_Paint_1(object sender, PaintEventArgs e)
        {
            Graphics g2 = panel2.CreateGraphics();
            int r = 50;
            int szer = panel2.ClientRectangle.Width;
            int wys = panel2.ClientRectangle.Height;
            if (flag == 0)
            {
                Graphics g = e.Graphics;

               
                //rect
                g.FillRectangle(Brushes.Yellow, szer / 2 - r, wys / 2 - r, 2 * r, 2 * r);
                //eli
                g.DrawEllipse(Pens.Red, szer / 2, wys / 2, 2 * r, 2 * r);

                //nowa stała do wektorowania grafiki
              //  float WektorekX = szer / szer_old;
            //    float WektorekY = wys / wys_old;

                //punkty Krzywej
                PointF[] points = {
                    new PointF(szer*0/szer,wys*0/wys), new PointF(szer*100/szer,wys*50/wys), new PointF(szer*200/szer,wys*200/wys)
                              };
                //punkty wielokąta
                //699 124,243 118,597 371,452 29,289 378
                Point[] poly = { new Point(699 * szer/szer_old, 124 * wys/wys_old), new Point(243 * szer/szer_old, 118 * wys/wys_old), new Point(597 * szer/szer_old, 371 * wys/wys_old), new Point(452 * szer/szer_old, 29 * wys/wys_old), new Point(289 * szer/szer_old, 378 * wys/wys_old)};
                //krzywa
                g.DrawCurve(Pens.Red, points);
                //łuk
                g.DrawArc(Pens.Red, szer / 4, wys / 4, (szer / 4) + (2 * r), wys / 4, szer / 4, (wys / 4) + (2 * r));
                //eli
                g2.DrawEllipse(System.Drawing.Pens.Purple, szer / 2, wys / 2, 100, 200);
                //text
                String text = "*Sztuka Współczesna*";
                g.DrawString(text, this.Font, Brushes.MediumSpringGreen, 600 * szer/szer_old, 400 * wys/wys_old);
                //wielokąt
                g.DrawPolygon(Pens.Red, poly);

            }



            if (flag == 1)
            {

                g2.DrawEllipse(System.Drawing.Pens.Purple, sz, w, 100, 200);
                sz = sz + 5;
                w = w + 5;

            }

            if (flag == 2) { 
            g2.DrawEllipse(mupen, pointx, pointy, 2, 2);
            }

            if (flag == 3)
            {
                int ss = szer / 3 + sz;
                int ww = wys / 3 + w;
                int wx = 5;
                int wy = 5;
                for (int i = 0; i<300; i++)
                {
                   

                    
                  

                    if (ss +100>= szer)
                    {
                        wx = -wx;
                       
                    }
                    else if (ss  <= 0)
                    {
                        wx = -wx;
                        
                    }
                    else if (ww +200>= wys)
                    {
                       
                        wy = -wy;
                    }
                    else if (ww <= 0)
                    {
                       
                        wy = -wy;
                    }
                    ss += wx;
                    ww += wy;

                    g2.DrawEllipse(System.Drawing.Pens.Purple, ss, ww, 100, 200);
                }
            }

        }
    }
}
