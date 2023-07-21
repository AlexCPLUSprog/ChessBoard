using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChessBoard
{
    internal class Figure
    {
        //private Rectangle _rectangle;
        public Rectangle rectangle { get; }

        // private Brush _brush;
        public Brush brush { get; set;  }

        public Figure(Rectangle _rectangle, Brush _brush)
        {
            this.rectangle = _rectangle;
            this.brush = _brush;           
        }
    }
}
