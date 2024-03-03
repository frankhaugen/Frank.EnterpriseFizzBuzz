namespace Frank.EnterpriseFizzBuzz;

public static class ConsoleColorExtensions
{
    public static Color Average(this IEnumerable<Color> colors)
    {
        var SystemColor = System.Drawing.Color.FromArgb(
            (int)colors.Average(color => color.R),
            (int)colors.Average(color => color.G),
            (int)colors.Average(color => color.B)
        );
        
        return new Color(SystemColor.R, SystemColor.G, SystemColor.B);
    }
}