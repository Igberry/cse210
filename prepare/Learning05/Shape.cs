using System;
using System.Collections.Generic;

// Base Shape class
class Shape
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

    // Virtual method for GetArea
    public virtual double GetArea()
    {
        return 0;
    }
}