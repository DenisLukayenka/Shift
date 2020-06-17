using Shift.DAL.Models.UserModels.GraduateData;

namespace Shift.FileGenerator.GJournal
{
    public interface IGJConverter
    {
        byte[] Convert(GraduateJournal journal);
    }
}
