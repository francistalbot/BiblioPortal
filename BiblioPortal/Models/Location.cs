using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace BiblioPortal.Models
{
    [PrimaryKey(nameof(ClientId), nameof(OutilId), nameof(Date))]
    public class Location
    {
        [Key]
        [Column(Order = 0)]
        public int ClientId { get; set; }
        [Key]
        [Column(Order = 1)]
        public int OutilId { get; set; }
        [Key]
        [Column(Order = 2)]
        public DateTime Date { get; set; }= DateTime.Now;
        public virtual Client Client { get; set; }
        public virtual Outil Outil { get; set; }
    }
}
