using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Partial_Ex4
{
    public partial class Form1 : Form
    {
        
        public Bitmap bitmap;
        public Graphics graphics;
        public Random random=new Random();
        List<Point3D> points = new List<Point3D>();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            pictureBox1.Width = Width; pictureBox1.Height = Height;
            pictureBox1.Height = Height;
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                Close();
            }
        }
       
        //timerul executa metoda la fiecare milisecunda
        private void timer1_Tick(object sender, EventArgs e)
        {
            //bitmap reprezinta imaginea in cazul de fata
            //graphics este un obiect care deseneaza peste o imagine
            bitmap = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            graphics = Graphics.FromImage(bitmap);

            //adaugam cateva puncte la intamplare
            points.Add(GenerateRandomPoint3D());
            points.Add(GenerateRandomPoint3D());
            points.Add(GenerateRandomPoint3D());
            points.Add(GenerateRandomPoint3D());

            //parcurgem intreaga lista de puncte
            for(int i = 0; i < points.Count; i++)
            {
                //desenam punctul si ne apropiem de el
                points[i].Draw(this);
                points[i].z--;

                //verificam daca punctul a iesit in afara ecranului,
                //atunci il scoatem din lista
                if (points[i].z < -100)
                {
                    points.RemoveAt(i);
                    i--;
                }
            }
            //punem bitmap ca imagine a picturebox-ului
            pictureBox1.Image = bitmap;
        }
        
        
       private Point3D GenerateRandomPoint3D()
       {
            int x =0, y = 0;
            //punctul poate fi generat in 4 zone
            //zone corespunzatoare unui grafic de coordonate
            int zone = random.Next(4);
            switch (zone)
            {
                case 0:     //zona din stanga (vest)
                    x = random.Next(Width / 4);
                    y = random.Next(Height);
                    break;
                case 1:     //zona din dreapta (est)
                    x=random.Next(3 * Width / 4,Width);
                    y = random.Next(Height);
                    break;
               case 2:      //zona de sus (nord)
                    x= random.Next(Width);
                    y= random.Next(Height / 4);
                    break;
               case 3:      //zona de jos (sud
                    x=random.Next(Width);
                    y=random.Next(3  * Height / 4, Height);
                    break;
            }
            //initializam fiecare punct ca fiind cel mai indepartat punct de noi, cu z = 100
            return new Point3D(x, y, 100);
       }

        

        

        
    }
}
