using TicketShop.Shared.Utils;
// ReSharper disable UnusedAutoPropertyAccessor.Global

namespace TicketShop.Shared.Entities
{
    public class Ticket
    {
        public string TimeSpan { get; init; }

        public string Zone { get; init; }

        public int PriceInEurCents { get; init; }

        public string Price => PriceUtils.FormatEurCentsAsEur(PriceInEurCents);
    }
}