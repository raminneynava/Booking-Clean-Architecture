using Booking.Application.Abstractions.Messaging;


namespace Booking.Application.Bookings.CancelBooking;

public sealed record CancelBookingCommand(Guid BookingId) : ICommand;
