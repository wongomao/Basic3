namespace ReflectIt;
public class Payer
{
    public int PayerId { get; set; }
    public string? Name { get; set; }
    public Account? Account { get; set; }

    public Payer(int id, string name)
    {
        PayerId = id;
        Name = name;
    }
}
