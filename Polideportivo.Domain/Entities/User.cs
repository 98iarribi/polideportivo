namespace Polideportivo.Domain;

public class User
{
    public Guid UserId { get; set; }
    public string Username { get; set; }
    public string PasswordHash { get; set; }
    //public BookingHistory BookingHistory { get; set; }
}
