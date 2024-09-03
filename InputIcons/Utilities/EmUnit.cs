namespace InputIcons.Utilities;

public struct EmUnit
{
    public float Value { get; set; }

    public EmUnit(float value)
    {
        Value = value;
    }

    public string Css => $"{Value}em";

    public static EmUnit operator +(EmUnit a, EmUnit b)
    {
        return new EmUnit(a.Value + b.Value);
    }

    public static implicit operator float(EmUnit emUnit)
    {
        return emUnit.Value;
    }
}