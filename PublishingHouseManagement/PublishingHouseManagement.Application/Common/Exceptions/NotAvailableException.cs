namespace PublishingHouseManagement.Application.Common.Exceptions
{
    public class NotAvailableException : Exception
    {
        public string notAvailable = "Not Available";
        public NotAvailableException(string message) : base(message) { }
    }
}