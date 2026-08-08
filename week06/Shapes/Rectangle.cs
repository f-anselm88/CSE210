/// <summary>
/// Represents a rectangle, defined by two side lengths.
/// </summary>
public class Rectangle : Shape
{
    private double _sideA;
    private double _sideB;

    public Rectangle(string color, double sideA, double sideB) : base(color)
    {
        _sideA = sideA;
        _sideB = sideB;
    }

    public override double GetArea()
    {
        return _sideA * _sideB;
    }
}
