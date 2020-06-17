using Shift.DAL.Models.University;
using Shift.DAL.Models.UserModels.GraduateData;
using Shift.DAL.Models.UserModels.GraduateData.JournalData;
using Shift.DAL.Models.UserModels.UserData;
using Shift.Infrastructure.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using TemplateEngine.Docx;

namespace Shift.FileGenerator.GJournal
{
    public class GJConverterDocx : IGJConverter
    {
        public byte[] Convert(GraduateJournal journal)
        {
            string templatePath = this.GetInputTemplatePath();
            string outputPath = this.GetOutputTemplatePath(journal.GraduateId ?? 0);

            if (File.Exists(outputPath))
            {
                File.Delete(outputPath);
            }

            File.Copy(templatePath, outputPath);

            var tablesContent = new Content();
            tablesContent.Tables.Add(this.GenerateExamsContent(journal.ExamsData));
            tablesContent.Tables.Add(this.GenerateCalendarPlan(journal.EducationYears.FirstOrDefault().CalendarStages));

            using (var outputDoc = new TemplateProcessor(outputPath).SetRemoveContentControls(true))
            {
                outputDoc.FillContent(this.GenerateCommonDataContent(journal));
                outputDoc.FillContent(this.GenerateRationalInfo(journal.RationalInfo));
                outputDoc.FillContent(this.GenerateThesisPlan(journal.ThesisPlan));
                outputDoc.FillContent(this.GenerateWorkPlan(journal.WorkPlans.FirstOrDefault()));
                outputDoc.FillContent(this.GenerateEducationPhaseContent(journal.EducationYears.FirstOrDefault()));
                outputDoc.FillContent(this.GenerateAttestation(journal.EducationYears.FirstOrDefault().Attestations.FirstOrDefault()));

                outputDoc.FillContent(tablesContent);
                outputDoc.SaveChanges();
            }

            return File.ReadAllBytes(outputPath);
        }

        protected virtual Content GenerateCommonDataContent(GraduateJournal journal)
        {
            return new Content(
                new FieldContent("EducationForm", this.EducationFormToString(journal.Graduate?.EducationForm ?? EducationForm.DAILY)),
                new FieldContent("UserFullName", this.ConvertToFullName(journal.Graduate?.User) ?? ""),
                new FieldContent("SpecialtyName", journal.Graduate.Specialty?.Title ?? ""),
                new FieldContent("StartEducationDate", journal.Graduate.StartEducationDate?.ToShortDateString() ?? ""),
                new FieldContent("FinishEducationDate", journal.Graduate.FinishEducationDate?.ToShortDateString() ?? ""),
                new FieldContent("AdviserFullName", this.ConvertToFullName(journal.Graduate?.ScienceAdviser?.User) ?? ""),
                new FieldContent("DepartmentHeadSign", journal.Graduate?.Specialty?.Department?.Head ?? ""),
                new FieldContent("DepartmentFullName", journal.Graduate?.Specialty?.Department?.Name ?? ""),
                new FieldContent("ScienceWorkerSign", journal.Graduate?.Specialty?.Department?.Faculty?.University?.ScientificTrainingHead ?? ""),
                new FieldContent("AdviserSign", this.ConvertToSignName(journal.Graduate?.ScienceAdviser?.User) ?? ""),
                new FieldContent("GraduateSign", this.ConvertToSignName(journal.Graduate?.User) ?? "")
            );
        }

        protected virtual Content GenerateRationalInfo(RationalInfo info) 
        {
            return new Content(
                new FieldContent("StudyPurpose", info.StudyPurpose.ValueOrDefault()),
                new FieldContent("StudySubject", info.StudyObject.ValueOrDefault()),
                new FieldContent("StudySubject", info.StudySubject.ValueOrDefault()),
                new FieldContent("Justification", info.Justification.ValueOrDefault()),
                new FieldContent("ThesisPublications", info.ThesisPublications.ValueOrDefault()),
                new FieldContent("ResearchParticipation", info.ResearchParticipation.ValueOrDefault()),
                new FieldContent("DissertationTopic", info.DissertationTopic.ValueOrDefault()),
                new FieldContent("ClarificationProtocolDate", info.Protocol?.Date?.ToShortDateString() ?? ""),
                new FieldContent("ClarificationProtocolNumber", info.Protocol?.Number ?? "")
            );
        }

        protected virtual TableContent GenerateExamsContent(IEnumerable<ExamInfo> exams)
        {
            var examsData = new TableContent("ExamsData");
            foreach (var exam in exams)
            {
                examsData.AddRow(
                    new FieldContent("FullName", exam.Discipline?.FullName ?? ""),
                    new FieldContent("Mark", exam.Mark.ToString()),
                    new FieldContent("Date", exam.Date?.ToShortDateString() ?? "")
                );
            }

            return examsData;
        }

        protected virtual Content GenerateThesisPlan(ThesisPlan plan)
        {
            return new Content(
                new FieldContent("ThesisPlanAdviserApproveDate", plan.AdviserApproveDate?.ToShortDateString() ?? ""),
                new FieldContent("ThesisPlanSubmitDate", plan.SubmitDate?.ToShortDateString() ?? ""),
                new FieldContent("ThesisDessertation", plan.Info ?? "")
            );
        }

        protected virtual Content GenerateWorkPlan(WorkPlan plan)
        {
            var stages = new TableContent("WorkPlan");
            var content = new Content(
                new FieldContent("WorkPlanAdviserApproveDate", plan.AdviserApproveDate?.ToShortDateString() ?? ""),
                new FieldContent("WorkPlanSubmitDate", plan.SubmitDate?.ToShortDateString() ?? ""),
                new FieldContent("FinalCertification", plan.FinalCertification ?? ""),
                new FieldContent("CouncilNumber", plan.CouncilNumber ?? "")
            );

            foreach(var stage in plan.WorkStages)
            {
                stages.AddRow(
                    new FieldContent("JobInfo", stage.JobInfo.ValueOrDefault()),
                    new FieldContent("StartDate", stage.StartDate?.ToShortDateString() ?? ""),
                    new FieldContent("FinishDate", stage.FinishDate?.ToShortDateString() ?? ""),
                    new FieldContent("Note", stage.Note.ValueOrDefault())
                );
            }

            content.Tables.Add(stages);

            return content;
        }

        protected virtual Content GenerateEducationPhaseContent(EducationPhase phase)
        {
            var content = new Content(
                new FieldContent("TripsInternships", phase.TripsInternships.ValueOrDefault()),
                new FieldContent("SubWorks", phase.SubWorks.ValueOrDefault()),
                new FieldContent("EducationPhasePublications", phase.Publications.ValueOrDefault()),
                new FieldContent("EducationPhaseScienceParticipations", phase.ScienceParticipations.ValueOrDefault()),
                new FieldContent("EducationPhaseSubResearchResults", phase.SubResearchResults.ValueOrDefault()),
                new FieldContent("EducationPhaseReportSubmitDate", phase.SubmitDate?.ToShortDateString() ?? "")
            );

            var scienceActivities = this.GenerateScienceActivities(phase.ScienceActivities);
            var calendarReport = this.GenerateCalendarReport(phase.CalendarStages);

            content.Tables.Add(scienceActivities);
            content.Tables.Add(calendarReport);

            return content;
        }

        protected virtual TableContent GenerateCalendarPlan(IEnumerable<CalendarStage> stages)
        {
            int index = 1;

            var stagesData = new TableContent("CalendarPlan");
            foreach (var stage in stages)
            {
                stagesData.AddRow(
                    new FieldContent("Index", index.ToString()),
                    new FieldContent("StageName", stage.StageName.ValueOrDefault()),
                    new FieldContent("StartDate", stage.StartDate?.ToShortDateString() ?? ""),
                    new FieldContent("FinishDate", stage.FinishDate?.ToShortDateString() ?? ""),
                    new FieldContent("WaitResult", stage.WaitResult.ValueOrDefault())
                );

                index++;
            }

            return stagesData;
        }
        protected virtual TableContent GenerateScienceActivities(IEnumerable<ScienceActivity> activities)
        {
            var activitiesData = new TableContent("ScienceActivity");
            foreach (var activity in activities)
            {
                activitiesData.AddRow(
                    new FieldContent("Title", activity.Title.ValueOrDefault()),
                    new FieldContent("PlanResult", activity.PlanResult.ValueOrDefault()),
                    new FieldContent("StartDate", activity.StartDate?.ToShortDateString() ?? ""),
                    new FieldContent("FinishDate", activity.FinishDate?.ToShortDateString() ?? "")
                );
            }

            return activitiesData;
        }
        protected virtual TableContent GenerateCalendarReport(IEnumerable<CalendarStage> stages)
        {
            int index = 1;

            var plansContent = new TableContent("CalendarPlanResults");
            foreach (var stage in stages)
            {
                plansContent.AddRow(
                    new FieldContent("Index", index.ToString()),
                    new FieldContent("StageName", stage.StageName.ValueOrDefault()),
                    new FieldContent("OutcomeResult", stage.OutcomeResult.ValueOrDefault())
                );

                index++;
            }

            return plansContent;
        }

        protected virtual Content GenerateAttestation(Attestation attestation)
        {
            return new Content(
                new FieldContent("AttestationResult", attestation.AttestationResult.ValueOrDefault()),
                new FieldContent("AttestationAdviserApproveDate", attestation.AdviserApproveDate?.ToShortDateString() ?? ""),
                new FieldContent("DepartmentResult", attestation.DepartmentResult.ValueOrDefault()),
                new FieldContent("DepartmentProtocolDate", attestation.DepartmentProtocol?.Date?.ToShortDateString() ?? ""),
                new FieldContent("DepartmentProtocolNumber", attestation.DepartmentProtocol?.Number.ValueOrDefault()),

                new FieldContent("CommissionResult", attestation.CommissionResult.ValueOrDefault()),
                new FieldContent("CommissionProtocolDate", attestation.CommissionProtocol?.Date?.ToShortDateString() ?? ""),
                new FieldContent("CommissionProtocolNumber", attestation.CommissionProtocol?.Number.ValueOrDefault())
            );
        }


        protected virtual string GetInputTemplatePath()
        {
            var currentDirectory = GetProjectRootDirectory();
            var templatePath = Path.Combine(currentDirectory, "Templates", "GraduateTemplate.docx");

            return templatePath;
        }

        protected virtual string GetOutputTemplatePath(int graduateId)
        {
            var currentDirectory = GetProjectRootDirectory();
            var templatePath = Path.Combine(currentDirectory, "Templates", "Temp", $"GraduateOutput-{graduateId}.docx");

            return templatePath;
        }

        protected virtual string GetProjectRootDirectory()
        {
            return Environment.CurrentDirectory;
        }

        private string EducationFormToString(EducationForm form)
        {
            return form == EducationForm.DAILY ? "дневная" : "заочная";
        }

        private string ConvertToFullName(User user)
        {
            var sb = new StringBuilder();

            if (user.LastName != null)
            {
                sb.Append(user.LastName);
            }
            if (user.FirstName != null)
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

        private string ConvertToSignName(User user)
        {
            var sb = new StringBuilder();
            if (user.FirstName != null && user.FirstName.Length > 0)
            {
                sb.Append($"{user.FirstName[0]}. ");
            }
            if (user.PatronymicName != null && user.PatronymicName.Length > 0)
            {
                sb.Append($"{user.PatronymicName[0]}. ");
            }
            if (user.LastName != null)
            {
                sb.Append(user.LastName);
            }

            return sb.ToString();
        }
    }
}
