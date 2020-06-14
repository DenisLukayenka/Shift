using Shift.DAL.Models.UserModels.GraduateData.JournalData;
using System.Collections.Generic;

namespace Shift.Repository.Repositories.Interfaces
{
    public interface IEducationPhaseRepository: IRepository<EducationPhase>
    {
        void DeleteCalendarStageExcept(IEnumerable<CalendarStage> stages, int id);
        void DeleteActivitiesExcept(IEnumerable<ScienceActivity> activities, int id);

        void UpdateEducationPhases(IEnumerable<EducationPhase> phases);
    }
}
