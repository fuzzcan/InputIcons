using System.Drawing;
using InputIcons.Utilities;

public static class ColorExtensions
{
    private const float Tolerance = 1e-5f; // Adjusted for float precision

    public static HslaColor ToHsla(this Color color)
    {
        var h = color.GetHue();
        var s = color.GetSaturation() * 100;
        var l = color.GetBrightness() * 100;
        var a = (float)color.A;
        return new HslaColor(h, s, l, a);
    }

    public static string ToCss(this Color color)
    {
        return $"rgba({color.R},{color.G},{color.B},{color.A}";
    }

    public static Color FromHex(string hex)
    {
        // Remove the # if present
        if (hex.StartsWith("#"))
        {
            hex = hex.Substring(1);
        }

        // Validate the hex string length
        if (hex.Length != 3 && hex.Length != 6 && hex.Length != 8)
        {
            throw new ArgumentException(
                "Invalid hex color format. Use #RRGGBB, #AARRGGBB, RRGGBB, or AARRGGBB.");
        }

        // Convert 3-digit hex to 6-digit hex
        if (hex.Length == 3)
        {
            hex = $"{hex[0]}{hex[0]}{hex[1]}{hex[1]}{hex[2]}{hex[2]}";
        }

        // Parse ARGB components
        byte a = 255; // Default alpha value
        byte r = 0;
        byte g = 0;
        byte b = 0;

        try
        {
            if (hex.Length == 8)
            {
                // ARGB format
                a = byte.Parse(hex.Substring(0, 2),
                    System.Globalization.NumberStyles.HexNumber);
                r = byte.Parse(hex.Substring(2, 2),
                    System.Globalization.NumberStyles.HexNumber);
                g = byte.Parse(hex.Substring(4, 2),
                    System.Globalization.NumberStyles.HexNumber);
                b = byte.Parse(hex.Substring(6, 2),
                    System.Globalization.NumberStyles.HexNumber);
            }
            else if (hex.Length == 6)
            {
                // RGB format
                r = byte.Parse(hex.Substring(0, 2),
                    System.Globalization.NumberStyles.HexNumber);
                g = byte.Parse(hex.Substring(2, 2),
                    System.Globalization.NumberStyles.HexNumber);
                b = byte.Parse(hex.Substring(4, 2),
                    System.Globalization.NumberStyles.HexNumber);
            }
        }
        catch (FormatException)
        {
            throw new ArgumentException(
                "Invalid hex color format. The hex string contains invalid characters.");
        }

        return Color.FromArgb(a, r, g, b);
    }
}