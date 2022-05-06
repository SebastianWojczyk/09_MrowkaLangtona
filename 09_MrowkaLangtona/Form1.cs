using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _09_MrowkaLangtona
{
    public partial class Form1 : Form
    {
        private Board myBoard;
        private const int fieldSize = 20;

        private Graphics graphics;
        public Form1()
        {
            InitializeComponent();

            myBoard = new Board(40, 30);
            myBoard.AddAnt(new Ant(new Point(10, 10), Color.Red, 50));
            myBoard.AddAnt(new Ant(new Point(20, 15), Color.Green, 100));
            myBoard.AddAnt(new Ant(new Point(30, 20), Color.Blue, 150));

            myBoard.FieldChanged += FieldDraw;

            pictureBoxBoard.Width = myBoard.Width * fieldSize;
            pictureBoxBoard.Height = myBoard.Height * fieldSize;
            pictureBoxBoard.Image = new Bitmap(pictureBoxBoard.Width, pictureBoxBoard.Height);
            graphics = Graphics.FromImage(pictureBoxBoard.Image);

            DrawBoard();
        }

        private void DrawBoard()
        {
            graphics.Clear(Color.White);

            for (int x = 0; x < myBoard.Width; x++)
            {
                for (int y = 0; y < myBoard.Height; y++)
                {
                    graphics.FillRectangle(new SolidBrush(myBoard.Map[x, y]),
                                          x * fieldSize,
                                          y * fieldSize,
                                          fieldSize,
                                          fieldSize);
                    graphics.DrawRectangle(new Pen(Color.Gray),
                                           x * fieldSize,
                                           y * fieldSize,
                                           fieldSize,
                                           fieldSize);
                }
            }

            pictureBoxBoard.Refresh();
        }
        void FieldDraw(Point p)
        {
            graphics.FillRectangle(new SolidBrush(myBoard.Map[p.X, p.Y]),
                                          p.X * fieldSize,
                                          p.Y * fieldSize,
                                          fieldSize,
                                          fieldSize);
            graphics.DrawRectangle(new Pen(Color.Gray),
                                   p.X * fieldSize,
                                   p.Y * fieldSize,
                                   fieldSize,
                                   fieldSize);
            pictureBoxBoard.Refresh();
        }
    }
}
