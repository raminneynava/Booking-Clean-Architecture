using Booking.Domain.Abstractions;

namespace Booking.Domain.Bookings.Events;

public sealed record BookingReservedDomainEvent(Guid BookingId) : IDomainEvent;
