using FluentAssertions;
using TicketShop.Shared.Entities;
using Xunit;

namespace TicketShop.Tests
{
    public class FormatPriceTest
    {
        [Fact]
        public void TicketFormatsPriceInCurrency()
        {
            var ticket = new Ticket {PriceInEurCents = 123};
            ticket.Price.Should().StartWith("1,23");
        }
    }
}