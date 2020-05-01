using AutoMapper;
using Shift.DAL.Models.UserModels.EmployeeData;
using Shift.DAL.Models.UserModels.GraduateData;
using Shift.DAL.Models.UserModels.UndergraduateData;
using Shift.DAL.Models.UserModels.UndergraduateData.JournalData;
using Shift.DAL.Models.UserModels.UserData;
using Shift.Infrastructure.Models.ViewModels.Auth;
using Shift.Infrastructure.Models.ViewModels.Journals;
using Shift.Infrastructure.Models.ViewModels.Journals.UJournalData;
using System.Collections.Generic;
using System.Linq;

namespace Shift.Infrastructure.Mappings
{
	public class MappingProfile : Profile
	{
		public MappingProfile()
		{
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
				.ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.Id));

		}
	}
}
