using Shift.Infrastructure.Models.ViewModels.Journals;
using System;
using System.IO;

namespace Shift.FileGenerator.Undergraduate
{
    public class UJConverterDocx : IUJConverter
    {
        public byte[] Convert(UJournalVM journal)
        {
            string templatePath = this.GetInputTemplatePath();

            return File.ReadAllBytes(templatePath);
        }

        protected virtual string GetInputTemplatePath()
        {
            var currentDirectory = GetProjectRootDirectory();
            var templatePath = Path.Combine(currentDirectory, "Templates", "UndergraduateTemplate.docx");

            return templatePath;
        }

        protected virtual string GetProjectRootDirectory()
        {
            return Environment.CurrentDirectory;
        }
    }
}
