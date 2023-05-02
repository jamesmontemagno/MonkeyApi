namespace MonkeyApp1.Models;

public class Continent
{
    public int Id { get; set; }
    public string? Name { get; set; }

    public string? Description { get; set; }

    public List<Monkey> Monkeys { get; set; } = new List<Monkey>();
}
