using System.Globalization;

namespace TicketShop.Shared.Utils
{
    public static class PriceUtils
    {
        public static string FormatEurCentsAsEur(int eurCents)
        {
            double eur = eurCents / 100f;
            return eur.ToString("C", CultureInfo.CurrentCulture);
        }
    }
}