# Hotel Booking — Low Level Design

## Problem Statement

Implement a booking manager against a fixed interface:
1. `IsRoomAvailable(room, date)` — true if the room is free on that date
2. `AddBooking(guest, room, date)` — books the room, throws if it's already taken or the room id is invalid
3. `GetAvailableRooms(date)` — lists every free room for a given date

## Design

- **`IBookingManager`** — the contract above; kept separate from the implementation so the manager can be swapped or mocked.
- **`BookingManager`** — backs bookings with `Dictionary<DateTime, HashSet<int>>` (date → booked room ids) against a fixed set of valid room ids (`101, 102, 201, 203`). Writes are wrapped in a `lock` so concurrent booking attempts for the same date don't race.
- Availability and validity checks are O(1) set lookups; `GetAvailableRooms` is a set difference against the booked rooms for that date.

## Tech

C# / .NET

## How to Run

`Program.cs` runs a scripted demo: checks room 101's availability, books it, confirms it's no longer available, then lists remaining available rooms for the same date.
