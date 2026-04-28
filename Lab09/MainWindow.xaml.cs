using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Lab09;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    private bool isPaused = false;
    double dx = 3;
    double dy = 2;
    private Thread anim;
    public MainWindow()
    {
        InitializeComponent();
        var ball = Ball.CreateBall(100, 100, 30);
        var maxX = Canva.Width - ball.Radius * 2;
        var maxY = Canva.Height - ball.Radius * 2;
        Canva.Children.Add(ball.Ref);
        ball.MoveBall(0,0);
        // dodaj licznik odbić w klasie Ball, zwiększaj przy zmianie kierunku
        // dodaj wątek animujący drugą kulkę
        // oblicz sumę odbić obu kulek
        anim = new Thread(() =>
        {
            while (true)
            {
                Thread.Sleep(25);
                if (isPaused)
                {
                    continue;
                }

                if (ball.X + dx > maxX - 15 || ball.X + dx < 0)
                {
                    dx = -dx;
                    ball.bounceCounter++;
                }

                if (ball.Y + dy > maxY || ball.Y + dy < 0)
                {
                    dy = -dy;
                    ball.bounceCounter++;
                }
                Application.Current.Dispatcher.Invoke(() => { ball.MoveBall(dx, dy); });
            }
        });
        anim.Start();
    }

    private void PauseBtn_OnClick(object sender, RoutedEventArgs e)
    {
        if (isPaused)
        {
            PauseBtn.Content = "Pause";
            isPaused = false;
        }
        else
        {
            PauseBtn.Content = "Resume";
            isPaused = true;
        }
    }

    private void StopBtn_OnClickBtn_OnClick(object sender, RoutedEventArgs e)
    {
        if (anim.IsAlive)
        {
            anim.Interrupt();
        }
    }
}