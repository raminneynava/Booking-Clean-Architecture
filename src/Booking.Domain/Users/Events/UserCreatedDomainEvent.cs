using Booking.Domain.Abstractions;

namespace Booking.Domain.Users.Events;

public sealed record UserCreatedDomainEvent(Guid UserId) : IDomainEvent;
