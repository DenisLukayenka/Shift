using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Shift.Services.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AcademicDegrees",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DegreeName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AcademicDegrees", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AcademicRanks",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RankName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AcademicRanks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Disciplines",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(nullable: true),
                    Abbreviation = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Disciplines", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Faculties",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Abbreviation = table.Column<string>(nullable: true),
                    Dean = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Faculties", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "JobPositions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    ShortName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobPositions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Protocol",
                columns: table => new
                {
                    ProtocolId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(nullable: false),
                    Number = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Protocol", x => x.ProtocolId);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Caption = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UniversitySettings",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Abbreviation = table.Column<string>(nullable: true),
                    ViceRector = table.Column<string>(nullable: true),
                    ScientificTrainingHead = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UniversitySettings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Abbreviation = table.Column<string>(nullable: true),
                    Head = table.Column<string>(nullable: true),
                    FacultyId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Departments_Faculties_FacultyId",
                        column: x => x.FacultyId,
                        principalTable: "Faculties",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    PatronymicName = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    RoleId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Specialties",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(nullable: true),
                    Title = table.Column<string>(nullable: true),
                    DepartmentId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Specialties", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Specialties_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    EmployeeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(nullable: false),
                    JobPositionId = table.Column<int>(nullable: true),
                    AcademicDegreeId = table.Column<int>(nullable: true),
                    AcademicRankId = table.Column<int>(nullable: true),
                    DepartmentId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.EmployeeId);
                    table.ForeignKey(
                        name: "FK_Employees_AcademicDegrees_AcademicDegreeId",
                        column: x => x.AcademicDegreeId,
                        principalTable: "AcademicDegrees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Employees_AcademicRanks_AcademicRankId",
                        column: x => x.AcademicRankId,
                        principalTable: "AcademicRanks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Employees_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Employees_JobPositions_JobPositionId",
                        column: x => x.JobPositionId,
                        principalTable: "JobPositions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Employees_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LoginInfo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Login = table.Column<string>(nullable: true),
                    HashPassword = table.Column<string>(nullable: true),
                    Salt = table.Column<string>(nullable: true),
                    UserId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoginInfo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LoginInfo_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Graduates",
                columns: table => new
                {
                    GraduateId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(nullable: false),
                    EducationForm = table.Column<int>(nullable: false),
                    StartEducationDate = table.Column<DateTime>(nullable: false),
                    FinishEducationDate = table.Column<DateTime>(nullable: false),
                    ScienceAdviserId = table.Column<int>(nullable: true),
                    SpecialtyId = table.Column<int>(nullable: true),
                    DepartmentId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Graduates", x => x.GraduateId);
                    table.ForeignKey(
                        name: "FK_Graduates_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Graduates_Employees_ScienceAdviserId",
                        column: x => x.ScienceAdviserId,
                        principalTable: "Employees",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Graduates_Specialties_SpecialtyId",
                        column: x => x.SpecialtyId,
                        principalTable: "Specialties",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Graduates_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Undergraduates",
                columns: table => new
                {
                    UndergraduateId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(nullable: false),
                    EducationForm = table.Column<int>(nullable: false),
                    StudyTerm = table.Column<int>(nullable: false),
                    StartEducationDate = table.Column<DateTime>(nullable: false),
                    FinishEducationDate = table.Column<DateTime>(nullable: false),
                    ScienceAdviserId = table.Column<int>(nullable: true),
                    SpecialtyId = table.Column<int>(nullable: true),
                    DepartmentId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Undergraduates", x => x.UndergraduateId);
                    table.ForeignKey(
                        name: "FK_Undergraduates_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Undergraduates_Employees_ScienceAdviserId",
                        column: x => x.ScienceAdviserId,
                        principalTable: "Employees",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Undergraduates_Specialties_SpecialtyId",
                        column: x => x.SpecialtyId,
                        principalTable: "Specialties",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Undergraduates_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ExamInfo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Mark = table.Column<int>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    DisciplineId = table.Column<int>(nullable: true),
                    GraduateId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExamInfo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExamInfo_Disciplines_DisciplineId",
                        column: x => x.DisciplineId,
                        principalTable: "Disciplines",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ExamInfo_Graduates_GraduateId",
                        column: x => x.GraduateId,
                        principalTable: "Graduates",
                        principalColumn: "GraduateId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "GraduateJournals",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GraduateId = table.Column<int>(nullable: true),
                    UniversitySettingsId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GraduateJournals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GraduateJournals_Graduates_GraduateId",
                        column: x => x.GraduateId,
                        principalTable: "Graduates",
                        principalColumn: "GraduateId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GraduateJournals_UniversitySettings_UniversitySettingsId",
                        column: x => x.UniversitySettingsId,
                        principalTable: "UniversitySettings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UndergraduateJournal",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UndergraduateId = table.Column<int>(nullable: true),
                    UniversitySettingsId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UndergraduateJournal", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UndergraduateJournal_Undergraduates_UndergraduateId",
                        column: x => x.UndergraduateId,
                        principalTable: "Undergraduates",
                        principalColumn: "UndergraduateId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UndergraduateJournal_UniversitySettings_UniversitySettingsId",
                        column: x => x.UniversitySettingsId,
                        principalTable: "UniversitySettings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EducationPhases",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TripsInternships = table.Column<string>(nullable: true),
                    SubWorks = table.Column<string>(nullable: true),
                    Publications = table.Column<string>(nullable: true),
                    ScienceParticipations = table.Column<string>(nullable: true),
                    SubResearchResults = table.Column<string>(nullable: true),
                    JournalId = table.Column<int>(nullable: true),
                    Adviser = table.Column<string>(nullable: true),
                    AdviserApproveDate = table.Column<DateTime>(nullable: true),
                    IsAdviserApproved = table.Column<bool>(nullable: false),
                    SubmitDate = table.Column<DateTime>(nullable: true),
                    IsSubmitted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EducationPhases", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EducationPhases_GraduateJournals_JournalId",
                        column: x => x.JournalId,
                        principalTable: "GraduateJournals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RationalInfo",
                columns: table => new
                {
                    RationalInfoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudyPurpose = table.Column<string>(nullable: true),
                    StudyObject = table.Column<string>(nullable: true),
                    StudySubject = table.Column<string>(nullable: true),
                    Justification = table.Column<string>(nullable: true),
                    ThesisPublications = table.Column<string>(nullable: true),
                    ReseachParticipation = table.Column<string>(nullable: true),
                    DissertationTopic = table.Column<string>(nullable: true),
                    DepartmentHead = table.Column<string>(nullable: true),
                    DepartmentHeadApproveDate = table.Column<DateTime>(nullable: true),
                    IsDepartmentHeadApproved = table.Column<bool>(nullable: false),
                    TrainingHead = table.Column<string>(nullable: true),
                    TrainingHeadApproveDate = table.Column<DateTime>(nullable: true),
                    IsTrainingHeadApproved = table.Column<bool>(nullable: false),
                    Adviser = table.Column<string>(nullable: true),
                    AdviserApproveDate = table.Column<DateTime>(nullable: true),
                    IsAdviserApproved = table.Column<bool>(nullable: false),
                    ProtocolId = table.Column<int>(nullable: true),
                    GraduateJournalId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RationalInfo", x => x.RationalInfoId);
                    table.ForeignKey(
                        name: "FK_RationalInfo_GraduateJournals_GraduateJournalId",
                        column: x => x.GraduateJournalId,
                        principalTable: "GraduateJournals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RationalInfo_Protocol_ProtocolId",
                        column: x => x.ProtocolId,
                        principalTable: "Protocol",
                        principalColumn: "ProtocolId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ThesisPlans",
                columns: table => new
                {
                    ThesisPlanId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Info = table.Column<string>(nullable: true),
                    Adviser = table.Column<string>(nullable: true),
                    AdviserApproveDate = table.Column<DateTime>(nullable: true),
                    SubmitDate = table.Column<DateTime>(nullable: true),
                    IsSubmitted = table.Column<bool>(nullable: false),
                    IsApproved = table.Column<bool>(nullable: false),
                    GraduateJournalId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ThesisPlans", x => x.ThesisPlanId);
                    table.ForeignKey(
                        name: "FK_ThesisPlans_GraduateJournals_GraduateJournalId",
                        column: x => x.GraduateJournalId,
                        principalTable: "GraduateJournals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "WorkPlans",
                columns: table => new
                {
                    WorkPlanId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsSubmitted = table.Column<bool>(nullable: false),
                    SubmitDate = table.Column<DateTime>(nullable: true),
                    Adviser = table.Column<string>(nullable: true),
                    AdviserApproveDate = table.Column<DateTime>(nullable: true),
                    IsAdviserApproved = table.Column<bool>(nullable: false),
                    TrainingHead = table.Column<string>(nullable: true),
                    TrainingHeadApproveDate = table.Column<DateTime>(nullable: true),
                    IsTrainingHeadApproved = table.Column<bool>(nullable: false),
                    FinalCertification = table.Column<string>(nullable: true),
                    CouncilNumber = table.Column<string>(nullable: true),
                    GraduateJournalId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkPlans", x => x.WorkPlanId);
                    table.ForeignKey(
                        name: "FK_WorkPlans_GraduateJournals_GraduateJournalId",
                        column: x => x.GraduateJournalId,
                        principalTable: "GraduateJournals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PreparationInfo",
                columns: table => new
                {
                    PreparationInfoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Topic = table.Column<string>(nullable: true),
                    Relevance = table.Column<string>(nullable: true),
                    Objectives = table.Column<string>(nullable: true),
                    ResearchProcedure = table.Column<string>(nullable: true),
                    Additions = table.Column<string>(nullable: true),
                    PreparationAdviser = table.Column<string>(nullable: true),
                    ResearchAdviser = table.Column<string>(nullable: true),
                    PreparationSubmittedDate = table.Column<DateTime>(nullable: true),
                    PreparationApprovedDate = table.Column<DateTime>(nullable: true),
                    IsPreparationSubmitted = table.Column<bool>(nullable: false),
                    IsPreparationApproved = table.Column<bool>(nullable: false),
                    IsReseachSubmitted = table.Column<bool>(nullable: false),
                    IsResearchApproved = table.Column<bool>(nullable: false),
                    UndergraduateJournalId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PreparationInfo", x => x.PreparationInfoId);
                    table.ForeignKey(
                        name: "FK_PreparationInfo_UndergraduateJournal_UndergraduateJournalId",
                        column: x => x.UndergraduateJournalId,
                        principalTable: "UndergraduateJournal",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ReportResults",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(nullable: false),
                    Result = table.Column<string>(nullable: true),
                    DepartmentHead = table.Column<string>(nullable: true),
                    UndergraduateJournalId = table.Column<int>(nullable: true),
                    ProtocolId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReportResults", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReportResults_Protocol_ProtocolId",
                        column: x => x.ProtocolId,
                        principalTable: "Protocol",
                        principalColumn: "ProtocolId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ReportResults_UndergraduateJournal_UndergraduateJournalId",
                        column: x => x.UndergraduateJournalId,
                        principalTable: "UndergraduateJournal",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ThesisCertifications",
                columns: table => new
                {
                    ThesisCertificationId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsApproved = table.Column<bool>(nullable: false),
                    Mark = table.Column<int>(nullable: false),
                    ApproveDate = table.Column<DateTime>(nullable: false),
                    DepartmentHead = table.Column<string>(nullable: true),
                    UndergraduateJournalId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ThesisCertifications", x => x.ThesisCertificationId);
                    table.ForeignKey(
                        name: "FK_ThesisCertifications_UndergraduateJournal_UndergraduateJournalId",
                        column: x => x.UndergraduateJournalId,
                        principalTable: "UndergraduateJournal",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Attestations",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AttestationResult = table.Column<string>(nullable: true),
                    Adviser = table.Column<string>(nullable: true),
                    AdviserApproveDate = table.Column<DateTime>(nullable: true),
                    IsAdviserApproved = table.Column<bool>(nullable: false),
                    DepartmentHead = table.Column<string>(nullable: true),
                    DepartmentHeadApproveDate = table.Column<DateTime>(nullable: true),
                    IsDepartmentHeadApproved = table.Column<bool>(nullable: false),
                    TrainingtHead = table.Column<string>(nullable: true),
                    TrainingHeadApproveDate = table.Column<DateTime>(nullable: true),
                    IsTrainingHeadApproved = table.Column<bool>(nullable: false),
                    ProtocolId = table.Column<int>(nullable: true),
                    EducationPhaseId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Attestations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Attestations_EducationPhases_EducationPhaseId",
                        column: x => x.EducationPhaseId,
                        principalTable: "EducationPhases",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Attestations_Protocol_ProtocolId",
                        column: x => x.ProtocolId,
                        principalTable: "Protocol",
                        principalColumn: "ProtocolId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CalendarStages",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StageName = table.Column<string>(nullable: true),
                    StartDate = table.Column<DateTime>(nullable: false),
                    FinishDate = table.Column<DateTime>(nullable: false),
                    WaitResult = table.Column<string>(nullable: true),
                    OutcomeResult = table.Column<string>(nullable: true),
                    EducationPhaseId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CalendarStages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CalendarStages_EducationPhases_EducationPhaseId",
                        column: x => x.EducationPhaseId,
                        principalTable: "EducationPhases",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ScienceActivities",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StartDate = table.Column<DateTime>(nullable: false),
                    FinishDate = table.Column<DateTime>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    PlanResult = table.Column<string>(nullable: true),
                    EducationPhaseId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScienceActivities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ScienceActivities_EducationPhases_EducationPhaseId",
                        column: x => x.EducationPhaseId,
                        principalTable: "EducationPhases",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "WorkStages",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    JobInfo = table.Column<string>(nullable: true),
                    StartDate = table.Column<DateTime>(nullable: false),
                    FinishDate = table.Column<DateTime>(nullable: false),
                    SubmitDate = table.Column<DateTime>(nullable: false),
                    ApproveDate = table.Column<DateTime>(nullable: false),
                    IsSubmitted = table.Column<bool>(nullable: false),
                    IsApproved = table.Column<bool>(nullable: false),
                    Note = table.Column<string>(nullable: true),
                    WorkPlanId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkStages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WorkStages_WorkPlans_WorkPlanId",
                        column: x => x.WorkPlanId,
                        principalTable: "WorkPlans",
                        principalColumn: "WorkPlanId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ResearchWorks",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    JobType = table.Column<string>(nullable: true),
                    PresentationType = table.Column<string>(nullable: true),
                    StartDate = table.Column<DateTime>(nullable: true),
                    FinishDate = table.Column<DateTime>(nullable: true),
                    PreparationInfoId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResearchWorks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ResearchWorks_PreparationInfo_PreparationInfoId",
                        column: x => x.PreparationInfoId,
                        principalTable: "PreparationInfo",
                        principalColumn: "PreparationInfoId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Attestations_EducationPhaseId",
                table: "Attestations",
                column: "EducationPhaseId");

            migrationBuilder.CreateIndex(
                name: "IX_Attestations_ProtocolId",
                table: "Attestations",
                column: "ProtocolId");

            migrationBuilder.CreateIndex(
                name: "IX_CalendarStages_EducationPhaseId",
                table: "CalendarStages",
                column: "EducationPhaseId");

            migrationBuilder.CreateIndex(
                name: "IX_Departments_FacultyId",
                table: "Departments",
                column: "FacultyId");

            migrationBuilder.CreateIndex(
                name: "IX_EducationPhases_JournalId",
                table: "EducationPhases",
                column: "JournalId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_AcademicDegreeId",
                table: "Employees",
                column: "AcademicDegreeId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_AcademicRankId",
                table: "Employees",
                column: "AcademicRankId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_DepartmentId",
                table: "Employees",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_JobPositionId",
                table: "Employees",
                column: "JobPositionId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_UserId",
                table: "Employees",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ExamInfo_DisciplineId",
                table: "ExamInfo",
                column: "DisciplineId");

            migrationBuilder.CreateIndex(
                name: "IX_ExamInfo_GraduateId",
                table: "ExamInfo",
                column: "GraduateId");

            migrationBuilder.CreateIndex(
                name: "IX_GraduateJournals_GraduateId",
                table: "GraduateJournals",
                column: "GraduateId");

            migrationBuilder.CreateIndex(
                name: "IX_GraduateJournals_UniversitySettingsId",
                table: "GraduateJournals",
                column: "UniversitySettingsId");

            migrationBuilder.CreateIndex(
                name: "IX_Graduates_DepartmentId",
                table: "Graduates",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Graduates_ScienceAdviserId",
                table: "Graduates",
                column: "ScienceAdviserId");

            migrationBuilder.CreateIndex(
                name: "IX_Graduates_SpecialtyId",
                table: "Graduates",
                column: "SpecialtyId");

            migrationBuilder.CreateIndex(
                name: "IX_Graduates_UserId",
                table: "Graduates",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_LoginInfo_UserId",
                table: "LoginInfo",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_PreparationInfo_UndergraduateJournalId",
                table: "PreparationInfo",
                column: "UndergraduateJournalId",
                unique: true,
                filter: "[UndergraduateJournalId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_RationalInfo_GraduateJournalId",
                table: "RationalInfo",
                column: "GraduateJournalId",
                unique: true,
                filter: "[GraduateJournalId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_RationalInfo_ProtocolId",
                table: "RationalInfo",
                column: "ProtocolId");

            migrationBuilder.CreateIndex(
                name: "IX_ReportResults_ProtocolId",
                table: "ReportResults",
                column: "ProtocolId");

            migrationBuilder.CreateIndex(
                name: "IX_ReportResults_UndergraduateJournalId",
                table: "ReportResults",
                column: "UndergraduateJournalId");

            migrationBuilder.CreateIndex(
                name: "IX_ResearchWorks_PreparationInfoId",
                table: "ResearchWorks",
                column: "PreparationInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_ScienceActivities_EducationPhaseId",
                table: "ScienceActivities",
                column: "EducationPhaseId");

            migrationBuilder.CreateIndex(
                name: "IX_Specialties_DepartmentId",
                table: "Specialties",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_ThesisCertifications_UndergraduateJournalId",
                table: "ThesisCertifications",
                column: "UndergraduateJournalId",
                unique: true,
                filter: "[UndergraduateJournalId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_ThesisPlans_GraduateJournalId",
                table: "ThesisPlans",
                column: "GraduateJournalId",
                unique: true,
                filter: "[GraduateJournalId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_UndergraduateJournal_UndergraduateId",
                table: "UndergraduateJournal",
                column: "UndergraduateId");

            migrationBuilder.CreateIndex(
                name: "IX_UndergraduateJournal_UniversitySettingsId",
                table: "UndergraduateJournal",
                column: "UniversitySettingsId");

            migrationBuilder.CreateIndex(
                name: "IX_Undergraduates_DepartmentId",
                table: "Undergraduates",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Undergraduates_ScienceAdviserId",
                table: "Undergraduates",
                column: "ScienceAdviserId");

            migrationBuilder.CreateIndex(
                name: "IX_Undergraduates_SpecialtyId",
                table: "Undergraduates",
                column: "SpecialtyId");

            migrationBuilder.CreateIndex(
                name: "IX_Undergraduates_UserId",
                table: "Undergraduates",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_RoleId",
                table: "Users",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkPlans_GraduateJournalId",
                table: "WorkPlans",
                column: "GraduateJournalId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkStages_WorkPlanId",
                table: "WorkStages",
                column: "WorkPlanId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Attestations");

            migrationBuilder.DropTable(
                name: "CalendarStages");

            migrationBuilder.DropTable(
                name: "ExamInfo");

            migrationBuilder.DropTable(
                name: "LoginInfo");

            migrationBuilder.DropTable(
                name: "RationalInfo");

            migrationBuilder.DropTable(
                name: "ReportResults");

            migrationBuilder.DropTable(
                name: "ResearchWorks");

            migrationBuilder.DropTable(
                name: "ScienceActivities");

            migrationBuilder.DropTable(
                name: "ThesisCertifications");

            migrationBuilder.DropTable(
                name: "ThesisPlans");

            migrationBuilder.DropTable(
                name: "WorkStages");

            migrationBuilder.DropTable(
                name: "Disciplines");

            migrationBuilder.DropTable(
                name: "Protocol");

            migrationBuilder.DropTable(
                name: "PreparationInfo");

            migrationBuilder.DropTable(
                name: "EducationPhases");

            migrationBuilder.DropTable(
                name: "WorkPlans");

            migrationBuilder.DropTable(
                name: "UndergraduateJournal");

            migrationBuilder.DropTable(
                name: "GraduateJournals");

            migrationBuilder.DropTable(
                name: "Undergraduates");

            migrationBuilder.DropTable(
                name: "Graduates");

            migrationBuilder.DropTable(
                name: "UniversitySettings");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Specialties");

            migrationBuilder.DropTable(
                name: "AcademicDegrees");

            migrationBuilder.DropTable(
                name: "AcademicRanks");

            migrationBuilder.DropTable(
                name: "JobPositions");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Departments");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Faculties");
        }
    }
}
