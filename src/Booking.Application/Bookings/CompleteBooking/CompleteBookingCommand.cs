using Booking.Application.Abstractions.Messaging;

namespace Booking.Application.Bookings.CompleteBooking;

public sealed record CompleteBookingCommand(Guid BookingId) : ICommand;
