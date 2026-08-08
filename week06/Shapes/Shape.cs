using System;

/// <summary>
/// Represents the base type for all two-dimensional shapes.
/// Encapsulates the shape's color and defines a contract (GetArea)
/// that every derived shape must fulfill via method overriding.
/// </summary>
public class Shape
{
    private string _color;

    public Shape(string color)
    {
        _color = color;
    }

    public string GetColor()
    {
        return _color;
    }

    public void SetColor(string color)
    {
        _color = color;
    }

    /// <summary>
    /// Calculates the area of the shape. The base implementation
    /// returns 0 since a generic shape has no defined geometry.
    /// Derived classes override this to provide their own formula.
    /// </summary>
    public virtual double GetArea()
    {
        return 0;
    }
}
