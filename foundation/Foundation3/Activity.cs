using System;

public abstract class Activity
{
    
    private DateTime _date;
    private double _durationInMinutes;

    

    public double DurationInMinutes
    {
        get { return _durationInMinutes; }
        set { _durationInMinutes = value; }
    }

    
    protected Activity(DateTime date, double durationInMinutes)
    {
        _date = date;
        _durationInMinutes = durationInMinutes;
    }

    
    public abstract double GetDistance();
    public abstract double GetSpeed();
    public abstract double GetPace();

    
    public virtual string GetSummary()
    {
        return $"{_date:dd MMM yyyy} {GetType().Name} ({_durationInMinutes} min) - Distance {GetDistance():F2} miles, Speed {GetSpeed():F2} mph, Pace: {GetPace():F2} min per mile";
    }
}
