using AutoMapper;

namespace Shift.Infrastructure.Mappings
{
	using Shift.DAL.Models.University;
	using Shift.DAL.Models.UserModels.EmployeeData;
	using Shift.DAL.Models.UserModels.UndergraduateData.JournalData;
	using Shift.Infrastructure.Models.ViewModels.Data;
	using Shift.Infrastructure.Models.ViewModels.Journals.UJournalData;
	using Shift.Infrastructure.Models.ViewModels.Journals.University;
	using Shift.Infrastructure.Models.ViewModels.University;

	public class DataMappingProfile: Profile
	{
		public DataMappingProfile()
		{
			CreateMap<Protocol, ProtocolVM>().ReverseMap();
			CreateMap<PreparationInfo, PreparationInfoVM>().ReverseMap();
			CreateMap<ThesisCertification, ThesisCertificationVM>().ReverseMap();
			CreateMap<Report, ReportVM>().ReverseMap();

			CreateMap<AcademicDegree, AcademicDegreeVM>().ReverseMap();
			CreateMap<AcademicRank, AcademicRankVM>().ReverseMap();
			CreateMap<JobPosition, JobPositionVM>().ReverseMap();
			CreateMap<Department, DepartmentVM>().ReverseMap();
			CreateMap<Specialty, SpecialtyVM>().ReverseMap();
		}
	}
}
