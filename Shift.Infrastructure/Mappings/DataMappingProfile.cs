using AutoMapper;

namespace Shift.Infrastructure.Mappings
{
	using Shift.DAL.Models.University;
	using Shift.DAL.Models.UserModels.EmployeeData;
	using Shift.DAL.Models.UserModels.UserData;
	using Shift.Infrastructure.Models.ViewModels.Data;
	using Shift.Infrastructure.Models.ViewModels.Journals.GJournalData;
	using Shift.Infrastructure.Models.ViewModels.University;

	public class DataMappingProfile: Profile
	{
		public DataMappingProfile()
		{
			CreateMap<Protocol, ProtocolVM>().ReverseMap();

			CreateMap<AcademicDegree, AcademicDegreeVM>().ReverseMap();
			CreateMap<AcademicRank, AcademicRankVM>().ReverseMap();
			CreateMap<JobPosition, JobPositionVM>().ReverseMap();
			CreateMap<Department, DepartmentVM>().ReverseMap();
			CreateMap<Specialty, SpecialtyVM>().ReverseMap();
			CreateMap<ExamInfo, ExamInfoVM>().ReverseMap();
			CreateMap<Discipline, DisciplineVM>().ReverseMap();
		}
	}
}
