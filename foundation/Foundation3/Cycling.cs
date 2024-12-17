using System;

public class CyclingActivity : Activity
{
    
    private double _speedInMph;

        
    public CyclingActivity(DateTime date, double durationInMinutes, double speedInMph) 
        : base(date, durationInMinutes)
    {
        _speedInMph = speedInMph;
    }

    
    public override double GetDistance() => _speedInMph * (DurationInMinutes / 60);

    public override double GetSpeed() => _speedInMph; 

    public override double GetPace() => 60 / _speedInMph; 
}
