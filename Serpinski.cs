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
    public class Serpinski : Fractal
    {
        /// <summary>
        /// Конструктор ковра Серпинского.
        /// </summary>
        /// <param name="m"></param>
        /// <param name="depth">
        /// Глубина.
        /// </param>
        public Serpinski(MainWindow m, int depth) : base(m, depth)
        {

        }
        /// <summary>
        /// Метод рисования.
        /// </summary>
        public override void Draw()
        {

            Point a = new(100, 100);
            Point b = new(900, 900);
            Paint(a, b, depth);
        }
        /// <summary>
        /// Это метод отрисовки рекурссии.
        /// </summary>
        /// <param name="a">
        /// точка "начальная"
        /// </param>
        /// <param name="b"></param>
        /// точка "конечная"
        /// <param name="d"></param>
        public void Paint(Point a, Point b, int d)
        {
            if (d == 0) { return; }

            if (d == depth)
            {
                // квадрат
                Line myline = new Line();
                Point c = new(a.X, (a.Y + b.Y) / 2);
                Point w = new(b.X, (a.Y + b.Y) / 2);
                myline.X1 = c.X;
                myline.Y1 = c.Y;
                myline.X2 = w.X;
                myline.Y2 = w.Y;
                myline.StrokeThickness = w.X - c.X;
                myline.Stroke = Brushes.Black;
                m.MyCanvas.Children.Add(myline);
                Paint(a, b, d - 1);
            }
            else
            {
                Line myline = new Line();
                //Считаю 2 точки для рекурсии(c и w).
                Point c = new(a.X + (b.X - a.X) / 3, (a.Y + b.Y) / 2);
                Point w = new(a.X + 2 * (b.X - a.X) / 3, (a.Y + b.Y) / 2);
                myline.X1 = c.X;
                myline.Y1 = c.Y;
                myline.X2 = w.X;
                myline.Y2 = w.Y;
                myline.StrokeThickness = w.X - c.X;
                myline.Stroke = Brushes.White;
                m.MyCanvas.Children.Add(myline);
                //Для удобства шаги(dx и dy).
                double dx = b.X - a.X;
                double dy = b.Y - a.Y;
                //1 квадрат.
                Paint(new Point(a.X, a.Y + 2 * dy / 3), new Point(a.X + dx / 3, b.Y), d - 1);
                //2 квадрат.
                Paint(new Point(a.X + dx / 3, a.Y + 2 * dy / 3), new Point(a.X + 2 * dx / 3, b.Y), d - 1);
                //3 квадрат.
                Paint(new Point(a.X + 2 * dx / 3, a.Y + 2 * dy / 3), new Point(b.X, b.Y), d - 1);
                //4 квадрат.
                Paint(new Point(a.X + 2 * dx / 3, a.Y + dy / 3), new Point(b.X, a.Y + 2 * dy / 3), d - 1);
                //5 квадрат
                Paint(new Point(a.X + 2 * dx / 3, a.Y), new Point(b.X, a.Y + dy / 3), d - 1);
                //6 квадрат
                Paint(new Point(a.X + dx / 3, a.Y), new Point(a.X + 2 * dx / 3, a.Y + dy / 3), d - 1);
                //7 квадрат
                Paint(new Point(a.X, a.Y), new Point(a.X + dx / 3, a.Y + dy / 3), d - 1);
                //8 квадрат.
                Paint(new Point(a.X, a.Y + dy / 3), new Point(a.X + dx / 3, a.Y + 2 * dy / 3), d - 1);

            }
        }
    }
}
