using BiblioPortal.Models;

namespace BiblioPortal.ViewModels
{
    public class ClientFormViewModel
    {
        public IEnumerable<MembershipType>  MembershipTypes { get; set; }
        public Client Client { get; set; }
    }
}
