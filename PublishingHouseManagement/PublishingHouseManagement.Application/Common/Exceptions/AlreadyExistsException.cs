namespace PublishingHouseManagement.Application.Common.Exceptions
{
    public class AlreadyExistsException : Exception
    {
        public string alreadyExists = "Already Exists";
        public AlreadyExistsException(string message) : base(message) { }
    }
}