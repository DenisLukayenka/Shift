using AutoMapper;
using Shift.DAL.Models.UserModels.GraduateData;
using Shift.DAL.Models.UserModels.GraduateData.JournalData;
using Shift.DAL.Models.UserModels.UndergraduateData;
using Shift.DAL.Models.UserModels.UserData;
using Shift.Infrastructure.Models.ViewModels.Auth;
using Shift.Infrastructure.Models.ViewModels.Journals;
using Shift.Infrastructure.Models.ViewModels.Journals.GJournalData;
using Shift.Infrastructure.Models.ViewModels.Users;
using System.Collections.Generic;
using System.Linq;

namespace Shift.Infrastructure.Mappings
{
	public class MappingProfile : Profile
	{
		public MappingProfile()
		{
			CreateMap<UndergraduateJournal, UJournal>()
				.ForMember(dest => dest.PreparationInfo, opt => opt.MapFrom(src => src.PreparationInfo))
				.ForMember(dest => dest.ReportResults, opt => opt.MapFrom(src => src.ReportResults))
				.ForMember(dest => dest.ThesisCertification, opt => opt.MapFrom(src => src.ThesisCertification))
				.ReverseMap();

			CreateMap<GraduateViewModel, User>()
				.ForMember(dest => dest.LoginData, opt => opt.MapFrom((src, dest) => new List<LoginInfo>()
				{
					new LoginInfo()
					{
						HashPassword = src.Password,
						Login = src.Login,
					}
				}));

			CreateMap<GraduateViewModel, Graduate>()
				.ForMember(dest => dest.User, opt => opt.MapFrom(src => src))
				.ForMember(dest => dest.ScienceAdviserId, opt => opt.MapFrom(src => src.AdviserId));


			CreateMap<User, UserContext>()
				.ForMember(dest => dest.Login, opt => opt.MapFrom((src, dest) => src.LoginData.FirstOrDefault()?.Login ?? ""))
				.ForMember(dest => dest.Role, opt => opt.MapFrom((src, dest) => src.Role?.Caption ?? ""))
				.ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId))
				.ForMember(dest => dest.SpecifiedUserId, opt => opt.MapFrom((src, dest) => 
				{
					if (src.Undergraduate != null)
					{
						return src.Undergraduate.UndergraduateId;
					}
					if (src.Graduate != null)
					{
						return src.Graduate.GraduateId;
					}
					
					return src.Employee?.EmployeeId;
				}));

			CreateMap<RationalInfoVM, RationalInfo>()
				.ForMember(dest => dest.Protocol, opt => opt.MapFrom(src => src.Protocol))
				.ReverseMap();

			this.RegisterGJournalMappings();
			this.RegisterUndergraduateMappings();
		}

		public void RegisterGJournalMappings()
		{
			CreateMap<ThesisPlanVM, ThesisPlan>().ReverseMap();
			CreateMap<WorkPlanVM, WorkPlan>().ReverseMap();
			CreateMap<EducationPhaseVM, EducationPhase>()
				.ForMember(dest => dest.CalendarStages, opt => opt.MapFrom(src => src.CalendarStages))
				.ForMember(dest => dest.ScienceActivities, opt => opt.MapFrom(src => src.ScienceActivities))
				.ForMember(dest => dest.Attestations, opt => opt.MapFrom(src => src.Attestations))
				.ReverseMap();

			CreateMap<CalendarStageVM, CalendarStage>().ReverseMap();
			CreateMap<ScienceActivityVM, ScienceActivity>().ReverseMap();
			CreateMap<AttestationVM, Attestation>()
				.ForMember(dest => dest.Protocol, opt => opt.MapFrom(src => src.Protocol))
				.ReverseMap();

			CreateMap<WorkPlanVM, WorkPlan>()
				.ForMember(dest => dest.WorkStages, opt => opt.MapFrom(src => src.WorkStages))
				.ReverseMap();

			CreateMap<WorkStageVM, WorkStage>().ReverseMap();

			CreateMap<GraduateJournal, GJournal>()
				.ForMember(dest => dest.ThesisPlan, opt => opt.MapFrom(src => src.ThesisPlan))
				.ForMember(dest => dest.RationalInfo, opt => opt.MapFrom(src => src.RationalInfo))
				.ForMember(dest => dest.EducationYears, opt => opt.MapFrom(src => src.EducationYears))
				.ForMember(dest => dest.WorkPlans, opt => opt.MapFrom(src => src.WorkPlans))
				.ReverseMap();
		}

		public void RegisterUndergraduateMappings()
		{
			CreateMap<Graduate, GraduateContext>()
				.ForMember(dest => dest.Login, opt => opt.MapFrom((src, dest) => src.User.LoginData.FirstOrDefault()?.Login ?? ""))
				.ForMember(dest => dest.Role, opt => opt.MapFrom((src, dest) => src.User.Role?.Caption ?? ""))
				.ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.User.UserId))
				.ForMember(dest => dest.SpecifiedUserId, opt => opt.MapFrom((src, dest) => src.GraduateId))
				.ForMember(dest => dest.JournalId, opt => opt.MapFrom((src, dest) => src.GraduateJournals.FirstOrDefault()?.Id));

			CreateMap<Undergraduate, UndergraduateContext>()
				.ForMember(dest => dest.Login, opt => opt.MapFrom((src, dest) => src.User.LoginData.FirstOrDefault()?.Login ?? ""))
				.ForMember(dest => dest.Role, opt => opt.MapFrom((src, dest) => src.User.Role?.Caption ?? ""))
				.ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.User.UserId))
				.ForMember(dest => dest.SpecifiedUserId, opt => opt.MapFrom((src, dest) => src.UndergraduateId))
				.ForMember(dest => dest.JournalId, opt => opt.MapFrom((src, dest) => src.Journals.FirstOrDefault()?.Id));
		}
	}
}
