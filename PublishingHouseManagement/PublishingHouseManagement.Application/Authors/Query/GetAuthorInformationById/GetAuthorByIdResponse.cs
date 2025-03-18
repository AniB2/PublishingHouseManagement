namespace PublishingHouseManagement.Application.Authors.Query.GetAuthorInformationById
{
    public class GetAuthorByIdResponse
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
        public List<ProductResponse> Products { get; set; } 
    }
    public class ProductResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Annotation { get; set; }
        public string ProductType { get; set; }
        public string ISBN { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string PublishingHouse { get; set; }
        public string Address { get; set; }
        public string NumberOfPages { get; set; }
    }
}