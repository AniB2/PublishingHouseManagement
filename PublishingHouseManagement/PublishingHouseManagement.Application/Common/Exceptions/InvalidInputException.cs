namespace PublishingHouseManagement.Application.Common.Exceptions
{
    public class InvalidInputException : Exception
    {
        public string invalidInput = "Invalid Input";
        public InvalidInputException(string message) : base(message) { }
    }
}