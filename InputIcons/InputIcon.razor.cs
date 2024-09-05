using System.Drawing;
using InputIcons.Utilities;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Logging;

namespace InputIcons;

public partial class InputIcon
{
    /// <summary>
    /// <c>Text</c> sets the text displayed on the key face
    /// </summary>
    [Parameter]
    public string Text { get; set; } = "";

    /// <summary>
    /// Whether the key should be wrapped in a &lt;kbd&gt; tag
    /// <remarks><see langword="true"/> by default</remarks>
    /// </summary>
    [Parameter]
    public bool WrapWithKbdTag { get; set; } = true;

    /// <summary>
    /// <see cref="InputIcons.IconSize"/>
    /// </summary>
    [Parameter]
    public IconSize? Size { get; set; }

    /// <summary>
    /// Optional parameter for inheriting <see cref="IconSize"/> 
    /// </summary>
    [CascadingParameter]
    public IconSize? CascadingSize { get; set; }

    /// <summary>
    /// Sets the <see cref="System.Drawing.Color"/> of the key
    /// </summary>
    [Parameter]
    public Color Color { get; set; } = Color.Salmon;

    /// <summary>
    /// Optional parameter for inheriting parent's <see cref="ColorScheme"/>
    /// </summary>
    [CascadingParameter]
    public ColorScheme? CascadingColorScheme { get; set; }

    [Parameter] public ColorScheme? ColorScheme { get; set; }
    [Parameter] public float FontWidthEm { get; set; } = 0.55f;


    private Guid _trapezoidGuid = Guid.NewGuid();
    private EmUnit FaceWidth => new((Text.Length + 2) * FontWidthEm);
    private string FaceWidthCss => $"width:{FaceWidth.Css};";
    private EmUnit FaceHeight => new(FontWidthEm * 3);
    private string FaceHeightCss => $"height:{FaceHeight.Css}";

    private EmUnit SidePadding = new(.4f);
    private EmUnit TopPadding = new(.2f);
    private EmUnit BottomPadding = new(.9f);

    private RoundedTrapezoid Trapezoid => new(.0f,
        1f, .4f, .15f,
        (float)HeightToWidthRatio);

    private string BasePadding =>
        $"padding: {TopPadding.Css} {SidePadding.Css} {BottomPadding.Css} {SidePadding.Css};";

    public float TotalWidth => FaceWidth + (SidePadding * 2);
    public float TotalHeight => FaceHeight + TopPadding + BottomPadding;
    public double HeightToWidthRatio => TotalHeight / TotalWidth;

    protected override void OnInitialized()
    {
        ColorScheme ??= CascadingColorScheme ?? new ColorScheme(Color);
    }

    private void InitializeColorScheme()
    {
        if (CascadingColorScheme != null)
        {
        }
    }

    private string BaseCss
    {
        get
        {
            var size = Size ?? CascadingSize ?? IconSize.Medium;
            var sizeCss = $"input-icons__key{SizeToClassModifier(size)}";
            return $"{KeyCss} {sizeCss}";
        }
    }

    private string KeyCss => "input-icons__key";
    private string KeyLayer => "input-icons__key-layer";
    private string BaseRoundness => "input-icons__key-roundness";
    private string FaceCss => "input-icons__key-face";
    private string FaceRoundness => "input-icons__key-face-roundness";

    private string SizeToClassModifier(IconSize size)
    {
        return size switch
        {
            IconSize.Small => "--sm",
            IconSize.Medium => "--md",
            IconSize.Large => "--lg",
            _ => ""
        };
    }
}