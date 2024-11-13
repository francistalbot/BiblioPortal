namespace BiblioPortal.Models
{
    public class Client
    {
        public Client()
        {
            Locations = new HashSet<Location>();
        }
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? DateOfBirth { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public ICollection<Location>? Locations { get; set; }
    }
}
