using System;
using System.Collections.Generic;


// Derived Circle class
class Circle : Shape
{
    private double _radius;

    public Circle(string color, double radius) : base(color)
    {
        _radius = radius;
    }

    // Override GetArea method for Circle
    public override double GetArea()
    {
        return Math.PI * _radius * _radius;
    }
}