using System;
using Xunit;
using FluentAssertions;
using TicketShop.Shared.Entities;

namespace TicketShop.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void TicketFormatsPriceInCurrency()
        {
            var ticket = new Ticket();
            ticket.PriceInEurCents = 123;
            ticket.Price.Should().StartWith("1,23");
        }
    }
}