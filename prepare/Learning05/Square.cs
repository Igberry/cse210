using System;
using System.Collections.Generic;

// Derived Square class
class Square : Shape
{
    private double _side;

    public Square(string color, double side) : base(color)
    {
        _side = side;
    }

    // Override GetArea method for Square
    public override double GetArea()
    {
        return _side * _side;
    }
}