using AutoMapper;
using Shift.DAL.Models.UserModels.EmployeeData;
using Shift.Infrastructure.Models.ViewModels.Auth;
using Shift.Infrastructure.Models.ViewModels.Users;
using System.Text;

namespace Shift.Infrastructure.Mappings
{
	public class EmployeeMappingProfile: Profile
	{
		public EmployeeMappingProfile()
		{
			CreateMap<EmployeeRegisterVM, Employee>()
				.ForMember(dest => dest.JobPositionId, opt => opt.MapFrom(src => src.JobPosition.Id))
				.ForMember(dest => dest.AcademicDegreeId, opt => opt.MapFrom(src => src.AcademicDegree.Id))
				.ForMember(dest => dest.AcademicRankId, opt => opt.MapFrom(src => src.AcademicRank.Id))
				.ForMember(dest => dest.DepartmentId, opt => opt.MapFrom(src => src.Department.Id))
				.ForMember(dest => dest.User, opt => opt.MapFrom(src => src.User))

				.ForMember(dest => dest.AcademicDegree, opt => opt.MapFrom((src, dest) => src.AcademicDegree?.Id != 0 ? null : src.AcademicDegree))
				.ForMember(dest => dest.AcademicRank, opt => opt.MapFrom((src, dest) => src.AcademicRank?.Id != 0 ? null : src.AcademicRank))
				.ForMember(dest => dest.JobPosition, opt => opt.MapFrom((src, dest) => src.JobPosition?.Id != 0 ? null : src.JobPosition))
				.ForMember(dest => dest.Department, opt => opt.MapFrom((src, dest) => src.Department?.Id != 0 ? null : src.Department));

			CreateMap<Employee, AdviserListItem>()
				.ForMember(dest => dest.EmployeeId, opt => opt.MapFrom(src => src.EmployeeId))
				.ForMember(dest => dest.Name, opt => opt.MapFrom((src, dest) =>
				{
					var adviserName = new StringBuilder();

					adviserName.Append(src.User.LastName);
					adviserName.Append(" ");
					adviserName.Append(src.User.FirstName.Substring(0, 1));
					adviserName.Append(". ");
					adviserName.Append(src.User.PatronymicName.Substring(0, 1));
					adviserName.Append(". ");

					return adviserName.ToString();
				}));
		}
	}
}
