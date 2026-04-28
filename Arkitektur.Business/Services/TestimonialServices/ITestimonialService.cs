using Arkitektur.Business.DTOs.TestimonailDtos;
using Arkitektur.Business.Services.GenericServices;

namespace Arkitektur.Business.Services.TestimonialServices
{
    public interface ITestimonialService : IGenericService<ResultTestimonialDto,CreateTestimonialDto,UpdateTestimonialDto>
    {
    }
}
