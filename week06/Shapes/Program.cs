using System;
using System.Collections.Generic;

/// <summary>
/// Demonstrates polymorphism: a single List&lt;Shape&gt; holds Square,
/// Rectangle, and Circle instances. The same GetArea() call resolves
/// to a different implementation depending on the runtime type of
/// each object in the list.
/// </summary>
public class Program
{
    public static void Main(string[] args)
    {
        List<Shape> shapes = new List<Shape>();

        shapes.Add(new Square("Red", 5));
        shapes.Add(new Rectangle("Blue", 4, 6));
        shapes.Add(new Circle("Green", 3));

        foreach (Shape shape in shapes)
        {
            Console.WriteLine($"Color: {shape.GetColor()}, Area: {shape.GetArea():F2}");
        }
    }
}
