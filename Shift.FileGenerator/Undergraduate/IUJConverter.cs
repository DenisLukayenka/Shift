using Shift.Infrastructure.Models.ViewModels.Journals;

namespace Shift.FileGenerator.Undergraduate
{
    public interface IUJConverter
    {
        byte[] Convert(UJournalVM journal);
    }
}
