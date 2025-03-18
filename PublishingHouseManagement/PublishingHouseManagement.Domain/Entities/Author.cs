namespace PublishingHouseManagement.Domain.Entities
{
    public class Author
    {
        public int Id {  get; set; }
        public string FirstName {  get; set; }
        public string LastName {  get; set; }
        public int Gender {  get; set; }
        public string PrivateNumber { get; set; } 
        public DateTime BirthDate { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public bool IsDelete { get; set; }
        public ICollection<Product> Products { get; set; } = new List<Product>();
    }
}