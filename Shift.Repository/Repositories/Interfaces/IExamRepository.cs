using Shift.DAL.Models.UserModels.UserData;
using System.Collections.Generic;

namespace Shift.Repository.Repositories.Interfaces
{
    public interface IExamRepository: IRepository<ExamInfo>
    {
        void DeleteExcept(IEnumerable<ExamInfo> exceptExams, int journalId);
    }
}
