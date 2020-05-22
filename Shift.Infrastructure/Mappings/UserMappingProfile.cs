using AutoMapper;
using Shift.DAL.Models.UserModels.UserData;
using Shift.Infrastructure.Models.ViewModels.Auth;
using System.Collections.Generic;

namespace Shift.Infrastructure.Mappings
{
	class UserMappingProfile: Profile
	{
		public UserMappingProfile()
		{
			CreateMap<UserRegisterVM, User>()
				.ForMember(dest => dest.LoginData, opt => opt.MapFrom((src, dest) => new List<LoginInfo>()
				{
					new LoginInfo()
					{
						HashPassword = src.Login.Password,
						Login = src.Login.Login,
					}
				})); ;

			CreateMap<LoginVM, LoginInfo>()
				.ForMember(dest => dest.Login, opt => opt.MapFrom(src => src.Login))
				.ForMember(dest => dest.HashPassword, opt => opt.MapFrom(src => src.Password))
				.ReverseMap();
		}
	}
}
