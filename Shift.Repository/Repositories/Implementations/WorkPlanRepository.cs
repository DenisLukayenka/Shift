using Microsoft.EntityFrameworkCore;
using Shift.DAL.Models.UserModels.GraduateData.JournalData;
using Shift.Repository.Database;
using Shift.Repository.Repositories.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Shift.Repository.Repositories.Implementations
{
    public class WorkPlanRepository: BaseRepository<WorkPlan>, IWorkPlanRepository
    {
        public WorkPlanRepository(CoreContext context)
            : base(context)
        {
        }

        public void DeleteExcept(IEnumerable<WorkPlan> plans, int journalId)
        {
            var dalPlans = this.AppContext.WorkPlans.AsNoTracking().Where(e => e.GraduateJournalId == journalId).ToList();

            foreach (var plan in dalPlans)
            {
                if (plans.FirstOrDefault(e => e.WorkPlanId == plan.WorkPlanId) == null)
                {
                    this.AppContext.Remove(plan);
                }
            }

            foreach(var plan in plans)
            {
                this.DeleteStagesExcept(plan.WorkStages, plan.WorkPlanId);
            }
        }

        private void DeleteStagesExcept(IEnumerable<WorkStage> stages, int planId)
        {
            var dalStages = this.AppContext.WorkStages.AsNoTracking().Where(e => e.WorkPlanId == planId).ToList();

            foreach (var stage in dalStages)
            {
                if (stages.FirstOrDefault(e => e.Id == stage.Id) == null)
                {
                    this.AppContext.Remove(stage);
                }
            }
        }
    }
}
