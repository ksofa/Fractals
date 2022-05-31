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
    public abstract class Fractal
    {
       
        protected MainWindow m;
        protected int depth;
        /// <summary>
        /// Это родительский (базовый) класс.
        /// </summary>
        /// <param name="m"></param>
        /// <param name="depth"></param>
        protected Fractal(MainWindow m, int depth)
        {
            this.m = m;
            this.depth = depth;
            //При отрисовки очисти доску.
            m.MyCanvas.Children.Clear();
        }
        /// <summary>
        /// Абстрактный метод рисования.
        /// </summary>
        public abstract void Draw();
    }
}