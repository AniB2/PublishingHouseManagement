using FluentValidation;
using System.Text.RegularExpressions;

namespace PublishingHouseManagement.Application.Common.Validators.Extensions
{
    public static class ValidationExtensions
    {
        public static IRuleBuilderOptions<T, string> Email<T>(this IRuleBuilder<T, string> rule)
        {
            return rule.Must(x => Regex.IsMatch(x, @"@(([0-9a-zA-Z][-\w]*[0-9a-zA-Z]*\.)+[a-zA-Z0-9]{2,17})$")).WithMessage("Invalid email address format.");
        }
    }
}