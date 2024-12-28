using Booking.Domain.Abstractions;

namespace Booking.Domain.Bookings.Events;

public sealed record BookingCompletedDomainEvent(Guid BookingId) : IDomainEvent;
