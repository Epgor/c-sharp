using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace Gra_w_Zycie
{
    public partial class Form1 : Form
    {


        public class Data

        {

            public int dvar1 = 1, dvar2 = 2, dvar3 = 3, dvar4 = 4,dGenNr=0,born=0,dead=0;

            public List<int> dparts = new List<int>();

            public List<int> dcolor = new List<int>();

        }


        public Data data = new Data();


        private void SaveData() //zapisz dane z programu do kontenera data
        {
            
            data.dvar1 = Convert.ToInt32(Var1.Value);
            data.dvar2 = Convert.ToInt32(Var2.Value);
            data.dvar3 = Convert.ToInt32(Var3.Value);
            data.dvar4 = Convert.ToInt32(Var4.Value);

            data.dGenNr = gennr;

            data.dparts = parts;
            data.dcolor = colors;

            data.born = born;
            data.dead = dead;
        }

        private void LoadData() //wczytaj dane z kontenera data do programu
        {
            Var1.Value = data.dvar1;
            Var2.Value = data.dvar2;
            Var3.Value = data.dvar3;
            Var4.Value = data.dvar4;

            gennr = data.dGenNr;

            parts = data.dparts;
            colors = data.dcolor;

            born = data.born;
            dead = data.dead;
        }

        private void SerializeData()
        {

            StreamWriter sw = new StreamWriter("dane.xml");

            try

            {

                XmlSerializer serializer = new XmlSerializer(typeof(Data));

                serializer.Serialize(sw, data);

                sw.Close();

            }

            catch (Exception err)

            {

                Text = err.ToString();          //wyswietl komunikat w pasku tytułowym

            }

            finally

            {

                sw.Close();

            }


        }

        private void DeserializeData()
        {
            StreamReader sr = new StreamReader("dane.xml");

            try

            {



                XmlSerializer serializer = new XmlSerializer(typeof(Data));

                data = (Data)serializer.Deserialize(sr);

            }

            catch (Exception err)

            {

                Text = err.ToString();          //wyswietl komunikat w pasku tytułowym

            }

            finally

            {

                sr.Close();

            }
        }


        int GameSize = 10;
        int CellSize = 50;
        int born = 0, dead = 0;
        public List<int> parts = new List<int>();
        public List<int> colors = new List<int>();
        
        int gennr = 0;
       
        int var1 = 2,
            var2 = 3,
            var3 = 3,
            var4 = 3;
  
        public Form1()
        {
            InitializeComponent();
            ListResize();
        }

        private void ListResize()
        {
            parts.Clear();
            colors.Clear();
            for (int x = 0; x < GameSize; x++)
            {
                for (int y = 0; y < GameSize; y++)
                {
                    parts.Add(0);
                    colors.Add(0);
                }
            }
        }

        private int[,] SetSize()
        {
            int NewSize = Convert.ToInt32(NumberOfCells.Value);
            int[,] Matrix = new int[NewSize, NewSize];

            GameSize = NewSize;
            CellSize = 500 / GameSize;
            for (int x = 0; x < GameSize; x++)
            {
                for (int y = 0; y < GameSize; y++)
                {
                    Matrix[x, y] = parts[GameSize*x + y];
                }
            }

            return Matrix;
        }

        private Brush SetColor(int x, int y)
        {
            SolidBrush myBrush = new SolidBrush(Color.DarkGray);
            if (colors[x * GameSize + y] == 0)
                myBrush.Color = Color.DarkGray;
            if (colors[x * GameSize + y] == 1)
                myBrush.Color = Color.Black;
            if (colors[x * GameSize + y] == 2)
                myBrush.Color = Color.Purple;
            if (colors[x * GameSize + y] == 3)
                myBrush.Color = Color.DarkBlue;
            if (colors[x * GameSize + y] == 4)
                myBrush.Color = Color.Blue;
            if (colors[x * GameSize + y] == 5)
                myBrush.Color = Color.LightBlue;
            if (colors[x * GameSize + y] == 6)
                myBrush.Color = Color.LightGreen;
            if (colors[x * GameSize + y] == 7)
                myBrush.Color = Color.Green;
            if (colors[x * GameSize + y] == 8)
                myBrush.Color = Color.Yellow;
            if (colors[x * GameSize + y] == 9)
                myBrush.Color = Color.Orange;
            if (colors[x * GameSize + y] == 10)
                myBrush.Color = Color.OrangeRed;
            if (colors[x * GameSize + y] == 11)
                myBrush.Color = Color.Red;
            if (colors[x * GameSize + y] >= 11)
                myBrush.Color = Color.DarkRed;

       
     
            return myBrush;
        }

        private void MainPanel_Paint(object sender, PaintEventArgs e)
        {
            int[,] Matrix = SetSize();

            int cs = CellSize;
            Graphics g = MainPanel.CreateGraphics();
            //rysuje linie - bardziej efektywne niż zagnieżdżone rysowanie kwadratów
            for (int y = 0; y < GameSize; ++y)
            {
                g.DrawLine(Pens.Black, 0, y * cs, GameSize * cs, y * cs);
                g.FillRectangle(Brushes.Gray, 0, y * cs, cs, cs);
                g.FillRectangle(Brushes.Gray, (GameSize-1)*cs, y * cs, cs, cs);

            }

            for (int x = 0; x < GameSize; ++x)
            {
                g.DrawLine(Pens.Black, x * cs, 0, x * cs, GameSize * cs);
                g.FillRectangle(Brushes.Gray, x * cs, 0, cs, cs);
                g.FillRectangle(Brushes.Gray, x * cs, (GameSize-1)*cs, cs, cs);
            }
            //koloruje wybrane kwadraty
            for (int x = 0; x < GameSize; x++)
            {
                for (int y = 0; y < GameSize; y++)
                {
                    Brush myBrush = SetColor(x, y);
                    if (Matrix[x, y] == 1)
                    g.FillRectangle(myBrush, x * cs, y * cs, cs, cs);
                    
                    
                }
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int[,] Matrix = SetSize();

            Random R = new Random();


            int zi = Convert.ToInt32(numericUpDown1.Value);


            for (int i = 0; i < zi; i++)
                Matrix[R.Next(0, GameSize), R.Next(0, GameSize)] = 1;
          

            for(int x = 1; x < GameSize - 1; x++)

            {

                for (int y = 1; y < GameSize - 1; y++)

                {

                    parts[GameSize * x + y] = Matrix[x, y];
                    if (parts[GameSize * x + y] == 1)
                        colors[GameSize * x + y]+=1;


                }

            }
            MainPanel.Refresh();
        }   

        private void Licznik_Paint(object sender, PaintEventArgs e)
        {
            string s = Convert.ToString(gennr);
            PointF p = new PointF(1, 1);
            Graphics g = Licznik.CreateGraphics();
            g.DrawString(s, this.Font, Brushes.Black, p);
        }

        private void ChangeSize_Click(object sender, EventArgs e)
        {
            int NewSize = Convert.ToInt32(NumberOfCells.Value);
           
            int[,] Matrix = new int[NewSize, NewSize];

            GameSize = NewSize;
            CellSize = 500/GameSize;
            gennr = 0;
            ListResize();
            Licznik.Refresh();           
            MainPanel.Refresh();
        }

        private void MainPanel_MouseMove(object sender, MouseEventArgs e)
        {
            int x, y, X, Y;
            if (e.Button == MouseButtons.Left)
            {
                x = e.X;
                y = e.Y;
                X = x / CellSize;
                Y = y / CellSize;
                parts[X*GameSize + Y] = 1;
                colors[X *GameSize + Y]+=1;
                MainPanel.Refresh();
            }
    
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SaveData();

            SerializeData();
        }

        private void button3_Click(object sender, EventArgs e)
        {

            DeserializeData();

            LoadData();

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            string s = Convert.ToString(dead);
            PointF p = new PointF(1, 1);
            Graphics g = panel2.CreateGraphics();
            g.DrawString(s, this.Font, Brushes.Black, p);
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            string s = Convert.ToString(born);
            PointF p = new PointF(1, 1);
            Graphics g = panel1.CreateGraphics();
            g.DrawString(s, this.Font, Brushes.Black, p);
        }

        private void NextGen_Click(object sender, EventArgs e)
        {
            int zi = Convert.ToInt32(numericUpDown2.Value);
            var1 = Convert.ToInt32(Var1.Value);
            var2 = Convert.ToInt32(Var2.Value);
            var3 = Convert.ToInt32(Var3.Value);
            var4 = Convert.ToInt32(Var4.Value);

            for (int i = 0; i < zi; i++)
                { 
                gennr++;  
                CheckConw();
                }
            Licznik.Refresh();
            MainPanel.Refresh();
                     
        }

        private int HowMany(int x, int y)
        {
            int[,] Matrix = SetSize();
            int Sum;

            Sum = Matrix[x - 1,y - 1] + Matrix[x,y - 1] +
                   Matrix[x + 1,y - 1] + Matrix[x - 1,y] +
                     Matrix[x + 1,y] + Matrix[x - 1,y + 1] +
                       Matrix[x,y + 1] + Matrix[x + 1,y + 1];

            return Sum;

        }

        private void CheckConw()
        {
            int[,] Matrix = SetSize();
            
            int[,] TempMatrix = new int [GameSize,GameSize];
            int x, y, state, neigh;

            for(x = 1; x<GameSize-1; ++x)
            {

                for(y = 1; y<GameSize-1; ++y)
                {

                    state = Matrix[x,y];

                    neigh = HowMany(x, y);

                    if(state == 1)
                    {
                        if (neigh < var1 || neigh > var2)
                        {
                            state = 0;
                            dead++;
                            panel2.Refresh();
                        }
                    }

                    else
                    {
                        if (neigh <= var3 && neigh >= var4)
                        {
                            state = 1;
                           
                            born++;
                            panel1.Refresh();
                        }
                    }
                        TempMatrix[x,y] = state;
                }
            }

            for(x = 1; x<GameSize-1; ++x)

            {

                for(y = 1; y<GameSize-1; ++y)

                {

                    parts[GameSize * x+y] = TempMatrix[x,y];
                    colors[GameSize * x + y] += TempMatrix[x, y];
                }

            }
        }
    }
}
