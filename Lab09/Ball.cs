using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Lab09;

public class Ball
{
    public double X { get; set; }
    public double Y { get; set; }
    public double Radius { get; private set; }
    public Rectangle Ref { get; private set; }
    public int bounceCounter { get; set; }

    public static Ball CreateBall(double x, double y, double radius)
    {
        var bref = new Rectangle()
        {
            Width = 2 * radius,
            Height = 2 * radius,
            RadiusX = radius,
            RadiusY = radius,
            Fill = Brushes.Crimson
        };
        return new Ball()
        {
            X = x,
            Y = y,
            Ref = bref,
            Radius = radius
        };
    }

    public void MoveBall(double dx, double dy)
    {
        X = X + dx;
        Y = Y + dy;
        Canvas.SetLeft(Ref, X);
        Canvas.SetTop(Ref, Y);
        
    }
}