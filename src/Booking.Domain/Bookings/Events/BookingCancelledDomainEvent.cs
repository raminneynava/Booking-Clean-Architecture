using Booking.Domain.Abstractions;

namespace Booking.Domain.Bookings.Events;

public sealed record BookingCancelledDomainEvent(Guid BookingId) : IDomainEvent;
