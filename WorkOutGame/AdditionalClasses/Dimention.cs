using System;

namespace WorkOutGame.AdditionalClasses
{
    public class Dimention
    {
        private int _x, _y, _width, _height;
        public int X
        {
            get => _x;
            set
            {
                if (value < 0) throw new ArgumentException();
                _x = value;
            }
        }

        public int Y
        {
            get => _y;
            set
            {
                if (value < 0) throw new ArgumentException();
                _y = value;
            }
        }

        public int Width
        {
            get => _width;
            set
            {
                if (value < 0) throw new ArgumentException();
                _width = value;
            }
        }

        public int Height
        {
            get => _height;
            set
            {
                if (value < 0) throw new ArgumentException();
                _height = value;
            }
        }

        public Dimention(int x, int y, int squareLenght) : this(x, y, squareLenght, squareLenght) { }

        public Dimention(int x, int y, int width, int height)
        {
            X = x;
            Y = y;
            Width = width;
            Height = height;
        }
    }
}