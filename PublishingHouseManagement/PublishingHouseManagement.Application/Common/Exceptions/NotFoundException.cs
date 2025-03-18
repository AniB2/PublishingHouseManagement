namespace PublishingHouseManagement.Application.Common.Exceptions
{
    public class NotFoundException : Exception
    {
        public string notFound = "Not Found";
        public NotFoundException(string message) : base(message) { }
    }
}