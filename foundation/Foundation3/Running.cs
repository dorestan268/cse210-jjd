using System;

public class RunningActivity : Activity
{
    
    private double _distanceInMiles;


    
    public RunningActivity(DateTime date, double durationInMinutes, double distanceInMiles) 
        : base(date, durationInMinutes)
    {
        _distanceInMiles = distanceInMiles;
    }

    
    public override double GetDistance() => _distanceInMiles;

    public override double GetSpeed() => _distanceInMiles / DurationInMinutes * 60; 

    public override double GetPace() => DurationInMinutes / _distanceInMiles; 
}
