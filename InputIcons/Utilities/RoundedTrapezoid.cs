namespace InputIcons.Utilities;

public class RoundedTrapezoid
{
    public RoundedTrapezoid(float topIndentWidth, float bottomWidth,
        float topCornerRadius, float bottomCornerRadius,
        float heightToWidthRatio)
    {
        HeightToWidthRatio = heightToWidthRatio;
        OldTopWidth = 1 - topIndentWidth * 2;
        TopWidth = 1 - topIndentWidth * 2 * heightToWidthRatio;
        BottomWidth = bottomWidth;
        TopCornerRadius = topCornerRadius;
        BottomCornerRadius = bottomCornerRadius;
        InitializePoints();
    }

    public float OldTopWidth { get; set; }
    public float TopWidth { get; set; }
    private float BottomWidth { get; set; }
    private float TopCornerRadius { get; set; }
    private float BottomCornerRadius { get; set; }
    private float HeightToWidthRatio { get; set; }

    public Point TopLeft { get; set; }
    private Point TopRight { get; set; }
    private Point BottomLeft { get; set; }
    private Point BottomRight { get; set; }

    /// <summary>
    /// Initializes the corner points of the trapezoid.
    /// </summary>
    private void InitializePoints()
    {
        TopLeft = new Point((1 - TopWidth) / 2, 1);
        TopRight = new Point(1 - (1 - TopWidth) / 2, 1);
        BottomLeft = new Point((1 - BottomWidth) / 2, 0);
        BottomRight = new Point(1 - (1 - BottomWidth) / 2, 0);
    }

    /// <summary>
    /// Adjusts corner radius according to the width-to-height ratio.
    /// </summary>
    public float AdjustedCornerRadius(float cornerRadius) =>
        cornerRadius * HeightToWidthRatio;

    /// <summary>
    /// Generates the full SVG path for the rounded trapezoid.
    /// </summary>
    public string SvgPath =>
        $"{TopPath}\n{TopRightCornerPath}\n{RightPath}\n" +
        $"{BottomRightCornerPath}\n{BottomCornerPath}\n" +
        $"{BottomLeftCornerPath}\n{LeftPath}\n{TopLeftCornerPath}";

    private string TopPath =>
        $"M {TopLeft.X + AdjustedCornerRadius(TopCornerRadius)} 0 L {TopRight.X -
            AdjustedCornerRadius(TopCornerRadius)} {1 - TopRight.Y}";

    private string TopRightCornerPath =>
        $"Q {TopRight.SvgPoint} {Lerp(TopRight, BottomRight,
            TopCornerRadius).SvgPoint}";

    private string RightPath =>
        $"L {Lerp(BottomRight, TopRight, BottomCornerRadius).SvgPoint}";

    private string BottomRightCornerPath =>
        $"Q {BottomRight.SvgPoint} {Lerp(BottomRight, BottomLeft,
            AdjustedCornerRadius(BottomCornerRadius)).SvgPoint}";

    private string BottomCornerPath =>
        $"L {BottomLeft.X + AdjustedCornerRadius(BottomCornerRadius)} {1 -
            BottomLeft.Y}";

    private string BottomLeftCornerPath =>
        $"Q {BottomLeft.SvgPoint} {Lerp(BottomLeft, TopLeft,
            BottomCornerRadius).SvgPoint}";

    private string LeftPath =>
        $"L {Lerp(TopLeft, BottomLeft, TopCornerRadius).SvgPoint}";

    private string TopLeftCornerPath =>
        $"Q {TopLeft.SvgPoint} {Lerp(TopLeft, TopRight,
            AdjustedCornerRadius(TopCornerRadius)).SvgPoint}";

    /// <summary>
    /// Linearly interpolates between two points.
    /// </summary>
    private static Point Lerp(Point p1, Point p2, float t)
    {
        var x = p1.X + (p2.X - p1.X) * t;
        var y = p1.Y + (p2.Y - p1.Y) * t;
        return new Point(x, y);
    }

    public class Point(float x, float y)
    {
        public float X { get; set; } = x;
        public float Y { get; set; } = y;

        /// <summary>
        /// Returns a formatted string for the SVG coordinate.
        /// </summary>
        public string SvgPoint => $"{X} {1 - Y}";
    }
}