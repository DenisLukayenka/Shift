using Shift.DAL.Models.UserModels.GraduateData.JournalData;
using System.Collections.Generic;

namespace Shift.Repository.Repositories.Interfaces
{
    public interface IWorkPlanRepository: IRepository<WorkPlan>
    {
        void DeleteExcept(IEnumerable<WorkPlan> plans, int journalId);
    }
}
