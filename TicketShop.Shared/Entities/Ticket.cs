using System.Globalization;

namespace TicketShop.Shared.Entities
{
    public class Ticket
    {
        public string TimeSpan { get; set; }

        public string Zone { get; set; }

        public int PriceInEurCents { get; set; }

        public string Price
        {
            get
            {
                double eur = PriceInEurCents / 100f;
                return eur.ToString("C", CultureInfo.CurrentCulture);
            }
        }
    }
}