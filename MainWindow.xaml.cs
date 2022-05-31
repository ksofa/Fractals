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
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Обработчик для ковра Серпинского.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DepthSerpinckiCarpet_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {

            int depth = (int)double.Parse(DepthSerpincki.Value.ToString());
            // MessageBox.Show(depth.ToString());
            var serp = new Serpinski(this, depth);
            serp.Draw();
        }
        /// <summary>
        /// Обработчик для кривой Коха.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Depth_Koch(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            int depth = (int)double.Parse(Koch_depth.Value.ToString());
            // MessageBox.Show(depth.ToString());
            var koch_fr = new Koch(this, depth);
            koch_fr.Draw();
        }
        /// <summary>
        /// Обработчик для треугольника Серпинского.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Triangle_Serp_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            int depth = (int)double.Parse(Triangle_Serp.Value.ToString());
            // MessageBox.Show(depth.ToString());
            var triangle_Serp = new Triangle(this, depth);
            triangle_Serp.Draw();
        }
        /// <summary>
        /// Обработчик для дерева.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RecursionDepth_Tree_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {

            try
            {
                int depth = (int)double.Parse(RecursionDepth_Tree.Value.ToString());
                double angle_L = double.Parse(angle_left.Value.ToString());
                double angle_R = double.Parse(angle_right.Value.ToString());
                double coefficient = double.Parse(coef.Value.ToString());
                PythTree tree = new PythTree(this, depth, angle_L, angle_R, coefficient);
                tree.Draw();
            }

            catch (Exception)
            {


            }

        }
        /// <summary>
        /// Обработчик для мн-ва Кантора.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void depth_Cantor_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {

            int depth = (int)double.Parse(depth_Cantor.Value.ToString());
            // MessageBox.Show(depth.ToString());
            int space = (int)double.Parse(space_Cantor.Value.ToString());
            Cantor cantor = new Cantor(this, depth, space);
            cantor.Draw();

        }

    }


}
