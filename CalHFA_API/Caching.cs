using System;
using Microsoft.Extensions.Caching.Memory;

namespace CalHFA_API
{
    public static class Caching
    {
        // Expiration set for two hours
        private static int ExpirationDurationMinutes = 120;
        // 0 seconds in UNIX time. Ensures we will be expired when we first start the API
        private static DateTimeOffset CachedLoansExpirationTime = new DateTimeOffset(1970, 1, 1, 0, 0, 0, TimeSpan.Zero);
        private static Loans CachedLoans = new Loans();

        public static void SetCachedLoans(Loans UpdatedLoans)
        {
            CachedLoans = UpdatedLoans;
            UpdateCachedLoansExpiration();
        }

        public static Loans GetCachedLoans()
        {
            return CachedLoans;
        }

        public static void UpdateCachedLoansExpiration()
        {
            CachedLoansExpirationTime = DateTime.Now.AddMinutes(ExpirationDurationMinutes);
        }

        public static bool CachedLoansIsExpired()
        {
            return DateTime.Now > CachedLoansExpirationTime;
        }
    }
}
