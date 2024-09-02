namespace InputIcons.Utilities;

public class RoundedTrapezoid
{
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

    public float TopWidth { get; set; } = .75f;

    /// <summary>
    ///     Radius of top corners as a percentage of trapezoid height
    /// </summary>
    public float TopCornerRadius { get; set; } = .05f;

    public float BottomWidth { get; set; } = 1f;

    /// <summary>
    ///     Radius of bottom corners as a percentage of trapezoid height
    /// </summary>
    public float BottomCornerRadius { get; set; } = .05f;

    public Point TopLeft { get; set; }
    public Point TopRight { get; set; }
    public Point BottomLeft { get; set; }
    public Point BottomRight { get; set; }

    public string SvgPath
    {
        get
        {
            var start = $"M {TopLeft.X + TopCornerRadius} {1 - TopLeft.Y}";
            var top = $"L {TopRight.X - TopCornerRadius} {1 - TopRight.Y}";
            var topRightCorner =
                $"Q {TopRight.SvgPoint} {Lerp(TopRight, BottomRight, TopCornerRadius).SvgPoint}";
            var right =
                $"L {Lerp(BottomRight, TopRight, BottomCornerRadius).SvgPoint}";
            var bottomRightCorner =
                $"Q {BottomRight.SvgPoint} {Lerp(BottomRight, BottomLeft, BottomCornerRadius).SvgPoint}";
            var bottom = $"L {BottomLeft.X} {1 - BottomLeft.Y}";
            var left = $"L {TopLeft.X} {1 - TopLeft.Y}";
            var trapezoid =
                $"{start}\n {top}\n {topRightCorner}\n {right}\n {bottomRightCorner}\n {bottom}\n {left}\n";
            return trapezoid;
        }
    }

    private Point Lerp(Point p1, Point p2, float t)
    {
        var x = p1.X + (p2.X - p1.X) * t;
        var y = p1.Y + (p2.Y - p1.Y) * t;
        return new Point(x, y);
    }

    public class Point
    {
        public Point(float x, float y)
        {
            X = x;
            Y = y;
        }

        public float X { get; set; }
        public float Y { get; set; }

        public string SvgPoint => $"{X} {1 - Y}";
    }
}