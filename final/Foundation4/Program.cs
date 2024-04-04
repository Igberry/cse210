using System;
using System.Collections.Generic;

class Activity
{
    private DateTime date;
    protected int duration; // in minutes

    public Activity(DateTime date, int duration)
    {
        this.date = date;
        this.duration = duration;
    }

    public virtual double GetDistance()
    {
        return 0;
    }

    public virtual double GetSpeed()
    {
        return 0;
    }

    public virtual double GetPace()
    {
        return 0;
    }

    public virtual string GetSummary()
    {
        return $"{date.ToShortDateString()} {GetType().Name} ({duration} min):";
    }
}

class Running : Activity
{
    private double distance; // in miles

    public Running(DateTime date, int duration, double distance)
        : base(date, duration)
    {
        this.distance = distance;
    }

    public override double GetDistance()
    {
        return distance;
    }

    public override double GetSpeed()
    {
        return distance / (duration / 60.0);
    }

    public override double GetPace()
    {
        return duration / distance;
    }

    public override string GetSummary()
    {
        return $"{base.GetSummary()} Distance: {distance} miles, Speed: {GetSpeed()} mph, Pace: {GetPace()} min per mile";
    }
}

class StationaryBicycle : Activity
{
    private double speed; // in kph

    public StationaryBicycle(DateTime date, int duration, double speed)
        : base(date, duration)
    {
        this.speed = speed;
    }

    public override double GetSpeed()
    {
        return speed;
    }

    public override double GetPace()
    {
        return 60 / speed;
    }

    public override string GetSummary()
    {
        return $"{base.GetSummary()} Speed: {speed} kph, Pace: {GetPace()} min per km";
    }
}

class Swimming : Activity
{
    private int laps;

    public Swimming(DateTime date, int duration, int laps)
        : base(date, duration)
    {
        this.laps = laps;
    }

    public override double GetDistance()
    {
        return laps * 50 / 1000.0;
    }

    public override double GetSpeed()
    {
        return GetDistance() / (duration / 60.0);
    }

    public override double GetPace()
    {
        return duration / GetDistance();
    }

    public override string GetSummary()
    {
        return $"{base.GetSummary()} Distance: {GetDistance()} km, Speed: {GetSpeed()} kph, Pace: {GetPace()} min per km";
    }
}

class Program
{
    static void Main(string[] args)
    {
        List<Activity> activities = new List<Activity>
        {
            new Running(DateTime.Now, 30, 3.0),
            new StationaryBicycle(DateTime.Now, 40, 25),
            new Swimming(DateTime.Now, 45, 20)
        };

        foreach (var activity in activities)
        {
            Console.WriteLine(activity.GetSummary());
        }
    }
}
