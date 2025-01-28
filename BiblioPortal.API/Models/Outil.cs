using System.ComponentModel.DataAnnotations;
namespace BiblioPortal.API.Models
{
    public class Outil
    {
        public int Id {  get; set; }
        [Required]
        [StringLength(255)]
        public string? Name { get; set; }
        public string? Description { get; set; }

    }
}
