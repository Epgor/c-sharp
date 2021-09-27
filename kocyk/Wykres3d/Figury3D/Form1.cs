using punkt;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using t3d;
using wektor;
using Kocyk;



namespace Kocyk
{
    public partial class GlownaForma : Form
    {
        public Brush Pedzelek = Brushes.Black;
        public Pen Pisak = Pens.Green;
        int[,,] Zyje = new int[X, X, X];
        int gennr = 0, deadnr = 0, bornnr = 0;
        private Punkt Obserwator;
        private Rectangle DziedzinaFunkcjiWykresu = new Rectangle(0, 0, 1, 1);
        private static int X = 3;
        int var1, var2, var3, var4;
        double R = 200;
        double Fi = 45;
        double Teta = 60;

        private Wykres3d wykres;
            

        public GlownaForma()
        {
            InitializeComponent();

            var1 = Convert.ToInt32(numericUpDown1.Value);
            var2 = Convert.ToInt32(numericUpDown2.Value);
            var3 = Convert.ToInt32(numericUpDown3.Value);
            var4 = Convert.ToInt32(numericUpDown4.Value);

            Obserwator = Punkt.RFiTetaToXYZ(R, Fi, Teta);

            wykres = new Wykres3d(Obserwator, DziedzinaFunkcjiWykresu, PanelGlowny.ClientRectangle, X, Zyje, Pedzelek, Pisak);
        }

        private void MainMojPanel_Paint(object sender, PaintEventArgs e)
        {
            wykres.Rysuj(e.Graphics);
        }


        private void PoruszKoc()
        {

            wykres = new Wykres3d(Obserwator, DziedzinaFunkcjiWykresu, PanelGlowny.ClientRectangle, X, Zyje,Pedzelek, Pisak);

            PanelGlowny.Invalidate();
        }


        private void ColorButton_Click(object sender, EventArgs e)
        {
            if (DialogKoloru.ShowDialog() == DialogResult.OK)
                Pedzelek = new SolidBrush(DialogKoloru.Color);
            PanelGlowny.Invalidate();
        }

        private void LinieButton_Click(object sender, EventArgs e)
        {
            if (DialogKoloru.ShowDialog() == DialogResult.OK)
                Pisak = new Pen(DialogKoloru.Color);

            PanelGlowny.Invalidate();
        }

        private void GlownaForma_Load(object sender, EventArgs e)
        {
            //przyszły rozwój
        }

        private void ZmienR(object sender, EventArgs e)
        {
            R = Convert.ToInt32(trackBar1.Value);
            Obserwator = Punkt.RFiTetaToXYZ(R, Fi, Teta);
        }


        private void timer1_Tick(object sender, EventArgs e)
        {
            CheckConw();
            gennr++;
            panel1.Refresh();
            panel2.Refresh();
            panel3.Refresh();
            PoruszKoc();           
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            string s = Convert.ToString(bornnr);
            PointF p = new PointF(1, 1);
            Graphics g = panel2.CreateGraphics();
            g.DrawString(s, this.Font, Brushes.Black, p);
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {
            string s = Convert.ToString(deadnr);
            PointF p = new PointF(1, 1);
            Graphics g = panel3.CreateGraphics();
            g.DrawString(s, this.Font, Brushes.Black, p);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Random L = new Random();
            Random R = new Random();
            int Li = L.Next((X), (X*X));
            for (int x = 1; x < Li; x++)
            {
                Zyje[R.Next(1, X-1), R.Next(1, X-1), R.Next(1, X-1)] = 1;
                                
            }

        }

        private void ZegarButton(object sender, EventArgs e)
        {

            var1 = Convert.ToInt32(numericUpDown1.Value);
            var2 = Convert.ToInt32(numericUpDown2.Value);
            var3 = Convert.ToInt32(numericUpDown3.Value);
            var4 = Convert.ToInt32(numericUpDown4.Value);

            CheckConw();
            PoruszKoc();
            gennr++;
            panel1.Refresh();
            panel2.Refresh();
            panel3.Refresh();
        }



        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            string s = Convert.ToString(gennr);
            PointF p = new PointF(1, 1);
            Graphics g = panel1.CreateGraphics();
            g.DrawString(s, this.Font, Brushes.Black, p);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (timer1.Enabled)
                timer1.Stop();
            else
                timer1.Start();
        }

        private int HowMany(int x, int y, int z)
        {
            int Sum = 0;

            for (int xi = x; xi < x + 3; xi++)
                for (int yi = y; yi < y + 3; yi++)
                    for (int zi = z; zi < z + 3; zi++)
                        Sum += Zyje[(xi - 1),(yi - 1),(zi -1)];

            return (Sum-1);

        }

        private void CheckConw()
        {

            int[,,] TempMatrix = new int[X, X,X];
            int x, y,z, state, neigh;

            for (x = 1; x < X - 1; ++x)
            {

                for (y = 1; y < X - 1; ++y)
                {

                    for (z = 1; z < X - 1; ++z)
                    {
                        state = Zyje[x, y, z];

                        neigh = HowMany(x, y, z);

                        if (state == 1)
                        {
                            if (neigh < var1 || neigh > var2)
                            {
                                state = 0;
                                deadnr++;
                        
                            }
                        }

                        else
                        {
                            if (neigh <= var3 && neigh >= var4)
                            {
                                state = 1;

                                bornnr++;

                            }
                        }
                        TempMatrix[x, y, z ] = state;
                    }
                }
            }

            for (x = 1; x <X - 1; ++x)

            {

                for (y = 1; y < X - 1; ++y)

                {
                    for (z = 1; z < X - 1; ++z)
                    {
          
                        Zyje[x, y, z] = TempMatrix[x, y, z];
                        // colors[GameSize * x + y] += TempMatrix[x, y];
                    }
                }

            }
        }



    }

    public class MojPanel : Panel
    {
        public MojPanel()
            : base()
        {
            DoubleBuffered = true;
        }
    }
}
