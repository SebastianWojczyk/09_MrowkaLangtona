using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _09_MrowkaLangtona
{
    class Ant
    {
        public enum EnumDirection { Up, Right, Down, Left };

        private Point location;
        private Color color;
        private EnumDirection direction;
        private Timer timer;

        public Point Location { get => location; private set => location = value; }
        public Color Color { get => color; private set => color = value; }
        public EnumDirection Direction { get => direction; private set => direction = value; }

        public Ant(Point point, Color color, int interval)
        {
            this.Location = point;
            this.Color = color;
            Direction = EnumDirection.Right;
            timer = new Timer();
            timer.Interval = interval;
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        public delegate bool delegate_isEmpty_setColor(Ant a);
        public event delegate_isEmpty_setColor Field_IsEmpty_SetColor;
        private void Timer_Tick(object sender, EventArgs e)
        {
            if (Field_IsEmpty_SetColor != null && Field_IsEmpty_SetColor(this))
            {
                switch (Direction)
                {
                    case EnumDirection.Up:
                        Direction = EnumDirection.Left;
                        break;
                    case EnumDirection.Left:
                        Direction = EnumDirection.Down;
                        break;
                    case EnumDirection.Down:
                        Direction = EnumDirection.Right;
                        break;
                    case EnumDirection.Right:
                        Direction = EnumDirection.Up;
                        break;
                }
            }
            else
            {
                switch (Direction)
                {
                    case EnumDirection.Up:
                        Direction = EnumDirection.Right;
                        break;
                    case EnumDirection.Right:
                        Direction = EnumDirection.Down;
                        break;
                    case EnumDirection.Down:
                        Direction = EnumDirection.Left;
                        break;
                    case EnumDirection.Left:
                        Direction = EnumDirection.Up;
                        break;
                }
            }
            switch (Direction)
            {
                case EnumDirection.Up:
                    Location = new Point(Location.X, Location.Y - 1);
                    break;
                case EnumDirection.Right:
                    Location = new Point(Location.X + 1, Location.Y);
                    break;
                case EnumDirection.Down:
                    Location = new Point(Location.X, Location.Y + 1);
                    break;
                case EnumDirection.Left:
                    Location = new Point(Location.X - 1, Location.Y);
                    break;
            }
        }
    }
}
