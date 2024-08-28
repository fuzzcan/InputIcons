using System.Drawing;

namespace InputIcons.Utilities;

public class ColorScheme
{
    public HslaColor Highlight { get; set; }
    public readonly int HighlightLightness = 30;
    public HslaColor Lighter { get; set; }
    public readonly int LighterLightness = 20;
    public HslaColor Light { get; set; }
    public readonly int LightLightness = 10;
    public HslaColor Neutral { get; set; }
    public readonly int NeutralLightness = 0;
    public HslaColor Dark { get; set; }
    public readonly int DarkLightness = -10;
    public HslaColor Darker { get; set; }
    public readonly int DarkerLightness = -20;


    public ColorScheme(Color color)
    {
        var c = color.ToHsla();
        c.Lightness = 50;
        Highlight = c.Clone().AdjustLightness(HighlightLightness);
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


    public string BaseGradient =>
        $"background: linear-gradient(135deg, {Light}, {Darker});";

    public string BaseShadow =>
        $"box-shadow: inset -.2em -.2em .4em rgba(0,0,0,0.2);";

    public string FaceGradient =>
        $"background: linear-gradient(315deg, {Highlight}, {Light});";

    public string FaceShadow =>
        $"box-shadow: 0 0 .3em rgba(255,255,255,.5), inset 0 0 .5em rgba(255,255,255,.5), inset .2em .2em .8em rgba(0,0,0,.5);";
}