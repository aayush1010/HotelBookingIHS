using System;
using System.Collections.Generic;
using System.Linq;

namespace HotelBookingIHS
{
    public class BookingManager : IBookingManager
    {
        Dictionary<DateTime, HashSet<int>> BookedRoomNumbers;
        HashSet<int> ValidRoomIds;
        private object obj = new object();

        public BookingManager()
        {
            ValidRoomIds = new HashSet<int> { 101, 102, 201, 203 };
            BookedRoomNumbers = new Dictionary<DateTime, HashSet<int>>();

        }

        public void AddBooking(string guest, int room, DateTime date)
        {

            if (ValidRoomIds.Contains(room))
            {
                lock (obj)
                {
                    if (!BookedRoomNumbers.ContainsKey(date.Date))
                    {
                        BookedRoomNumbers.Add(date.Date, new HashSet<int> { room });
                    }
                    else if (BookedRoomNumbers[date.Date].Contains(room))
                    {
                        throw new Exception("Room already booked");
                    }
                    else
                    {
                        BookedRoomNumbers[date.Date].Add(room);
                    }
                }
            }
            else
            {
                throw new Exception("Invalid Room Number");
            }

        }

        public IEnumerable<int> GetAvailableRooms(DateTime date)
        {
            var bookedRooms = BookedRoomNumbers.ContainsKey(date.Date) ? BookedRoomNumbers[date.Date] : new HashSet<int>();
            return ValidRoomIds.Where(x => !bookedRooms.Contains(x));
        }

        public bool IsRoomAvailable(int room, DateTime date)
        {
            return !BookedRoomNumbers.ContainsKey(date.Date) || !BookedRoomNumbers[date.Date].Contains(room);
        }
    }
}
