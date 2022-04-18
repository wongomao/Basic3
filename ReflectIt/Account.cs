namespace ReflectIt;

public class Account
{
    public string? Owner { get; set; } = null;
    public string? Number { get; set; } = null;
    public string? Purpose { get; set; } = null;

    public override string ToString()
    {
        return $"Owner:{Owner} Number:{Number}";
    }
}
