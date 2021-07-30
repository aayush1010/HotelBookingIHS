using System;

namespace HotelBookingIHS
{
    class Program
    {
        static void Main(string[] args)
        {
            IBookingManager bm = new BookingManager();// create your manager here; 
            var today = new DateTime(2012, 3, 28);
            Console.WriteLine(bm.IsRoomAvailable(101, today)); // outputs true 
            bm.AddBooking("Patel", 101, today);
            Console.WriteLine(bm.IsRoomAvailable(101, today)); // outputs false 
            bm.AddBooking("Li", 101, today); // 
            var availableRooms = bm.GetAvailableRooms(today);
            foreach (var room in availableRooms)
            {
                Console.WriteLine(room);

            }
        }
    }
}
