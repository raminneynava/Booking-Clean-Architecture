using Booking.Application.Abstractions.Messaging;

namespace Booking.Application.Reviews.AddReview;

public sealed record AddReviewCommand(Guid BookingId, int Rating, string Comment) : ICommand;
