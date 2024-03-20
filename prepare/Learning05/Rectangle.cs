using System;
using System.Collections.Generic;


// Derived Rectangle class
class Rectangle : Shape
{
    private double _length;
    private double _width;

    public Rectangle(string color, double length, double width) : base(color)
    {
        _length = length;
        _width = width;
    }

    // Override GetArea method for Rectangle
    public override double GetArea()
    {
        return _length * _width;
    }
}