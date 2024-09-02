public class HslaColor
{
    public HslaColor(float hue, float saturation, float lightness, float alpha)
    {
        Hue = Clamp(hue, 0, 360);
        Saturation = Clamp(saturation, 0, 100);
        Lightness = Clamp(lightness, 0, 100);
        Alpha = Clamp(alpha, 0, 1);
    }

    private float Hue { get; set; } // 0 to 360
    private float Saturation { get; set; } // 0 to 100
    private float Lightness { get; set; } // 0 to 100
    private float? Alpha { get; set; } // 0 to 1

    private static float Clamp(float value, float min, float max)
    {
        return Math.Max(min, Math.Min(max, value));
    }

    public HslaColor AdjustLightness(int lightness)
    {
        Lightness = Clamp(Lightness + lightness, 0, 100);
        return this;
    }

    public HslaColor Clone()
    {
        var alpha = Alpha ?? 1;
        return new HslaColor(Hue, Saturation, Lightness, alpha);
    }

    public string Css =>
        Alpha == null
            ? $"hsl({Hue}, {Saturation}%, {Lightness:F0}%)"
            : $"hsla({Hue}, {Saturation}%, {Lightness}%, {Alpha:F2})";
}