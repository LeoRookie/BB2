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

namespace BouncyBall
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        System.Windows.Threading.DispatcherTimer timer = new System.Windows.Threading.DispatcherTimer();
        double vx = 120;
        double vy = 90;

        public MainWindow()
        {
            InitializeComponent();

            timer.Interval = TimeSpan.FromSeconds(0.05);
            timer.IsEnabled = true;
            timer.Tick += animate;

        }

        void animate(object sender, EventArgs e)
        {

            double x = Canvas.GetLeft(Ball);
            double y = Canvas.GetTop(Ball);

            // X Achse


            x += vx * timer.Interval.TotalSeconds;
            Canvas.SetLeft(Ball, x);
                
            if ( (x <= LeftPaddle.ActualWidth || x + Ball.Width >= myCanvas.ActualWidth - RightPaddle.Width) && y >= Canvas.GetTop(LeftPaddle) && y + Ball.ActualHeight  <= Canvas.GetTop(LeftPaddle) + LeftPaddle.ActualHeight )
            {
                vx = vx * -1;
            }


            if (x <= 0 || x >= myCanvas.ActualWidth - Ball.ActualWidth)
            {
                timer.IsEnabled = false;


                GameOver.Visibility = Visibility.Visible;
                Image1_png.Visibility = Visibility.Visible;
                myCanvas.Background = Brushes.Red;
            }

            // Y Achse

            y += vy * timer.Interval.TotalSeconds;
            Canvas.SetTop(Ball, y);

            if (y <= 0 || y >= myCanvas.ActualHeight - Ball.ActualHeight)
            {
                vy = vy * -1;
            }


        }

        private void Window_MouseMove(object sender, MouseEventArgs e)
        {
            Point p = e.GetPosition(this);
            //Title = p.X.ToString();
            Canvas.SetTop(LeftPaddle, p.Y);
            Canvas.SetTop(RightPaddle, p.Y);

        }
    }
}
