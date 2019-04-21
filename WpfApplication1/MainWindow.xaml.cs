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
using WpfApplication1.Core;

namespace WpfApplication1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        

        public MainWindow()
        {
            InitializeComponent();

            Random rnd = new Random();
            List<Cell> cells = new List<Cell>();
            List<Cell> bombs = new List<Cell>();


            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    cells.Add(new EmptyCell(ref BattleGrid, new Point(i, j)));
                }
            }

            for (int i = 0; i < 10; i++)
            {
                var x = rnd.Next(10);
                var y = rnd.Next(10);
                var fined = bombs.Find(item => item.Position.X == x && item.Position.Y == y);
                if (fined == null)
                {
                    var fres = cells.Find(item => item.Position.X == x && item.Position.Y == y);
                    var r = cells.Remove(fres);
                    
                    var bomb = new BombCell(ref BattleGrid, new Point(x, y));
                    bombs.Add(bomb);
                    cells.Add(bomb);
                }
                else
                {
                    i--;
                }
            }


            foreach (var bomb in bombs)
            {
                List<Cell> envCells = new List<Cell>();


                envCells.Add(cells.Find(item => (item.Position.X == bomb.Position.X - 1)&&(item.Position.Y == bomb.Position.Y)));
                envCells.Add(cells.Find(item => (item.Position.X == bomb.Position.X + 1)&& (item.Position.Y == bomb.Position.Y)));
                envCells.Add(cells.Find(item => (item.Position.X == bomb.Position.X) && (item.Position.Y == bomb.Position.Y + 1)));
                envCells.Add(cells.Find(item => (item.Position.X == bomb.Position.X) && (item.Position.Y == bomb.Position.Y - 1)));
                envCells.Add(cells.Find(item => (item.Position.X == bomb.Position.X - 1) && (item.Position.Y == bomb.Position.Y - 1)));
                envCells.Add(cells.Find(item => (item.Position.X == bomb.Position.X - 1) && (item.Position.Y == bomb.Position.Y + 1)));
                envCells.Add(cells.Find(item => (item.Position.X == bomb.Position.X + 1) && (item.Position.Y == bomb.Position.Y - 1)));
                envCells.Add(cells.Find(item => (item.Position.X == bomb.Position.X + 1) && (item.Position.Y == bomb.Position.Y + 1)));

                foreach (var item in envCells)
                {
                    if (item != null && item.GetType() == typeof(NumCell))
                    {
                        ((NumCell)item).Num = ((NumCell)item).Num + 1;
                    }
                    else if (item != null && item.GetType() == typeof(EmptyCell))
                    {
                        var point = item.Position;
                        var r = cells.Remove(item);
                        cells.Add(new NumCell(ref BattleGrid, point, 1));
                    }
                }
            }

            cells.Sort((a, b)=>
            {
                if (a.Position.Y < b.Position.Y) return -1;
                else if (a.Position.Y == b.Position.Y && a.Position.X < b.Position.X) return -1;
                else if (a.Position.Y == b.Position.Y && a.Position.X == b.Position.X) return 0;
                else return 1;
            });

            foreach (var item in cells)
            {
                item.Draw();
            }
        }
    }
}
