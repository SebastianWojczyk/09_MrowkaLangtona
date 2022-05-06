using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09_MrowkaLangtona
{
    class Board
    {
        Color[,] map;
        List<Ant> ants;

        public Board(int width, int height)
        {
            Map = new Color[width, height];
            for(int x=0; x<width; x++)
            {
                for(int y=0; y<height; y++)
                {
                    Map[x, y] = Color.White;
                }
            }
            Ants = new List<Ant>();
        }

        public int Width { get => Map.GetLength(0); }
        public int Height { get => Map.GetLength(1); }
        public Color[,] Map { get => map; private set => map = value; }
        internal List<Ant> Ants { get => ants; private set => ants = value; }

        internal void AddAnt(Ant ant)
        {
            Ants.Add(ant);
            ant.Field_IsEmpty_SetColor += Ant_fieldIsEmpty_SetColor;
        }

        public delegate void delegate_fieldChanged(Point p);
        public event delegate_fieldChanged FieldChanged;
        private bool Ant_fieldIsEmpty_SetColor(Ant a)
        {
            bool isEmpty;
            if (Map[a.Location.X, a.Location.Y] == Color.White)
            {
                Map[a.Location.X, a.Location.Y] = a.Color;
                isEmpty = true;
            }
            else
            {
                Map[a.Location.X, a.Location.Y] = Color.White;
                isEmpty = false;
            }
            if (FieldChanged != null)
            {
                FieldChanged(a.Location);
            }
            return isEmpty;
        }
    }
}
