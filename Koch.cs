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
    public class Koch : Fractal
    {

        /// <summary>
        /// Конструктор для Кривой Коха.
        /// </summary>
        /// <param name="m"></param>
        /// <param name="depth"></param>
        public Koch(MainWindow m, int depth) : base(m, depth)
        {
        }
        /// <summary>
        ///  Метод для рисования.
        /// </summary>
        public override void Draw()
        {

            Point a = new(100, 500);
            Point b = new(900, 500);
            Paint_Koch(a, b, depth);
        }
        /// <summary>
        /// Метод для отрисовки рекурсии.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="d"></param>
        public void Paint_Koch(Point a, Point b, int d)
        {
            if (d == 0)
            {
                return;
            }
            if (d == depth)
            {
                // Рисуем линию.
                Line myline = new Line();
                myline.X1 = a.X;
                myline.Y1 = a.Y;
                myline.X2 = b.X;
                myline.Y2 = b.Y;
                myline.Stroke = Brushes.Black;
                m.MyCanvas.Children.Add(myline);
                Paint_Koch(a, b, d - 1);
            }
            else
            {
                //Считаем координаты по алгоритму ( по трети) и (2/3). 
                double x3 = a.X + (b.X - a.X) * 1 / 3;
                double y3 = a.Y + (b.Y - a.Y) * 1 / 3;


                double x4 = a.X + (b.X - a.X) * 2 / 3;
                double y4 = a.Y + (b.Y - a.Y) * 2 / 3;
                //Закрашием белым отрезок.
                Line newLine = new Line();
                newLine.X1 = x3;
                newLine.Y1 = y3;
                newLine.X2 = x4;
                newLine.Y2 = y4;
                newLine.Stroke = Brushes.White;
                newLine.StrokeThickness = 3;
                m.MyCanvas.Children.Add(newLine);
                //Т.к. треугольник равносторонний , то можем вычислить сторону ( по основанию).
                double triangle_a = Math.Sqrt((b.Y - a.Y) * (b.Y - a.Y) + (b.X - a.X) * (b.X - a.X)) / 3;
                //Считаем угол.
                double angle = Math.PI - (Math.Atan2(b.Y - a.Y, b.X - a.X) + Math.PI / 3);
                //Координаты верхушки кривой.
                double x5 = x3 - triangle_a * Math.Cos(angle);
                double y5 = y3 + triangle_a * Math.Sin(angle);
                //Рисуем наклонную право.
                Line firstLine = new Line();
                firstLine.X1 = x3;
                firstLine.Y1 = y3;
                firstLine.X2 = x5;
                firstLine.Y2 = y5;
                firstLine.Stroke = Brushes.Black;
                m.MyCanvas.Children.Add(firstLine);

                Paint_Koch(new Point(x3, y3), new Point(x5, y5), d - 1);
                //Рисуем наклонную влево.
                Line secondLine = new Line();
                secondLine.X1 = x5;
                secondLine.Y1 = y5;
                secondLine.X2 = x4;
                secondLine.Y2 = y4;
                secondLine.Stroke = Brushes.Black;
                m.MyCanvas.Children.Add(secondLine);
                //Продолжаем рекурсию.
                Paint_Koch(new Point(x5, y5), new Point(x4, y4), d - 1);
                Paint_Koch(new Point(a.X, a.Y), new Point(x3, y3), d - 1);
                Paint_Koch(new Point(x4, y4), new Point(b.X, b.Y), d - 1);

            }


        }
    }
}
