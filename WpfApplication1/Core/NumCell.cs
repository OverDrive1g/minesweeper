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
    class NumCell:Cell
    {
        public int Num { get; set; }

        public Rectangle cell;
        public TextBlock text;
        public NumCell(ref WrapPanel panel, Point position, int num)
            : base(ref panel, position)
        {
            Num = num;

            
            cell = new Rectangle() { Fill = new SolidColorBrush(Colors.Gray) };


            Figure.Children.Add(cell);

            Figure.PreviewMouseLeftButtonDown += (sender, args) =>
            {
                text = new TextBlock() { Text = "" + Num };
                cell.Fill = Brushes.LightGray;
                Figure.Children.Add(text);
                
            };
        }
    }
}
