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
        
        [Required(ErrorMessage = "Entrer le nom du client")]
        [StringLength(255)]
        [Display(Name = "Nom")]
        public string? Name { get; set; }
        
        [Display(Name = "Date de naissance")]
        public string? DateOfBirth { get; set; }
        
        [Display(Name = "Courriel")]
        public string? Email { get; set; }
        
        [Display(Name = "Numéro de Téléphone")]
        public string? Phone { get; set; }
        
        [Display(Name = "Newsletter")]
        public bool IsSubscribeToNewsletter {  get; set; }
        public MembershipType? MembershipType { get; set; }

        [Required]
        [Display(Name = "Type d'abonnement")]
        public byte MembershipTypeId { get; set; }
       
        public ICollection<Location>? Locations { get; set; }
    }
}
