using AutoMapper;
using Shift.DAL.Models.University;
using Shift.DAL.Models.UserModels.EmployeeData;
using Shift.DAL.Models.UserModels.GraduateData;
using Shift.DAL.Models.UserModels.GraduateData.JournalData;
using Shift.DAL.Models.UserModels.UndergraduateData;
using Shift.DAL.Models.UserModels.UndergraduateData.JournalData;
using Shift.DAL.Models.UserModels.UserData;
using Shift.Infrastructure.Models.ViewModels.Auth;
using Shift.Infrastructure.Models.ViewModels.Data;
using Shift.Infrastructure.Models.ViewModels.Journals;
using Shift.Infrastructure.Models.ViewModels.Journals.GJournalData;
using Shift.Infrastructure.Models.ViewModels.Journals.UJournalData;
using Shift.Infrastructure.Models.ViewModels.Journals.University;
using Shift.Infrastructure.Models.ViewModels.Users;
using System.Collections.Generic;
using System.Linq;

namespace Shift.Infrastructure.Mappings
{
	public class MappingProfile : Profile
	{
		public MappingProfile()
		{
			CreateMap<Protocol, ProtocolVM>().ReverseMap();
			CreateMap<PreparationInfo, PreparationInfoVM>().ReverseMap();
			CreateMap<ThesisCertification, ThesisCertificationVM>().ReverseMap();
			CreateMap<Report, ReportVM>().ReverseMap();

			CreateMap<UndergraduateJournal, UJournal>()
				.ForMember(dest => dest.PreparationInfo, opt => opt.MapFrom(src => src.PreparationInfo))
				.ForMember(dest => dest.ReportResults, opt => opt.MapFrom(src => src.ReportResults))
				.ForMember(dest => dest.ThesisCertification, opt => opt.MapFrom(src => src.ThesisCertification))
				.ReverseMap();

			CreateMap<UndergraduateViewModel, User>()
				.ForMember(dest => dest.LoginData, opt => opt.MapFrom((src, dest) => new List<LoginInfo>()
				{
					new LoginInfo()
					{
						HashPassword = src.Password,
						Login = src.Login,
					}
				}));
			CreateMap<GraduateViewModel, User>()
				.ForMember(dest => dest.LoginData, opt => opt.MapFrom((src, dest) => new List<LoginInfo>()
				{
					new LoginInfo()
					{
						HashPassword = src.Password,
						Login = src.Login,
					}
				}));
			CreateMap<EmployeeViewModel, User>()
				.ForMember(dest => dest.LoginData, opt => opt.MapFrom((src, dest) => new List<LoginInfo>()
					{
					new LoginInfo()
					{
						HashPassword = src.Password,
						Login = src.Login,
					}
				}));

			CreateMap<UndergraduateViewModel, Undergraduate>()
				.ForMember(dest => dest.User, opt => opt.MapFrom(src => src))
				.ForMember(dest => dest.ScienceAdviserId, opt => opt.MapFrom(src => src.AdviserId));

			CreateMap<GraduateViewModel, Graduate>()
				.ForMember(dest => dest.User, opt => opt.MapFrom(src => src))
				.ForMember(dest => dest.ScienceAdviserId, opt => opt.MapFrom(src => src.AdviserId));

			CreateMap<EmployeeViewModel, Employee>()
				.ForMember(dest => dest.User, opt => opt.MapFrom(src => src))
				.ForMember(dest => dest.AcademicDegreeId, opt => opt.MapFrom(src => src.DegreeId))
				.ForMember(dest => dest.AcademicRankId, opt => opt.MapFrom(src => src.RankId));

			CreateMap<User, UserContext>()
				.ForMember(dest => dest.Login, opt => opt.MapFrom((src, dest) => src.LoginData.FirstOrDefault()?.Login ?? ""))
				.ForMember(dest => dest.Role, opt => opt.MapFrom((src, dest) => src.Role?.Caption ?? ""))
				.ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.Id))
				.ForMember(dest => dest.SpecifiesUserId, opt => opt.MapFrom((src, dest) => src.EmployeeId ?? src.UndergraduateId ?? src.GraduateId));

			CreateMap<RationalInfoVM, RationalInfo>()
				.ForMember(dest => dest.Protocol, opt => opt.MapFrom(src => src.Protocol))
				.ReverseMap();

			this.RegisterGJournalMappings();
			this.RegisterUndergraduateMappings();
			this.RegisterDataMappings();
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
				.ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.User.Id))
				.ForMember(dest => dest.SpecifiesUserId, opt => opt.MapFrom((src, dest) => src.GraduateId))
				.ForMember(dest => dest.JournalId, opt => opt.MapFrom((src, dest) => src.GraduateJournals.FirstOrDefault()?.Id));

			CreateMap<Undergraduate, UndergraduateContext>()
				.ForMember(dest => dest.Login, opt => opt.MapFrom((src, dest) => src.User.LoginData.FirstOrDefault()?.Login ?? ""))
				.ForMember(dest => dest.Role, opt => opt.MapFrom((src, dest) => src.User.Role?.Caption ?? ""))
				.ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.User.Id))
				.ForMember(dest => dest.SpecifiesUserId, opt => opt.MapFrom((src, dest) => src.UndergraduateId))
				.ForMember(dest => dest.JournalId, opt => opt.MapFrom((src, dest) => src.Journals.FirstOrDefault()?.Id));
		}

		public void RegisterDataMappings()
		{
			CreateMap<AcademicDegree, AcademicDegreeVM>().ReverseMap();
			CreateMap<AcademicRank, AcademicRankVM>().ReverseMap();
			CreateMap<JobPosition, JobPositionVM>().ReverseMap();
		}
	}
}
