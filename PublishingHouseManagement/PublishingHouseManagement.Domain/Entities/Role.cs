namespace PublishingHouseManagement.Domain.Entities
{
    public class Role
    {
        public int UserId { get; set; }
        public string UserRole { get; set; }
        public User User { get; set; }
    }
}