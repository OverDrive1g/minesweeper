using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace WpfApplication1.Core
{
    public class Cell
    {
        public WrapPanel Panel;
        public Point Position;

        public Grid Figure;

        public Cell(ref WrapPanel panel, Point position)
        {
            Panel = panel;
            Position = position;
            Figure = new Grid() { Margin = new Thickness(2, 2, 2, 2), Width = 39, Height = 39 };
            Rectangle rect = new Rectangle() { Fill = Brushes.Coral };
            Figure.Children.Add(rect);
        }

        public void Draw()
        {
            Panel.Children.Add(Figure);
        }
    }
}
