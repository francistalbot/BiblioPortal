namespace BiblioPortal.Models
{
    public class MembershipType
    {
        public byte Id {  get; set; }
        public string Name { get; set; } = string.Empty;
        public short SignUpFee { get; set; }
        public byte DurationInMonths { get; set; }
        public byte DiscountRate { get; set; }
    }
}
