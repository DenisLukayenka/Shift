using Shift.DAL.Models.UserModels.UndergraduateData;

namespace Shift.FileGenerator.UJournal
{
    public interface IUJConverter
    {
        byte[] Convert(UndergraduateJournal journal);
    }
}
