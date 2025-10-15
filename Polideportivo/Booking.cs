namespace Polideportivo;

public class Booking
{
    public Guid BookingId { get; set; }
    public Guid UserId { get; set; }
    public DateTime BookingDate { get; set; }
    public int CourtNumber { get; set; }
    public DateTime SlotTime { get; set; }
    public BookingStatus Status { get; set; }
}

public enum BookingStatus
{
    Pending,
    Confirmed,
    Cancelled,
    Failed
}