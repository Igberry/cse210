using System;

class Address
{
    public string Street { get; }
    public string City { get; }
    public string State { get; }
    public string Country { get; }

    public Address(string street, string city, string state, string country)
    {
        Street = street;
        City = city;
        State = state;
        Country = country;
    }

    public override string ToString()
    {
        return $"{Street}, {City}, {State}, {Country}";
    }
}

class Event
{
    private string title;
    private string description;
    private DateTime date;
    private TimeSpan time;
    private Address address;

    public Event(string title, string description, DateTime date, TimeSpan time, Address address)
    {
        this.title = title;
        this.description = description;
        this.date = date;
        this.time = time;
        this.address = address;
    }

    public virtual string GenerateStandardMessage()
    {
        return $"Title: {title}\nDescription: {description}\nDate: {date.ToShortDateString()}\nTime: {time}\nAddress: {address}";
    }

    public virtual string GenerateFullMessage()
    {
        return GenerateStandardMessage();
    }

    public virtual string GenerateShortDescription()
    {
        return $"Type: Event\nTitle: {title}\nDate: {date.ToShortDateString()}";
    }
}

class Lecture : Event
{
    private string speaker;
    private int capacity;

    public Lecture(string title, string description, DateTime date, TimeSpan time, Address address, string speaker, int capacity)
        : base(title, description, date, time, address)
    {
        this.speaker = speaker;
        this.capacity = capacity;
    }

    public override string GenerateFullMessage()
    {
        return $"{base.GenerateFullMessage()}\nType: Lecture\nSpeaker: {speaker}\nCapacity: {capacity}";
    }
}

class Reception : Event
{
    private string rsvpEmail;

    public Reception(string title, string description, DateTime date, TimeSpan time, Address address, string rsvpEmail)
        : base(title, description, date, time, address)
    {
        this.rsvpEmail = rsvpEmail;
    }

    public override string GenerateFullMessage()
    {
        return $"{base.GenerateFullMessage()}\nType: Reception\nRSVP Email: {rsvpEmail}";
    }
}

class OutdoorGathering : Event
{
    private string weatherForecast;

    public OutdoorGathering(string title, string description, DateTime date, TimeSpan time, Address address, string weatherForecast)
        : base(title, description, date, time, address)
    {
        this.weatherForecast = weatherForecast;
    }

    public override string GenerateFullMessage()
    {
        return $"{base.GenerateFullMessage()}\nType: Outdoor Gathering\nWeather Forecast: {weatherForecast}";
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Create addresses
        Address lectureAddress = new Address("123 Oke Ola St", "Osogbo", "Osun State", "Nigeria");
        Address receptionAddress = new Address("456 Azikoro Town", "Yenagoa", "Bayelsa State", "Nigeria");
        Address outdoorGatheringAddress = new Address("789 Asubiaro", "Osogbo", "Osun State", "Nigeria");

        // Create events
        Lecture lecture = new Lecture("Science Talk", "Exciting lecture on scientific discoveries", DateTime.Now.Date, new TimeSpan(10, 0, 0), lectureAddress, "Dr. David C. Igberi", 50);
        Reception reception = new Reception("Networking Event", "Come meet and greet with industry professionals", DateTime.Now.Date.AddDays(7), new TimeSpan(18, 30, 0), receptionAddress, "rsvp@igberry.com");
        OutdoorGathering gathering = new OutdoorGathering("Picnic in the Park", "Enjoy outdoor games and food with friends", DateTime.Now.Date.AddDays(14), new TimeSpan(12, 0, 0), outdoorGatheringAddress, "Sunny skies");

        // Generate and display messages
        Console.WriteLine("Lecture:");
        Console.WriteLine(lecture.GenerateStandardMessage());
        Console.WriteLine(lecture.GenerateFullMessage());
        Console.WriteLine(lecture.GenerateShortDescription());
        Console.WriteLine();

        Console.WriteLine("Reception:");
        Console.WriteLine(reception.GenerateStandardMessage());
        Console.WriteLine(reception.GenerateFullMessage());
        Console.WriteLine(reception.GenerateShortDescription());
        Console.WriteLine();

        Console.WriteLine("Outdoor Gathering:");
        Console.WriteLine(gathering.GenerateStandardMessage());
        Console.WriteLine(gathering.GenerateFullMessage());
        Console.WriteLine(gathering.GenerateShortDescription());
    }
}
