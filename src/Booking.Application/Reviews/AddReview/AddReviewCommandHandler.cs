﻿using Booking.Application.Abstractions.Clock;
using Booking.Application.Abstractions.Messaging;
using Booking.Domain.Abstractions;
using Booking.Domain.Bookings;
using Booking.Domain.Reviews;

namespace Booking.Application.Reviews.AddReview;

internal sealed class AddReviewCommandHandler : ICommandHandler<AddReviewCommand>
{
    private readonly IBookingRepository _bookingRepository;
    private readonly IReviewRepository _reviewRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IDateTimeProvider _dateTimeProvider;

    public AddReviewCommandHandler(
        IBookingRepository bookingRepository,
        IReviewRepository reviewRepository,
        IUnitOfWork unitOfWork,
        IDateTimeProvider dateTimeProvider)
    {
        _bookingRepository = bookingRepository;
        _reviewRepository = reviewRepository;
        _unitOfWork = unitOfWork;
        _dateTimeProvider = dateTimeProvider;
    }

    public async Task<Result> Handle(AddReviewCommand request, CancellationToken cancellationToken)
    {
      Domain.Bookings.Booking? booking = await _bookingRepository.GetByIdAsync(request.BookingId, cancellationToken);

        if (booking is null)
        {
            return Result.Failure(BookingErrors.NotFound);
        }

        Result<Rating> ratingResult = Rating.Create(request.Rating);

        if (ratingResult.IsFailure)
        {
            return Result.Failure(ratingResult.Error);
        }

        Result<Review> reviewResult = Review.Create(
            booking,
            ratingResult.Value,
            new Comment(request.Comment),
            _dateTimeProvider.UtcNow);

        if (reviewResult.IsFailure)
        {
            return Result.Failure(reviewResult.Error);
        }

        _reviewRepository.Add(reviewResult.Value);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success();
    }
}
