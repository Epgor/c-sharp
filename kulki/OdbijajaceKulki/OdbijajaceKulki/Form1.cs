using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Reflection;

namespace OdbijajaceKulki
{
    public partial class Form1 : Form
    {
        public Form1()
        {           
            InitializeComponent();
            typeof(Panel).InvokeMember("DoubleBuffered",
   BindingFlags.SetProperty | BindingFlags.Instance | BindingFlags.NonPublic,
   null, PanelGlowny, new object[] { true });
        }

        //zmienne globalne        
        Color Kolor = Color.Red;
        private List<Figura> figury = new List<Figura>();
        PointF Klikniecie;   

        //definujemy kolor
        private void DefiniujKolorGuzik(object sender, EventArgs e)
        {
            if(colorDialog1.ShowDialog()==DialogResult.OK)
            {            
                Kolor = colorDialog1.Color;
            }
        }

        private void Panel_Paint(object sender, PaintEventArgs e)
        {
            //maluj wszystkie kulki z kontenera
            foreach (Figura f in figury)
                f.Namaluj(e.Graphics);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //dodawanie kulki
            int Wx = Convert.ToInt32(numericUpDown1.Value);
            int Wy = Convert.ToInt32(numericUpDown2.Value);
            int Rozmiar = Convert.ToInt32(numericUpDown3.Value);
     
            int PozX = Convert.ToInt32(numericUpDown5.Value);
            int PozY = Convert.ToInt32(numericUpDown6.Value);

            Klikniecie = new PointF(PozX, PozY);

            PointF wektor = new PointF(Wx, Wy);

            if (comboBox1.SelectedIndex == 0)
            {
                Kwadrat K = new Kwadrat(Klikniecie, wektor, Rozmiar, Kolor, PanelGlowny.Width, PanelGlowny.Height);
                figury.Add(K);
            }

            if (comboBox1.SelectedIndex == 1)
            {
                Kulka K = new Kulka(Klikniecie, wektor, Rozmiar, Kolor, PanelGlowny.Width, PanelGlowny.Height);
                figury.Add(K);
            }

            if (comboBox1.SelectedIndex == 2)
            {
                KreskowanaPilka K = new KreskowanaPilka(Klikniecie, wektor, Rozmiar,  Kolor, PanelGlowny.Width, PanelGlowny.Height);
                figury.Add(K);
            }
            if (comboBox1.SelectedIndex == 3)
            {

                LatajacaSzachownica K = new LatajacaSzachownica(Klikniecie, wektor, Rozmiar, Kolor, PanelGlowny.Width, PanelGlowny.Height);
                figury.Add(K);
            }
            if (comboBox1.SelectedIndex == 4)
            {

                Bomba K = new Bomba(Klikniecie, wektor, Rozmiar, Kolor, PanelGlowny.Width, PanelGlowny.Height);
                figury.Add(K);
            }
            if (comboBox1.SelectedIndex == 5)
            {

                Celownik K = new Celownik(Klikniecie, wektor, Rozmiar, Kolor, PanelGlowny.Width, PanelGlowny.Height);
                figury.Add(K);
            }
            if (comboBox1.SelectedIndex == 6)
            {

                OcenaZeStatystyki K = new OcenaZeStatystyki(Klikniecie, wektor, Rozmiar, Kolor, PanelGlowny.Width, PanelGlowny.Height);
                figury.Add(K);
            }

        }

        private void PanelGlowny_SizeChanged(object sender, EventArgs e)
        {//funkcja aktualizująca rozmiar kulki na podstawie rozmiaru okna
            foreach (Figura f in figury)
                f.Skaluj(PanelGlowny.Width, PanelGlowny.Height);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {//tykanie zegara - odswiezanie kulek
            foreach (Figura f in figury)
                f.Ruch();
            //odswierz  plansze z zaktualizowanymi kulkami
            PanelGlowny.Refresh();
        }

        private void Start_Stop(object sender, EventArgs e)
        {//włącz/wytłącz czasomierz
            if (timer1.Enabled)            
                timer1.Stop();            
            else           
                timer1.Start();           
        }

    }

    abstract class Figura
    {
        protected System.Media.SoundPlayer boom = new System.Media.SoundPlayer("boom.wav");
        protected System.Media.SoundPlayer pifpaf = new System.Media.SoundPlayer("clag.wav");
        protected int SzerokoscOkna, WysokoscOkna;
        //Właściwości kulki
        protected PointF Pozycja;
        protected PointF WektorRuchu;
        protected float Rozmiar;
       
        protected Brush Pedzel;


        public Figura(PointF Pozycja, PointF WektorRuchu, float Rozmiar,  Color Kolor, int szer, int wys)
        {
            this.Pozycja = Pozycja;
            this.WektorRuchu = WektorRuchu;
            this.Rozmiar = Rozmiar;
            
            Pedzel = new SolidBrush(Kolor);
            this.SzerokoscOkna = szer;
            this.WysokoscOkna = wys;
        }

        public void Skaluj(int szer, int wys)
        {
            //taka fukncja - proporcjonalne skalowanie kulek po zmiqnie okna
            this.Rozmiar = this.Rozmiar * (szer * wys) /(this.SzerokoscOkna * this.WysokoscOkna);
            this.SzerokoscOkna = szer;
            this.WysokoscOkna = wys;           
        }

        public void Ruch()
        {
            //Poruszanie
            OdbijKulkeOdSciany();
            Pozycja.X +=  WektorRuchu.X;
            Pozycja.Y +=  WektorRuchu.Y;
        }

        public void DajGlos()
        {
            Random r = new Random();
            if (r.Next(0, 2) == 1)
                boom.Play();
            else
                pifpaf.Play();
        }

        abstract public void OdbijKulkeOdSciany();
  
        abstract public void Namaluj(Graphics g);
    }

    class Kulka : Figura
    {
        

        public Kulka(PointF Pozycja, PointF WektorRuchu, float Rozmiar, Color Kolor, int szer, int wys) : base(Pozycja, WektorRuchu, Rozmiar, Kolor, szer, wys)
        { }
        override
        public void Namaluj(Graphics g)
        {
            //Rysujemy Kulki
            g.FillEllipse(Pedzel, Pozycja.X - Rozmiar, Pozycja.Y - Rozmiar, Rozmiar * 2, Rozmiar * 2);
        }
        override
        public void OdbijKulkeOdSciany()
        {            
                //odbijanie kulek od scian
            if (Pozycja.X + Rozmiar > SzerokoscOkna || Pozycja.X - Rozmiar < 0)
            {
                WektorRuchu.X = -WektorRuchu.X;
                DajGlos();
            }

            if (Pozycja.Y + Rozmiar > WysokoscOkna || Pozycja.Y - Rozmiar < 0)
            {
                WektorRuchu.Y = -WektorRuchu.Y;
                DajGlos();
            }
        }
    }

    class Kwadrat : Figura
    {
        public Kwadrat(PointF Pozycja, PointF WektorRuchu, float Rozmiar,  Color Kolor, int szer, int wys) : base(Pozycja, WektorRuchu, Rozmiar, Kolor, szer, wys)
        { }
        override
        public void Namaluj(Graphics g)
        {
            //Rysujemy Kwadraty
            g.FillRectangle(Pedzel, Pozycja.X - Rozmiar, Pozycja.Y - Rozmiar, Rozmiar * 2, Rozmiar * 2);
        }
        override
        public void OdbijKulkeOdSciany()
        {

            //odbijanie kulek od scian
            if (Pozycja.X + Rozmiar > SzerokoscOkna || Pozycja.X - Rozmiar < 0)
            {
                WektorRuchu.X = -WektorRuchu.X;
                DajGlos();
            }

            if (Pozycja.Y + Rozmiar > WysokoscOkna || Pozycja.Y - Rozmiar < 0)
            {
                WektorRuchu.Y = -WektorRuchu.Y;
                DajGlos();
            }

        }
    }

    class KreskowanaPilka : Figura
    {

        HatchBrush kreski = new HatchBrush(
           HatchStyle.Horizontal,
           Color.Red,
           Color.FromArgb(255, 128, 255, 255));

        public KreskowanaPilka(PointF Pozycja, PointF WektorRuchu, float Rozmiar,  Color Kolor, int szer, int wys) : base(Pozycja, WektorRuchu, Rozmiar,  Kolor, szer, wys)
        { }
        override
        public void Namaluj(Graphics g)
        {
            //Rysujemy Kulki
            g.FillEllipse(kreski, Pozycja.X - Rozmiar, Pozycja.Y - Rozmiar, Rozmiar * 2, Rozmiar * 2);
        }
        override
        public void OdbijKulkeOdSciany()
        {
            //odbijanie kulek od scian
            if (Pozycja.X + Rozmiar > SzerokoscOkna || Pozycja.X - Rozmiar < 0)
            {
                WektorRuchu.X = -WektorRuchu.X;
                DajGlos();
            }

            if (Pozycja.Y + Rozmiar > WysokoscOkna || Pozycja.Y - Rozmiar < 0)
            {
                WektorRuchu.Y = -WektorRuchu.Y;
                DajGlos();
            }
        }
    }

    class LatajacaSzachownica : Figura
    {
    
        Image Obraz = Image.FromFile("maze.png");

        public LatajacaSzachownica(PointF Pozycja, PointF WektorRuchu, float Rozmiar, Color Kolor, int szer, int wys) : base(Pozycja, WektorRuchu, Rozmiar,  Kolor, szer, wys)
        { }
        override
        public void Namaluj(Graphics g)
        {
            //Rysujemy Kulki
            g.DrawImage(Obraz, Pozycja.X, Pozycja.Y);

          
        }
        override
        public void OdbijKulkeOdSciany()//odbijanie zostało wykonane abstrakcyjnie, ze względu na naturę obrazu
        {//tutaj uznaję, że Punkt obrazu to jego lewy gorny rog i od niego sprawdzam kolizje
            if (Pozycja.X + Obraz.Width > SzerokoscOkna || Pozycja.X < 0)
            {
                WektorRuchu.X = -WektorRuchu.X;
                DajGlos();
            }
            if (Pozycja.Y + Obraz.Height > WysokoscOkna || Pozycja.Y < 0)
            { 
                WektorRuchu.Y = -WektorRuchu.Y;
                DajGlos();
            }
        }


    }
    class Bomba : Figura
    {

        Image Obraz = Image.FromFile("bomb.png");

        public Bomba(PointF Pozycja, PointF WektorRuchu, float Rozmiar, Color Kolor, int szer, int wys) : base(Pozycja, WektorRuchu, Rozmiar, Kolor, szer, wys)
        { }
        override
        public void Namaluj(Graphics g)
        {
            //Rysujemy Kulki
            g.DrawImage(Obraz, Pozycja.X, Pozycja.Y);


        }
        override
        public void OdbijKulkeOdSciany()//odbijanie zostało wykonane abstrakcyjnie, ze względu na naturę obrazu
        {//tutaj uznaję, że Punkt obrazu to jego lewy gorny rog i od niego sprawdzam kolizje
            if (Pozycja.X + Obraz.Width > SzerokoscOkna || Pozycja.X < 0)
            {
                WektorRuchu.X = -WektorRuchu.X;
                DajGlos();
            }
            if (Pozycja.Y + Obraz.Height > WysokoscOkna || Pozycja.Y < 0)
            {
                WektorRuchu.Y = -WektorRuchu.Y;
                DajGlos();
            }
        }


    }
    class OcenaZeStatystyki : Figura
    {

        Image Obraz = Image.FromFile("dwa.png");

        public OcenaZeStatystyki(PointF Pozycja, PointF WektorRuchu, float Rozmiar, Color Kolor, int szer, int wys) : base(Pozycja, WektorRuchu, Rozmiar, Kolor, szer, wys)
        { }
        override
        public void Namaluj(Graphics g)
        {
            //Rysujemy Kulki
            g.DrawImage(Obraz, Pozycja.X, Pozycja.Y);


        }
        override
        public void OdbijKulkeOdSciany()//odbijanie zostało wykonane abstrakcyjnie, ze względu na naturę obrazu
        {//tutaj uznaję, że Punkt obrazu to jego lewy gorny rog i od niego sprawdzam kolizje
            if (Pozycja.X + Obraz.Width > SzerokoscOkna || Pozycja.X < 0)
            {
                WektorRuchu.X = -WektorRuchu.X;
                DajGlos();
            }
            if (Pozycja.Y + Obraz.Height > WysokoscOkna || Pozycja.Y < 0)
            {
                WektorRuchu.Y = -WektorRuchu.Y;
                DajGlos();
            }
        }


    }
    class Celownik : Figura
    {

        Image Obraz = Image.FromFile("aim.png");

        public Celownik(PointF Pozycja, PointF WektorRuchu, float Rozmiar, Color Kolor, int szer, int wys) : base(Pozycja, WektorRuchu, Rozmiar, Kolor, szer, wys)
        { }
        override
        public void Namaluj(Graphics g)
        {
            //Rysujemy Kulki
            g.DrawImage(Obraz, Pozycja.X, Pozycja.Y);


        }
        override
        public void OdbijKulkeOdSciany()//odbijanie zostało wykonane abstrakcyjnie, ze względu na naturę obrazu
        {//tutaj uznaję, że Punkt obrazu to jego lewy gorny rog i od niego sprawdzam kolizje
            if (Pozycja.X + Obraz.Width > SzerokoscOkna || Pozycja.X < 0)
            {
                WektorRuchu.X = -WektorRuchu.X;
                DajGlos();
            }
            if (Pozycja.Y + Obraz.Height > WysokoscOkna || Pozycja.Y < 0)
            {
                WektorRuchu.Y = -WektorRuchu.Y;
                DajGlos();
            }
        }


    }


    public class MojPanel : Panel           //klasa pojawi sie na Toolbox (po przekompilowaniu), o ile jest public i ma konstr bezparametrowego.
    {
        public MojPanel()
        {
            DoubleBuffered = true;
        }
    }

}
