using Shift.DAL.Models.UserModels.GraduateData;
using Shift.DAL.Models.UserModels.GraduateData.JournalData;
using Shift.Infrastructure.Models.ViewModels.Journals;
using Shift.Infrastructure.Models.ViewModels.Journals.GJournalData;

namespace Shift.Infrastructure.Mappings
{
    public class GraduateJournalMappingProfile : ContextsMappingProfile
    {
        public GraduateJournalMappingProfile()
        {
            CreateMap<GraduateJournal, GJournal>().ReverseMap();
            CreateMap<WorkStageVM, WorkStage>().ReverseMap();
            CreateMap<WorkPlanVM, WorkPlan>().ReverseMap();
            CreateMap<AttestationVM, Attestation>().ReverseMap();
            CreateMap<CalendarStageVM, CalendarStage>().ReverseMap();
            CreateMap<ScienceActivityVM, ScienceActivity>().ReverseMap();
            
            CreateMap<WorkPlanVM, WorkPlan>().ReverseMap();

            CreateMap<ThesisPlanVM, ThesisPlan>();
            CreateMap<ThesisPlan, ThesisPlanVM>()
                .ForMember(dest => dest.GraduateJournalId, opt => opt.MapFrom((src, dest) => src.GraduateJournal?.Id));

            CreateMap<EducationPhaseVM, EducationPhase>()
                .ForMember(dest => dest.CalendarStages, opt => opt.MapFrom(src => src.CalendarStages))
                .ForMember(dest => dest.ScienceActivities, opt => opt.MapFrom(src => src.ScienceActivities))
                .ForMember(dest => dest.Attestations, opt => opt.MapFrom(src => src.Attestations))
                .ReverseMap();

            CreateMap<RationalInfoVM, RationalInfo>();
            CreateMap<RationalInfo, RationalInfoVM>()
                .ForMember(dest => dest.GraduateJournalId, opt => opt.MapFrom((src, dest) => src.GraduateJournal?.Id));
        }
    }
}
