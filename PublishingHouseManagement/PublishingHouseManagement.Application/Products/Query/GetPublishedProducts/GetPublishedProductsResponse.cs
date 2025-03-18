namespace PublishingHouseManagement.Application.Products.Query.GetPublishedProducts
{
    public class GetPublishedProductsResponse
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