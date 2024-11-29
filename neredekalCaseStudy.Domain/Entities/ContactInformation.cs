namespace neredekalCaseStudy.Domain.Entities
{
    public class ContactInformation
    {
        public Guid Id { get; set; }
        public string InfoType { get; set; } //Phone,Email,Location
        public string InfoContent { get; set; }
        public Guid HotelId { get; set; }
        public Hotel Hotel { get; set; }
    }
}