namespace Frank.EnterpriseFizzBuzz.Primitives;

public class Output(string value)
{
    public string Value { get; set; } = value;

    public Color Color { get; set; } = Color.White;
}