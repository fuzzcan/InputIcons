﻿using System.Drawing;
using InputIcons.Utilities;
using Microsoft.AspNetCore.Components;

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

    [Parameter] public Color Color { get; set; } = Color.Salmon;
    [CascadingParameter] public ColorScheme? CascadingColorScheme { get; set; }
    [Parameter] public ColorScheme? ColorScheme { get; set; }
    [Parameter] public float FontWidthEm { get; set; } = 0.55f;

    private RoundedTrapezoid Trapezoid => new(1f,
        1f, .3f, .2f);

    public string FaceWidth => $"width:{(Text.Length + 2) * FontWidthEm}em;";
    public string FaceHeight => $"height:{FontWidthEm * 3}em;";

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