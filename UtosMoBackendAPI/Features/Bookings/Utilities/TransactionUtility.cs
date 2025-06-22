namespace UtosMoBackendAPI.Features.Bookings.Utilities
{
    public static class TransactionUtility
    {
        public static string TransactionNumberGenerator(string previousTransactionNo)
        {
            if (string.IsNullOrEmpty(previousTransactionNo))
            {
                return string.Empty;
            }

            var sequenceNo = previousTransactionNo.Split("-").Skip(1).Take(1).FirstOrDefault();

            if (sequenceNo is null)
            {
                return string.Empty;
            }

            if (int.TryParse(sequenceNo, out int number))
            {
                int newSequenceNo = number + 1;

                return $"UM-{newSequenceNo.ToString("D6")}-{DateTime.Now.ToString("MMddyy")}";
            }

            return string.Empty;
        }
    }
}
