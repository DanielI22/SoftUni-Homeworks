﻿using System;
using System.Collections.Generic;
using System.Text;

namespace _1._Class_Box_Data
{
    public class Box
    {
        private double length;
        private double width;
        private double height;

        public Box(double length, double width, double height)
        {
            Length = length;
            Width = width;
            Height = height;
        }

        public double Length
        {
            get { return length; }

            private set 
            { 
                if(value <= 0)
                {
                    throw new ArgumentException($"Length cannot be zero or negative.");
                }
                length = value; 
            }
        }

        public double Width
        {
            get { return width; }

            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException($"Width cannot be zero or negative.");
                }
                width = value;
            }
        }

        public double Height
        {
            get { return height; }

            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException($"Height cannot be zero or negative.");
                }
                height = value;
            }
        }


        public double SurfaceArea()
        {
            return 2*Width * Length + 2 * Height * Length + 2 * Width * Height;
        }

        public double LateralSurfaceArea()
        {
            return SurfaceArea() -2 * Width * Length;
        }

        public double Volume()
        {
            return Width * Length * Height;
        }
    }
}
