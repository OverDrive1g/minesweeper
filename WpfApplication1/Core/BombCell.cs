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
    public class BombCell:Cell
    {
        public Rectangle cell;
        public BombCell(ref WrapPanel panel, Point position): base(ref panel, position)
        {

            cell = new Rectangle() { Fill = new SolidColorBrush(Colors.Gray) };
            
            Figure.Children.Add(cell);
            Figure.PreviewMouseLeftButtonDown += (sender, args) =>
            {
                cell.Fill = Brushes.PaleVioletRed;
            };
        }
    }
}
