namespace neredekalCaseStudy.Domain.Entities
{
    public class ContactInformation
    {
        public Guid Id { get; set; }
        public ContactType Type { get; set; }
        public string Content { get; set; }
        public Guid HotelId { get; set; }
    }

    public enum ContactType
    {
        PhoneNumber,
        Email,
        Location
    }
}