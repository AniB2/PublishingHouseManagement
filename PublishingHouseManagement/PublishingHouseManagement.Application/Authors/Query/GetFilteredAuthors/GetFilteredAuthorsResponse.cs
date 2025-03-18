namespace PublishingHouseManagement.Application.Authors.Query.GetFilteredAuthors
{
    public class GetFilteredAuthorsResponse
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool Gender { get; set; }
        public string PrivateNumber { get; set; }
        public DateTime BirthDate { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public bool IsDelete { get; set; }
    }
}