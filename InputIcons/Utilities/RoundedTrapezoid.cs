namespace InputIcons.Utilities;

public class RoundedTrapezoid
{
    public float TopWidth { get; set; } = .75f;
    public float TopCornerRadius { get; set; } = .05f;
    public float BottomWidth { get; set; } = 1f;
    public float BottomCornerRadius { get; set; } = .05f;
    public Point TopLeft { get; set; }
    public Point TopRight { get; set; }
    public Point BottomLeft { get; set; }
    public Point BottomRight { get; set; }

    public RoundedTrapezoid(float topWidth, float bottomWidth,
        float topCornerRadius, float bottomCornerRadius)
    {
        TopWidth = topWidth;
        BottomWidth = bottomWidth;
        TopCornerRadius = topCornerRadius;
        BottomCornerRadius = bottomCornerRadius;
        TopLeft = new Point((1 - TopWidth) / 2, 1);
        TopRight = new Point(1 - (1 - TopWidth) / 2, 1);
        BottomLeft = new Point(0, 0);
        BottomRight = new Point(1, 0);
    }

    public string SvgPath
    {
        get
        {
            var start = $"M {TopLeft.X + TopCornerRadius} {1 - TopLeft.Y}";
            var top = $"L {TopRight.X - TopCornerRadius} {1 - TopRight.Y}";
            var right = $"L {BottomRight.X} {1 - BottomRight.Y}";
            var bottom = $"L {BottomLeft.X} {1 - BottomLeft.Y}";
            var left = $"L {TopLeft.X} {1 - TopLeft.Y}";
            var trapezoid = $"{start}\n {top}\n {right}\n {bottom}\n {left}\n";
            return trapezoid;
        }
    }

    public class Point
    {
        public float X { get; set; } = 0;
        public float Y { get; set; } = 0;

        public Point(float x, float y)
        {
            X = x;
            Y = y;
        }
    }

    private Point Lerp(Point p1, Point p2, float t)
    {
        var x = p1.X + (p2.X - p1.X) * t;
        var y = p1.Y + (p2.Y - p1.Y) * t;
        return new Point(x, y);
    }
}