using Shift.DAL.Models.UserModels.GraduateData;
using Shift.Infrastructure.Models.ViewModels.Auth;

namespace Shift.Infrastructure.Mappings
{
	public class GraduateMappingProfile: ContextsMappingProfile
	{
		public GraduateMappingProfile()
		{
			CreateMap<GraduateRegisterVM, Graduate>()
				.ForMember(dest => dest.EducationForm, opt => opt.MapFrom(src => src.EducationForm))
				.ForMember(dest => dest.SpecialtyId, opt => opt.MapFrom(src => src.SpecialtyId))
				.ForMember(dest => dest.ScienceAdviserId, opt => opt.MapFrom(src => src.AdviserId))
				.ForMember(dest => dest.StartEducationDate, opt => opt.MapFrom(src => src.StartEducationDate))
				.ForMember(dest => dest.FinishEducationDate, opt => opt.MapFrom(src => src.FinishEducationDate))
				.ForMember(dest => dest.User, opt => opt.MapFrom(src => src.User));
		}
	}
}
