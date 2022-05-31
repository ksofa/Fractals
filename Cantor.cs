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

    public class Cantor : Fractal
    {
        private int Space { get; set; }
        /// <summary>
        /// Конструктор для множества Кантора.
        /// </summary>
        /// <param name="m"></param>
        /// <param name="depth"></param>
        /// <param name="space"></param>
        public Cantor(MainWindow m, int depth, int space) : base(m, depth)
        {
            Space = space;
        }
        /// <summary>
        /// Метод для рисования.
        /// </summary>
        public override void Draw()
        {
            Point a = new(100, 300);
            Point b = new(900, 300);
            Paint(a, b, depth);
        }
        /// <summary>
        /// Метод отрисовки рекурсии.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="d"></param>
        public void Paint(Point a, Point b, int d)
        {
            if (d == 0) { return; }

            if (d == depth)
            {
                //Рисуй линию.
                Line cantor_line = new Line();
                cantor_line.X1 = a.X;
                cantor_line.Y1 = a.Y;
                cantor_line.X2 = b.X;
                cantor_line.Y2 = b.Y;
                cantor_line.Stroke = Brushes.Black;
                m.MyCanvas.Children.Add(cantor_line);
                Paint(a, b, d - 1);
            }
            else
            {
                //dx- шаг на треть.
                //Здесь задаю координаты 4 точек ( для построения через шаги). 
                double dx = (b.X - a.X) / 3;
                double x3 = a.X;
                double x4 = x3 + dx;
                double x6 = b.X;
                double x5 = x6 - dx;

                double y3 = a.Y + Space;
                double y6 = b.Y + Space;
                double y4 = y3;
                double y5 = y6;

                Line newLine = new Line();
                newLine.X1 = a.X;
                newLine.Y1 = a.Y;
                newLine.X2 = b.X;
                newLine.Y2 = b.Y;
                newLine.Stroke = Brushes.Black;
                newLine.StrokeThickness = 3;
                m.MyCanvas.Children.Add(newLine);

                Paint(new Point(x3, y3), new Point(x4, y4), d - 1);
                Paint(new Point(x5, y5), new Point(x6, y6), d - 1);
            }
        }
    }
}
