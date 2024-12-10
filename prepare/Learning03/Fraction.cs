using System;

public class Fraction
{
    private int _top;
    private int _bottom;

    public Fraction()
    {
        // Default to 1/1
        _top = 1;
        _bottom = 1;
    }

    public Fraction(int wholeNumber)
    {
        _top = wholeNumber;
        _bottom = 1;
    }

    public Fraction(int top, int bottom)
    {
        _top = top;
        _bottom = bottom;
    }

    public string GetFractionString()
    {
        // Observe that this is not retained as a member variable.
        // It is merely a temporary, local variable that will be recalculated every time this is invoked.
        string text = $"{_top}/{_bottom}";
        return text;
    }

    public double GetDecimalValue()
    {
        // Note that this is not kept as a member variable.
        // It will be recalculated each time this is invoked.
        return (double)_top / (double)_bottom;
    }
}