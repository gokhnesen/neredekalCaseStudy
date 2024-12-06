using neredekalCaseStudy.Application.Features.HotelContacts.Commands.Create;

namespace neredekalCaseStudy.Application.Features.Hotels.Queries.GetById
{
    public class GetByIdHotelQueryResponse
    {
        public Guid Id { get; set; }
        public string CompanyName { get; set; }
        public string ManagerFirstName { get; set; }
        public string ManagerLastName { get; set; }
        public ICollection<CreateHotelContactResponse> ContactInformations { get; set; }
    }
}
