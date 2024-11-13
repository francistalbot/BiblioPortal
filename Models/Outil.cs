namespace BiblioPortal.Models
{
    public class Outil
    {
        public Outil()
        {
            Locations = new HashSet<Location>();
        }
        public int Id {  get; set; }
        public string? name { get; set; }
        public string? description { get; set; }
        public ICollection<Location>? Locations { get; set; }

    }
}
