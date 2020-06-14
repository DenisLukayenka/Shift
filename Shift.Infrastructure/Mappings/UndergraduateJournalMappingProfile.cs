using Shift.DAL.Models.UserModels.UndergraduateData;
using Shift.DAL.Models.UserModels.UndergraduateData.JournalData;
using Shift.Infrastructure.Models.ViewModels.Journals;
using Shift.Infrastructure.Models.ViewModels.Journals.UJournalData;

namespace Shift.Infrastructure.Mappings
{
	public class UndergraduateJournalMappingProfile: ContextsMappingProfile
	{
		public UndergraduateJournalMappingProfile()
		{
			CreateMap<UndergraduateJournal, UJournalVM>()
				.ForMember(dest => dest.PreparationInfo, opt => opt.MapFrom(src => src.PreparationInfo))
				.ForMember(dest => dest.ReportResults, opt => opt.MapFrom(src => src.ReportResults))
				.ForMember(dest => dest.ThesisCertification, opt => opt.MapFrom(src => src.ThesisCertification))
				.ReverseMap();

			CreateMap<UJournalVM, UndergraduateJournal>()
				.ForMember(dest => dest.PreparationInfo, opt => opt.MapFrom(src => src.PreparationInfo))
				.ForMember(dest => dest.ReportResults, opt => opt.MapFrom(src => src.ReportResults))
				.ForMember(dest => dest.ThesisCertification, opt => opt.MapFrom(src => src.ThesisCertification))
				.ForMember(dest => dest.PreparationInfoId, opt => opt.MapFrom(src => src.PreparationInfoId))
				.ForMember(dest => dest.ThesisCertificationId, opt => opt.MapFrom(src => src.ThesisCertificationId))
				.ReverseMap();

			CreateMap<PreparationInfo, PreparationInfoVM>().ReverseMap();
			CreateMap<ThesisCertification, ThesisCertificationVM>().ReverseMap();
			CreateMap<ResearchWork, ResearchWorkVM>().ReverseMap();
			CreateMap<Report, ReportVM>().ReverseMap();
		}
	}
}
