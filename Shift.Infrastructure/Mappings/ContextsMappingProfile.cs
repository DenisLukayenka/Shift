using AutoMapper;

using System.Linq;

namespace Shift.Infrastructure.Mappings
{
	using Shift.DAL.Models.UserModels.GraduateData;
	using Shift.DAL.Models.UserModels.UndergraduateData;
	using Shift.DAL.Models.UserModels.UserData;
	using Shift.Infrastructure.Models.ViewModels.Users;

	public class ContextsMappingProfile : Profile
	{
		public ContextsMappingProfile()
		{
			CreateMap<Graduate, GraduateContext>()
				.ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.User.FirstName))
				.ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.User.LastName))
				.ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.User.FirstName))

				.ForMember(dest => dest.Login, opt => opt.MapFrom((src, dest) => src.User.LoginData.FirstOrDefault()?.Login ?? ""))
				.ForMember(dest => dest.Role, opt => opt.MapFrom((src, dest) => src.User.Role?.Caption ?? ""))
				.ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.User.UserId))
				.ForMember(dest => dest.SpecifiedUserId, opt => opt.MapFrom((src, dest) => src.GraduateId))
				.ForMember(dest => dest.JournalId, opt => opt.MapFrom((src, dest) => src.GraduateJournals.FirstOrDefault()?.Id));

			CreateMap<Undergraduate, UndergraduateContext>()
				.ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.User.FirstName))
				.ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.User.LastName))
				.ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.User.FirstName))

				.ForMember(dest => dest.Login, opt => opt.MapFrom((src, dest) => src.User.LoginData.FirstOrDefault()?.Login ?? ""))
				.ForMember(dest => dest.Role, opt => opt.MapFrom((src, dest) => src.User.Role?.Caption ?? ""))
				.ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.User.UserId))
				.ForMember(dest => dest.SpecifiedUserId, opt => opt.MapFrom((src, dest) => src.UndergraduateId))
				.ForMember(dest => dest.JournalId, opt => opt.MapFrom((src, dest) => src.Journals.FirstOrDefault()?.Id));

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
		}
	}
}
