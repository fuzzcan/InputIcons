using System.Drawing;

namespace InputIcons;

public class ColorScheme
{
    public HslaColor Lighter { get; set; }
    public HslaColor Light { get; set; }
    public HslaColor Neutral { get; set; }
    public HslaColor Dark { get; set; }
    public HslaColor Darker { get; set; }

    public readonly int LighterLightness = 15;
    public readonly int LightLightness = 10;
    public readonly int NeutralLightness = 0;
    public readonly int DarkLightness = -5;
    public readonly int DarkerLightness = -15;

    public ColorScheme(Color color)
    {
        var c = color.ToHsla();
        Lighter = c.Clone().AdjustLightness(LighterLightness);
        Light = c.Clone().AdjustLightness(LightLightness);
        Neutral = c.Clone().AdjustLightness(NeutralLightness);
        Dark = c.Clone().AdjustLightness(DarkLightness);
        Darker = c.Clone().AdjustLightness(DarkerLightness);
    }

    public ColorScheme(string hexColor) : this(
        ColorExtensions.FromHex(hexColor))
    {
    }


    public string BaseGradientCss =>
        $"background: linear-gradient(135deg, {Lighter.Css}, {Darker.Css});";

    public string BaseShadowCss =>
        $"box-shadow: inset -.2em -.2em .4em {Darker.Css};";

    public string FaceGradientCss =>
        $"background: linear-gradient(135deg, {Dark.Css}, {Lighter.Css});";

    public string FaceShadowCss =>
        $"box-shadow: 0 0 .3em {Lighter.Css}";

    public string FaceRimCss
    {
        get
        {
            var inner = $"inset 0 0 .3em {Light.Css}";
            var outer = $".0em .0em .2em {Lighter.Css}";
            var bottomRight = $".1em .1em .3em {Light.Css}";
            return $"box-shadow: {inner}, {outer}, {bottomRight};";
        }
    }
}