using System.Linq;
using System.Collections.Generic;

using Microsoft.EntityFrameworkCore;

namespace Shift.Repository.Repositories.Implementations
{
    using Shift.DAL.Models.UserModels.GraduateData.JournalData;
    using Shift.Repository.Database;
    using Shift.Repository.Repositories.Interfaces;

    public class EducationPhaseRepository: BaseRepository<EducationPhase>, IEducationPhaseRepository
    {
        public EducationPhaseRepository(CoreContext context)
            : base(context)
        {
        }

        public virtual void UpdateEducationPhases(IEnumerable<EducationPhase> phases)
        {
            foreach(var phase in phases)
            {
                this.DeleteActivitiesExcept(phase.ScienceActivities, phase.Id);
                this.DeleteCalendarStageExcept(phase.CalendarStages, phase.Id);
            }
        }

        public virtual void DeleteCalendarStageExcept(IEnumerable<CalendarStage> stages, int id)
        {
            var dalStages = this.AppContext.CalendarStages.AsNoTracking().Where(e => e.EducationPhaseId == id).ToList();

            foreach (var stage in dalStages)
            {
                if (stages.FirstOrDefault(e => e.Id == stage.Id) == null)
                {
                    this.AppContext.Remove(stage);
                }
            }
        }

        public virtual void DeleteActivitiesExcept(IEnumerable<ScienceActivity> activities, int id)
        {
            var dalActivities = this.AppContext.ScienceActivities.AsNoTracking().Where(e => e.EducationPhaseId == id).ToList();

            foreach (var activity in dalActivities)
            {
                if (activities.FirstOrDefault(e => e.Id == activity.Id) == null)
                {
                    this.AppContext.Remove(activity);
                }
            }
        }
    }
}
