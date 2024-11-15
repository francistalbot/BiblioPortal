namespace BiblioPortal.Models
{
    public class Outil
    {
        public Outil()
        {
            Locations = new HashSet<Location>();
        }
        public int Id {  get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public ICollection<Location>? Locations { get; set; }

    }
}
