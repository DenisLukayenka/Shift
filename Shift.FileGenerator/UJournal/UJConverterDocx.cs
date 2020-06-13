using System;
using System.IO;
using System.Text;
using System.Collections.Generic;

using TemplateEngine.Docx;

namespace Shift.FileGenerator.UJournal
{
    using Shift.DAL.Models.University;
    using Shift.DAL.Models.UserModels.UndergraduateData;
    using Shift.DAL.Models.UserModels.UndergraduateData.JournalData;
    using Shift.DAL.Models.UserModels.UserData;
    using Shift.Infrastructure.Extensions;

    public class UJConverterDocx : IUJConverter
    {
        public byte[] Convert(UndergraduateJournal journal)
        {
            string templatePath = this.GetInputTemplatePath();
            string outputPath = this.GetOutputTemplatePath(journal.UndergraduateId ?? 0);

            if (File.Exists(outputPath))
            {
                File.Delete(outputPath);
            }
            
            File.Copy(templatePath, outputPath);

            TableContent researchWorksContent = this.GetResearchesContent(journal.PreparationInfo.ResearchWorks);
            RepeatContent reportsContent = this.GetReportsFields(journal.ReportResults, journal.Undergraduate.Specialty?.Department?.Head);

            Content preparationInfoContent = this.GetPreparationInfoContent(journal.PreparationInfo);
            Content thesisCertificationContent = this.GetThesisContent(journal.ThesisCertification);
            Content universityContent = this.GetUniversityContent(journal.Undergraduate.Specialty);

            Content ujContent = this.GetUJContent(journal.Undergraduate);
            ujContent.Repeats.Add(reportsContent);
            ujContent.Tables.Add(researchWorksContent);

            using (var outputDoc = new TemplateProcessor(outputPath).SetRemoveContentControls(true))
            {
                outputDoc.FillContent(ujContent);

                outputDoc.FillContent(universityContent);
                outputDoc.FillContent(preparationInfoContent);
                outputDoc.FillContent(thesisCertificationContent);
                outputDoc.SaveChanges();
            }

            return File.ReadAllBytes(outputPath);
        }

        protected virtual string GetInputTemplatePath()
        {
            var currentDirectory = GetProjectRootDirectory();
            var templatePath = Path.Combine(currentDirectory, "Templates", "UndergraduateTemplate.docx");

            return templatePath;
        }

        protected virtual string GetOutputTemplatePath(int undergraduateId)
        {
            var currentDirectory = GetProjectRootDirectory();
            var templatePath = Path.Combine(currentDirectory, "Templates", "Temp", $"UndergraduateOutput-{undergraduateId}.docx");

            return templatePath;
        }

        protected virtual string GetProjectRootDirectory()
        {
            return Environment.CurrentDirectory;
        }

        protected virtual RepeatContent GetReportsFields(IEnumerable<Report> reports, string head)
        {
            var reportsContent = new RepeatContent("UReports");
            foreach(var report in reports)
            {
                reportsContent.AddItem(
                    new FieldContent("ReportResult", report.Result),
                    new FieldContent("ProtocolDate", report.Protocol?.Date?.ToShortDateString() ?? ""),
                    new FieldContent("ProtocolNumber", report.Protocol?.Number?.ToString() ?? ""),
                    new FieldContent("DepartmentHeadSign", head.ValueOrDefault()));
            }

            return reportsContent;
        }

        protected virtual Content GetUniversityContent(Specialty specialty)
        {
            return new Content(
                new FieldContent("Faculty", specialty?.Department?.Faculty?.Name.ValueOrDefault()),
                new FieldContent("Department", specialty?.Department?.Name.ValueOrDefault()),
                new FieldContent("Specialty", this.GetFullSpecialtyName(specialty).ValueOrDefault()),
                new FieldContent("ViceRectorSign", specialty?.Department?.Faculty?.University?.ViceRector.ValueOrDefault()),
                new FieldContent("TrainingHeadSign", specialty?.Department?.Faculty?.University?.ScientificTrainingHead.ValueOrDefault()),
                new FieldContent("FacultyDeanSign", specialty?.Department?.Faculty?.Dean.ValueOrDefault()),
                new FieldContent("DepartmentHeadSign", specialty?.Department?.Head.ValueOrDefault())
            );
        }

        protected virtual Content GetUJContent(Undergraduate undergraduate)
        {
            return new Content(
                new FieldContent("UndergraduateSign", this.ConvertToSignName(undergraduate.User)),
                new FieldContent("AdviserSign", this.ConvertToSignName(undergraduate.ScienceAdviser.User)),
                new FieldContent("UndergraduateFullName", this.ConvertToFullName(undergraduate.User)),
                new FieldContent("UEducationForm", this.EducationFormToString(undergraduate.EducationForm)),
                new FieldContent("StartEducationDate", undergraduate.StartEducationDate?.ToShortDateString() ?? ""),
                new FieldContent("FinishEducationDate", undergraduate.FinishEducationDate?.ToShortDateString() ?? "")
            );
        }

        protected virtual TableContent GetResearchesContent(IEnumerable<ResearchWork> works)
        {
            var researchesContent = new TableContent("ResearchWorkTable");
            foreach (var work in works)
            {
                researchesContent.AddRow(
                    new FieldContent("JobType", work.JobType.ValueOrDefault()),
                    new FieldContent("PresentationType", work.PresentationType.ValueOrDefault()),
                    new FieldContent("StartDate", work.StartDate?.ToShortDateString() ?? ""),
                    new FieldContent("FinishDate", work.FinishDate?.ToShortDateString() ?? ""));
            }

            return researchesContent;
        }

        protected virtual Content GetThesisContent(ThesisCertification thesis)
        {
            return new Content(
                new FieldContent("PreliminaryResult", thesis?.PreliminaryResult.ValueOrDefault()),
                new FieldContent("ProtocolDate", thesis?.Protocol?.Date?.ToShortDateString() ?? ""),
                new FieldContent("ProtocolNumber", thesis?.Protocol?.Number?.ToString() ?? ""),
                new FieldContent("Mark", thesis?.Mark != null && thesis.Mark == 0 ? "" : thesis?.Mark.ToString()),
                new FieldContent("IsApprovedCertification", thesis.IsApproved ? "защищена" : "не защищена" )
            );
        }

        protected virtual Content GetPreparationInfoContent(PreparationInfo info)
        {
            return new Content(
                new FieldContent("Topic", info.Topic.ValueOrDefault()),
                new FieldContent("Relevance", info.Relevance.ValueOrDefault()),
                new FieldContent("Objectives", info.Objectives.ValueOrDefault()),
                new FieldContent("ResearchProcedure", info.ResearchProcedure.ValueOrDefault()),
                new FieldContent("Additions", info.Additions.ValueOrDefault())
            );
        }

        private string ConvertToSignName(User user)
        {
            var sb = new StringBuilder();
            if(user.FirstName != null && user.FirstName.Length > 0)
            {
                sb.Append($"{user.FirstName[0]}. ");
            }
            if (user.PatronymicName != null && user.PatronymicName.Length > 0) 
            {
                sb.Append($"{user.PatronymicName[0]}. ");
            }
            if(user.LastName != null)
            {
                sb.Append(user.LastName);
            }

            return sb.ToString();
        }

        private string ConvertToFullName(User user)
        {
            var sb = new StringBuilder();

            if(user.LastName != null)
            {
                sb.Append(user.LastName);
            }
            if(user.FirstName != null)
            {
                sb.Append(" ");
                sb.Append(user.FirstName);
            }
            if (user.PatronymicName != null)
            {
                sb.Append(" ");
                sb.Append(user.PatronymicName);
            }

            return sb.ToString();
        }

        private string EducationFormToString(EducationForm form)
        {
            return form == EducationForm.DAILY ? "дневная" : "заочная";
        }

        private string GetFullSpecialtyName(Specialty specialty)
        {
            return specialty?.Code + " " + specialty?.Title;
        }
    }
}
