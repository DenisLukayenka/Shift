using Microsoft.EntityFrameworkCore;
using Shift.DAL.Models.UserModels.UserData;
using Shift.Repository.Database;
using Shift.Repository.Repositories.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Shift.Repository.Repositories.Implementations
{
    public class ExamRepository: BaseRepository<ExamInfo>, IExamRepository
    {
        public ExamRepository(CoreContext context)
            : base(context)
        {
        }

        public virtual void DeleteExcept(IEnumerable<ExamInfo> exceptExams, int journalId)
        {
            var dalExams = this.AppContext.ExamInfo.AsNoTracking().Where(e => e.GraduateJournalId == journalId).ToList();

            foreach(var exam in dalExams)
            {
                if(exceptExams.FirstOrDefault(e => e.Id == exam.Id) == null)
                {
                    this.AppContext.Remove(exam);
                }
            }
        }
    }
}
