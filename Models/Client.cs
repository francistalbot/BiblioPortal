using System.ComponentModel.DataAnnotations;

namespace BiblioPortal.Models
{
    public class Client
    {
        public Client()
        {
            Locations = new HashSet<Location>();
        }
        public int Id { get; set; }
        [Required]
        [StringLength(255)]
        public string? Name { get; set; }
        public string? DateOfBirth { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public bool IsSubscribeToNewsletter {  get; set; }
        public MembershipType MembershipType { get; set; }
        public byte MembershipTypeId { get; set; }
        public ICollection<Location>? Locations { get; set; }
    }
}
