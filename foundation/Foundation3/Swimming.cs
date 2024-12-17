using System;

public class SwimmingActivity : Activity
{
    
    private int _numberOfLaps;

        
    public SwimmingActivity(DateTime date, double durationInMinutes, int numberOfLaps) 
        : base(date, durationInMinutes)
    {
        _numberOfLaps = numberOfLaps;
    }

    
    public override double GetDistance() => _numberOfLaps * 50 / 1000.0 * 0.62; 

    public override double GetSpeed() => GetDistance() / DurationInMinutes * 60; 

    public override double GetPace() => DurationInMinutes / GetDistance(); 
}
