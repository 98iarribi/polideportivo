class BookingDate
{
    public DateTime Date { get; set; }
    public BookingTimeSlot TimeSlot { get; set; }
}

public enum BookingTimeSlot
{
    T17_30,
    T18_30,
    T19_00,
    T19_30,
    T20_30
}