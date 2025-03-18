namespace PublishingHouseManagement.Application.Common.Exceptions
{
    public class UserUnauthorizedException : Exception
    {
        public string userUnauthorized = "User Unauthorized";
        public UserUnauthorizedException(string message) : base(message) { }
    }
}