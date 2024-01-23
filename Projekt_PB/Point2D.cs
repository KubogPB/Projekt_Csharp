using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Projekt_PB
{
    internal class Point2D
    {
        public float x { get; set; }
        public float y { get; set; }


        //konstruktory
        public Point2D()
        {
            x = 0;
            y = 0;
        }

        public Point2D(float x, float y)
        {
            this.x = x;
            this.y = y;
        }

        public Point2D(Point2D p)
        {
            this.x = p.x;
            this.y = p.y;
        }

        public Point2D(float x1,  float y1, float x2, float y2)
        {
            this.x = x1 - x2;
            this.y = y1 - y2;
        }

        public Point2D(Point2D p1, Point2D p2)
        {
            this.x = p1.x - p2.x;
            this.y = p1.y - p2.y;
        }


        //metody
        public float VectorLength2()
        {
            return x*x + y*y;
        }

        public double VectorLength()
        {
            return Math.Sqrt(VectorLength2());
        }

        public float VectorLength2(Point2D p)
        {
            return (x - p.x)*(x - p.x) + (y - p.y)*(y - p.y);
        }

        public double VectorLength(Point2D p)
        {
            return Math.Sqrt(VectorLength2(p));
        }

        public float VectorLength2(float x , float y)
        {
            return (this.x - x) * (this.x - x) + (this.y - y) * (this.y - y);
        }

        public double VectorLength(float x, float y)
        {
            return Math.Sqrt(VectorLength2(x, y));
        }



        public Point2D GetVector(Point2D p)
        {
            return new Point2D(x - p.x, y - p.y);
        }

        public Point2D GetVector(float x, float y)
        {
            return new Point2D(this.x - x, this.y - y);
        }



        public void AddVector(Point2D p)
        {
            this.x += p.x;
            this.y += p.y;
        }

        public void AddVector(float x, float y)
        {
            this.x += x;
            this.y += y;
        }



        public void RotateVector(double angle)
        {
            double thisLength = this.VectorLength();
            this.x = (float) (thisLength * Math.Cos(angle));
            this.y = (float) (thisLength * Math.Sin(angle));
        }


        //metody statyczne
        public static float VectorLength2(Point2D p1, Point2D p2)
        {
            return (p1.x - p2.x) * (p1.x - p2.x) + (p1.y - p2.y) * (p1.y - p2.y);
        }

        public static double VectorLength(Point2D p1, Point2D p2)
        {
            return Math.Sqrt(VectorLength2(p1, p2));
        }

        public static float VectorLength2(float x1, float y1, float x2, float y2)
        {
            return (x1 - x2) * (x1 - x2) + (y1 - y2) * (y1 - y2);
        }

        public static double VectorLength(float x1, float y1, float x2, float y2)
        {
            return Math.Sqrt(VectorLength(x1, y1, x2, y2));
        }

        public static Point2D GetPoint(Point2D p1, Point2D p2)
        {
            return new Point2D(p1.x - p2.x, p1.y - p2.y);
        }

        public static Point2D GetVector(float x1, float y1, float x2, float y2)
        {
            return new Point2D(x1 - x2, y1 - y2);
        }

        //public static double Angle(Point2D p1, Point2D p2)
        //{
        //    double cossin = (p1.x * p2.x + p1.y * p2.y) / (p1.VectorLength() * p2.VectorLength());
        //    if (cossin < -1)
        //        cossin = cossin + 2;
        //    else if (cossin > 1)
        //        cossin = cossin - 2;
        //
        //    Console.WriteLine(cossin);
        //
        //    if (Math.Asin(cossin) > 0)
        //        return Math.Acos(cossin);
        //    else
        //        return -Math.Acos(cossin);
        //}


        //przeciążenia
        override public string ToString()
        {
            base.ToString();
            return String.Format("{0}, {1}", x, y);
        }


        //operatory
        public static Point2D operator + (Point2D p1, Point2D p2)
        {
            return new Point2D(p1.x + p2.x, p1.y + p2.y);
        }

        public static Point2D operator - (Point2D p1, Point2D p2)
        {
            return new Point2D(p1.x - p2.x, p1.y - p2.y);
        }

        public static Point2D operator + (Point2D p, float f)
        {
            return new Point2D(p.x + f, p.y + f);
        }

        public static Point2D operator - (Point2D p, float f)
        {
            return new Point2D(p.x - f, p.y - f);
        }

        public static Point2D operator * (Point2D p, float f)
        {
            return new Point2D(p.x * f, p.y * f);
        }

        public static Point2D operator / (Point2D p, float f)
        {
            return new Point2D(p.x / f, p.y / f);
        }

        public static bool operator == (Point2D p1, Point2D p2)
        {
            bool status = false;
            if (p1.x == p2.x && p1.y == p2.y)
                status = true;
            return status;
        }

        public static bool operator != (Point2D p1, Point2D p2)
        {
            bool status = true;
            if (p1 == p2)
                status = false;
            return status;
        }
    }
}
