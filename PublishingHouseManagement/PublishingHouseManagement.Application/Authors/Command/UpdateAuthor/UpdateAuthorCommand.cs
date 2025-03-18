using MediatR;
using PublishingHouseManagement.Application.Common.Enums;

namespace PublishingHouseManagement.Application.Authors.Command.UpdateAuthor
{
    public class UpdateAuthorCommand : IRequest<UpdateAuthorResponse>
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Gender Gender { get; set; }
        public string PrivateNumber { get; set; }
        public DateTime BirthDate { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
    }
}