using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Frac
{

    public class Triangle : Fractal
    {
        /// <summary>
        /// Конструктор треугольника Серпинского.
        /// </summary>
        /// <param name="m"></param>
        /// <param name="depth"></param>
        public Triangle(MainWindow m, int depth) : base(m, depth)
        {

        }
        /// <summary>
        /// Это метод рисования.
        /// </summary>
        public override void Draw()
        {

            Point a = new(100, 100);
            Point b = new(500, 400 * Math.Sqrt(3));
            Point c = new Point(900, 100);
            Paint_Triangle(a, b, c, depth);
        }
        /// <summary>
        /// Метод отрисовки треугольника.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="c"></param>
        /// <param name="d"></param>
        public void Paint_Triangle(Point a, Point b, Point c, int d)
        {
            if (d == 0) { return; }
            if (d == depth)
            {
                //Треугольник
                Polygon triangle_draw = new Polygon();
                triangle_draw.Points = new PointCollection() { a, b, c };
                triangle_draw.Stroke = Brushes.Black;
                m.MyCanvas.Children.Add(triangle_draw);
                Paint_Triangle(a, b, c, d - 1);
            }
            else
            {
                //Считаю точки рекурссии(серединки).
                Point middleAB = new Point((c.X - a.X) / 4 + a.X, (b.Y - a.Y) / 2 + a.Y);
                Point middleAC = new Point((c.X + a.X) / 2, a.Y);
                Point middleBC = new Point(3 * (c.X - a.X) / 4 + a.X, (b.Y - a.Y) / 2 + a.Y);
                Polygon triangle_draw = new Polygon();
                triangle_draw.Points = new PointCollection() { middleAB, middleAC, middleBC };
                triangle_draw.Stroke = Brushes.Black;
                m.MyCanvas.Children.Add(triangle_draw);
                // 3 раза вызываю для 3х внутренних треугольников.
                Paint_Triangle(a, middleAB, middleAC, d - 1);
                Paint_Triangle(middleAB, b, middleBC, d - 1);
                Paint_Triangle(middleAC, middleBC, c, d - 1);
            }
        }
    }
}
