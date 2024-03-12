using System;

public class Fraction
{
    private int numerator;
    private int denominator;

    // Constructor that initializes the fraction to 1/1
    public Fraction()
    {
        numerator = 1;
        denominator = 1;
    }

    // Constructor that initializes the fraction with the given numerator
    public Fraction(int numerator)
    {
        this.numerator = numerator;
        denominator = 1;
    }

    // Constructor that initializes the fraction with the given numerator and denominator
    public Fraction(int numerator, int denominator)
    {
        this.numerator = numerator;
        this.denominator = denominator;
    }

    // Getter and setter for the numerator
    public int Numerator
    {
        get { return numerator; }
        set { numerator = value; }
    }

    // Getter and setter for the denominator
    public int Denominator
    {
        get { return denominator; }
        set { denominator = value; }
    }

    // Method to return the fraction representation
    public string GetFractionString()
    {
        return numerator + "/" + denominator;
    }

    // Method to return the decimal value of the fraction
    public double GetDecimalValue()
    {
        return (double)numerator / denominator;
    }
}