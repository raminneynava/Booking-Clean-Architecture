﻿namespace Booking.Api.Controllers.Reviews;

public sealed record AddReviewRequest(Guid BookingId, int Rating, string Comment);
