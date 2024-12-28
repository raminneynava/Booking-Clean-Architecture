using Booking.Domain.Abstractions;

namespace Booking.Domain.Bookings.Events;

public sealed record BookingConfirmedDomainEvent(Guid BookingId) : IDomainEvent;
