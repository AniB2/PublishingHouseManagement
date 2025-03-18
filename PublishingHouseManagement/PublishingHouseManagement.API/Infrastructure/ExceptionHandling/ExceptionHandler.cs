using Microsoft.AspNetCore.Mvc;
using System.Net;
using PublishingHouseManagement.Application.Common.Exceptions;

namespace LibraryManagement.API.Infrastrcture.ExceptionHandling
{
    public class ExceptionHandler : ProblemDetails
    {
        private const string UnexpectedErrorCode = "Unexpected error";
        private HttpContext _context;
        private Exception _exception;
        public string Code { get; set; }
        public LogLevel LogLevel { get; set; }
        public ExceptionHandler(HttpContext context, Exception exception)
        {
            _context = context;
            _exception = exception;
            Code = UnexpectedErrorCode;
            Status = (int)HttpStatusCode.InternalServerError;
            LogLevel = LogLevel.Error;
            Instance = context.Request.Path;
            Title = exception.Message;

            ExceptionHandling((dynamic)exception);
        }
        private void ExceptionHandling(NotFoundException exception)
        {
            Code = exception.notFound;
            Status = (int)HttpStatusCode.NotFound;
            LogLevel = LogLevel.Information;
            Title = exception.Message;
            Type = "https://datatracker.ietf.org/doc/html/rfc7231#section-6.5.4";
        }
        private void ExceptionHandling(AlreadyExistsException exception)
        {
            Code = exception.alreadyExists;
            Status = (int)HttpStatusCode.Conflict;
            LogLevel = LogLevel.Information;
            Title = exception.Message;
            Type = "https://datatracker.ietf.org/doc/html/rfc7231#section-6.5.8";
        }
        private void ExceptionHandling(InvalidInputException exception)
        {
            Code = exception.invalidInput;
            Status = (int)HttpStatusCode.BadRequest;
            LogLevel = LogLevel.Information;
            Title = exception.Message;
            Type = "https://datatracker.ietf.org/doc/html/rfc7231#section-6.5.1";
        }
        private void ExceptionHandling(UserUnauthorizedException exception)
        {
            Code = exception.userUnauthorized;
            Status = (int)HttpStatusCode.Unauthorized;
            LogLevel = LogLevel.Information;
            Title = exception.Message;
            Type = "https://datatracker.ietf.org/doc/html/rfc7231#section-3.1";
        }
        private void ExceptionHandling(NotAvailableException exception)
        {
            Code = exception.notAvailable;
            Status = (int)HttpStatusCode.Conflict;
            LogLevel = LogLevel.Information;
            Title = exception.Message;
            Type = "https://datatracker.ietf.org/doc/html/rfc7231#section-6.5.8";
        }
        private void ExceptionHandling(Exception exception) { }
    }
}