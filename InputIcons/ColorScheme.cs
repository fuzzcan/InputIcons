using System.Drawing;

namespace InputIcons.Utilities;

public class ColorScheme
{
    public readonly int DarkerLightness = -25;
    public readonly int DarkLightness = -5;
    public readonly int LighterLightness = 15;
    public readonly int LightLightness = 10;
    public readonly int NeutralLightness = 0;


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

    public HslaColor Lighter { get; set; }
    public HslaColor Light { get; set; }
    public HslaColor Neutral { get; set; }
    public HslaColor Dark { get; set; }
    public HslaColor Darker { get; set; }


    public string BaseGradient =>
        $"background: linear-gradient(135deg, {Lighter}, {Darker});";

    public string BaseShadow =>
        $"box-shadow: inset -.2em -.2em .4em {Darker};";

    public string FaceGradient =>
        $"background: linear-gradient(135deg, {Dark}, {Light});";

    public string FaceShadow =>
        "box-shadow: 0 0 .3em rgba(255,255,255,.5), inset 0 0 .5em rgba(255,255,255,.5), inset .2em .2em .8em rgba(0,0,0,.5);";

    public string FaceRim
    {
        get
        {
            var inner = $"inset 0 0 .4em {Lighter}";
            var outer = $".0em .0em .1em {Lighter}";
            var bottomRight = $".1em .1em .3em {Neutral}";
            return $"box-shadow: {inner},{outer},{bottomRight};";
        }
    }
}