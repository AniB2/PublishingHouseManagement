namespace PublishingHouseManagement.Domain.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Annotation { get; set; }
        public int ProductType { get; set; }
        public string ISBN { get; set; } 
        public DateTime ReleaseDate { get; set; }
        public string PublishingHouse { get; set; }
        public string Address { get; set; } 
        public string NumberOfPages { get; set; }
        public bool IsPublished { get; set; }
        public bool IsArchive { get; set; }
        public ICollection<Author> Authors { get; set; } = new List<Author>();
    }
}