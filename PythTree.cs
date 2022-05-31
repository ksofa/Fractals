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
    public class PythTree : Fractal

    {
        /// <summary>
        /// Свойства.
        /// </summary>
        private double Angle_Left { get; set; }
        private double Angle_Right { get; set; }
        private double Coefficient { get; set; }

        /// <summary>
        /// Конструктор для дерева.
        /// </summary>
        /// <param name="m"></param>
        /// <param name="depth"></param>
        /// <param name="angle_l"></param>
        /// <param name="angle_r"></param>
        /// <param name="coef"></param>
        public PythTree(MainWindow m, int depth, double angle_l, double angle_r, double coef) : base(m, depth)
        {
            Angle_Left = angle_l;
            Angle_Right = angle_r;
            Coefficient = coef;
        }
        /// <summary>
        ///  Метод рисования.
        /// </summary>
        /// <returns></returns>
        public override void Draw()
        {
            Point a = new(500, 50);
            Point b = new(500, 250);

            Paint(a, b, depth);
        }
        /// <summary>
        /// Метод для отрисовки рекурсии. 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="d"></param>
        private void Paint(Point a, Point b, int d)
        {
            if (d == 0) { return; }

            Line myline = new Line();
            myline.X1 = a.X;
            myline.Y1 = a.Y;
            myline.X2 = b.X;
            myline.Y2 = b.Y;
            myline.Stroke = Brushes.Black;
            double length = Math.Sqrt((b.Y - a.Y) * (b.Y - a.Y) + (b.X - a.X) * (b.X - a.X));
            myline.StrokeThickness = length / 10;
            //Нарисовали вертикальную линию ("ствол").
            m.MyCanvas.Children.Add(myline);
            length = length / Coefficient;
            //Считаем уголок для координаты ( построения) и строим ( вызов рекурсии) отрезок влево).
            double angle = Angle_Left - (Math.Atan2(b.Y - a.Y, b.X - a.X));
            Paint(b, new Point(b.X + (length * Math.Cos(angle)), (b.Y - (length * Math.Sin(angle)))), d - 1);
            //Считаем уголок для координаты ( построения) и строим ( вызов рекурсии) отрезок вправо).
            angle = Angle_Right + (Math.Atan2(b.Y - a.Y, b.X - a.X));
            Paint(b, new Point(b.X + (length * Math.Cos(angle)), (b.Y + (length * Math.Sin(angle)))), d - 1);


        }


    }
}
