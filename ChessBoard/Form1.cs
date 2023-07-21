using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChessBoard
{
    public partial class Form1 : Form
    {
       
        Graphics g;
        List<Figure> rectangles_lst = new List<Figure>();
        public Form1()
        {
            InitializeComponent();
            initCanvas();
        }
        private void initCanvas()
        {
            this.Size = new Size(900, 900);
        }
        private void addCell(Point point, Brush brush)
        {
            // this.Paint += Form1_Paint;

            Rectangle alarm = new Rectangle(0,0,135,135);
            if (alarm.Contains(point))
            {
                return;
            }

            g = CreateGraphics();
            int height = 90;
            int width = 90;
            Rectangle rectCell = new Rectangle(point.X - (width/2), point.Y - (height/2), width, height);

            /*if (rectCell.Contains(20,20))                                                 // доделать
            {
                return;    
            }*/


            Figure figure = new Figure(rectCell, brush);
            rectangles_lst.Add(figure);
            g.Clear(BackColor);
            foreach (var item in rectangles_lst)
            {
                g.FillRectangle(item.brush, item.rectangle);
            }
            //this.Refresh();
        }        
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = CreateGraphics();
            Rectangle rectCell = new Rectangle(10, 10, 90, 90);
            g.FillRectangle(Brushes.OrangeRed, rectCell);            
        }
        private void Form1_MouseDoubleClick(object sender, MouseEventArgs e)        // доделать
        {
            var last = rectangles_lst.LastOrDefault();       
            last.brush = Brushes.OrangeRed;            
        }
        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            addCell(e.Location, Brushes.Green);
            
        }
        private void Form1_Resize(object sender, EventArgs e)
        {
            string mess = string.Empty;
            int counter = 1;
            foreach (var item in rectangles_lst)
            {
                mess += $"№{counter++} {item.rectangle.X} : { item.rectangle.Y} " + "\n";
            }   
            MessageBox.Show($"{mess}");
        }
                
    }
}
