﻿public class HslaColor
{
    public float Hue { get; set; } // 0 to 360
    public float Saturation { get; set; } // 0 to 100
    public float Lightness { get; set; } // 0 to 100
    public float Alpha { get; set; } // 0 to 1

    public HslaColor(float hue, float saturation, float lightness, float alpha)
    {
        Hue = Clamp(hue, 0, 360);
        Saturation = Clamp(saturation, 0, 100);
        Lightness = Clamp(lightness, 0, 100);
        Alpha = Clamp(alpha, 0, 1);
    }

    private float Clamp(float value, float min, float max)
    {
        return Math.Max(min, Math.Min(max, value));
    }

    public HslaColor AdjustLightness(int lightness)
    {
        Lightness = Clamp(Lightness + lightness, 0, 100);
        return this; // Enable method chaining
    }

    public HslaColor Clone()
    {
        return new HslaColor(Hue, Saturation, Lightness, Alpha);
    }

    public override string ToString()
    {
        return Alpha == 1
            ? $"hsl({Hue}, {Saturation}%, {Lightness:F0}%)"
            : $"hsla({Hue}, {Saturation}%, {Lightness}%, {Alpha:F2})";
    }
}
