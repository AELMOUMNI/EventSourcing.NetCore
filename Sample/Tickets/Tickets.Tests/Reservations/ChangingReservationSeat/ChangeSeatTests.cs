using FluentAssertions;
using Tickets.Reservations.ChangingReservationSeat;
using Tickets.Tests.Builders;
using Tickets.Tests.Extensions;
using Xunit;

namespace Tickets.Tests.Reservations.ChangingReservationSeat;

public class ChangeSeatTests
{
    [Fact]
    public void ForValidParams_UpdatesSeatId()
    {
        // Given
        var reservation = ReservationBuilder
            .Create()
            .Tentative()
            .Build();

        var newSeatId = Guid.NewGuid();

        // When
        reservation.ChangeSeat(newSeatId);

        // Then
        reservation.SeatId.Should().Be(newSeatId);

        var @event = reservation.PublishedEvent<ReservationSeatChanged>();

        @event.Should().NotBeNull();
        @event.Should().BeOfType<ReservationSeatChanged>();
        @event!.ReservationId.Should().Be(reservation.Id);
        @event.SeatId.Should().Be(newSeatId);
    }
}
