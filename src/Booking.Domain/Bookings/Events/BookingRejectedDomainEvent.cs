using Booking.Domain.Abstractions;

namespace Booking.Domain.Bookings.Events;

public sealed record BookingRejectedDomainEvent(Guid BookingId) : IDomainEvent;
