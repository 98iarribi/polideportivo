namespace Polideportivo.Domain.Entities;

using System;
using System.Collections.Generic;
using System.Linq;


public class PadelCourt
{
    public int CourtNumber { get; set; }
    public Dictionary<BookingTimeSlot, string?> TimeSlotIds { get; set; }
}

public class PadelCourtTable
{
    public List<PadelCourt> Courts { get; set; }

    public PadelCourtTable()
    {
        Courts = new List<PadelCourt>
        {
            new PadelCourt
            {
                CourtNumber = 1,
                TimeSlotIds = new Dictionary<BookingTimeSlot, string?>
                {
                    { BookingTimeSlot.T18_30, "0104090111" },
                    { BookingTimeSlot.T19_30, "0104090112" },
                    { BookingTimeSlot.T20_30, "0104090113" }
                }
            },
            new PadelCourt
            {
                CourtNumber = 2,
                TimeSlotIds = new Dictionary<BookingTimeSlot, string?>
                {
                    { BookingTimeSlot.T18_30, "0104090211" },
                    { BookingTimeSlot.T19_30, "0104090212" },
                    { BookingTimeSlot.T20_30, "0104090213" }
                }
            },
            new PadelCourt
            {
                CourtNumber = 3,
                TimeSlotIds = new Dictionary<BookingTimeSlot, string?>
                {
                    { BookingTimeSlot.T17_30, "010409067" },
                    { BookingTimeSlot.T19_00, "010409068" },
                    { BookingTimeSlot.T20_30, "010409069" }
                }
            },
            new PadelCourt
            {
                CourtNumber = 4,
                TimeSlotIds = new Dictionary<BookingTimeSlot, string?>
                {
                    { BookingTimeSlot.T17_30, "010409077" },
                    { BookingTimeSlot.T19_00, "010409078" },
                    { BookingTimeSlot.T20_30, "010409079" }
                }
            }
        };
    }
    public List<string> GetAllIds()
    {
        return Courts.SelectMany(c => c.TimeSlotIds.Values)
                     .Where(v => v is not null)
                     .Select(v => v!)
                     .ToList();
    }
}