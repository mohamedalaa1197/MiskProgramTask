using Microsoft.EntityFrameworkCore;

namespace MiskProgramTask.DomainLayer;

public class ApplicationContext : DbContext
{
    public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
    {
    }

    public DbSet<Program> Programs { get; set; }
    public DbSet<Application> Applications { get; set; }
    public DbSet<WorkFlow> WorkFlows { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Program>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Id).ValueGeneratedOnAdd();

            entity.Property(e => e.Title).IsRequired();
            entity.Property(e => e.Description).IsRequired();
            entity.Property(e => e.Location).IsRequired();

            entity.OwnsMany(e => e.Skills, skills =>
            {
                skills.Property<Guid>("Id").IsRequired();
                skills.HasKey("Id");
                skills.WithOwner().HasForeignKey("ProgramId");
                skills.Property(e => e.Title).IsRequired();
            });
        });

        modelBuilder.Entity<Skill>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.Title).IsRequired();
        });

        modelBuilder.Entity<Application>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.ProgramId).IsRequired();
            entity.OwnsOne(e => e.PersonalInformation, personalInfo =>
            {
                personalInfo.Property(e => e.FirstName);
                personalInfo.Property(e => e.LastName);
                personalInfo.Property(e => e.Phone);
                personalInfo.Property(e => e.InternalPhone);
                personalInfo.Property(e => e.ShowPhone);
                personalInfo.Property(e => e.Nationality);
                personalInfo.Property(e => e.InternalNationality);
                personalInfo.Property(e => e.ShowNationality);
                personalInfo.Property(e => e.CurrentResidence);
                personalInfo.Property(e => e.InternalCurrentResidence);
                personalInfo.Property(e => e.ShowCurrentResidence);
                personalInfo.Property(e => e.IdNumber);
                personalInfo.Property(e => e.InternalIdNumber);
                personalInfo.Property(e => e.ShowIdNumber);
                personalInfo.Property(e => e.DateOfBirth);
                personalInfo.Property(e => e.InternalDateOfBirth);
                personalInfo.Property(e => e.ShowDateOfBirth);
                personalInfo.Property(e => e.Gender);
                personalInfo.Property(e => e.InternalGender);
                personalInfo.Property(e => e.ShowGender);
            });
            entity.OwnsOne(e => e.Profile, profile =>
            {
                profile.Property(e => e.ExperienceMandatory);
                profile.Property(e => e.ShowExperience);
                profile.Property(e => e.Resume);
                profile.Property(e => e.ResumeMandatory);
                profile.Property(e => e.ShowResume);
            });
            entity.OwnsOne(e => e.Profile.Education, education =>
            {
                education.Property(e => e.EducationMandatory);
                education.Property(e => e.ShowEducation);
            });
            entity.OwnsOne(e => e.Profile.Experience, experience =>
            {
                experience.Property(e => e.ExperienceMandatory);
                experience.Property(e => e.ShowExperience);
            });
            entity.OwnsOne(e => e.AdditionalQuestion, additionalQuestion =>
            {
                additionalQuestion.OwnsMany(e => e.Questions, questions =>
                {
                    questions.Property<Guid>("Id").IsRequired();
                    questions.HasKey("Id");
                });
            });
            entity.OwnsOne(e => e.Profile, profile =>
            {
                profile.OwnsMany(e => e.Questions, questions =>
                {
                    questions.Property<Guid>("Id").IsRequired();
                    questions.HasKey("Id");
                });
            });
        });

        modelBuilder.Entity<WorkFlow>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Id).ValueGeneratedOnAdd();

            entity.Property(e => e.ProgramId).IsRequired();
            entity.Property(e => e.StageName).IsRequired();
            entity.Property(e => e.Type).IsRequired();

            entity.OwnsOne(e => e.VideoStage, videoStage =>
            {
                videoStage.Property(vs => vs.VideoQuestion);
                videoStage.Property(vs => vs.Description);
                videoStage.Property(vs => vs.MaxDuration);
                videoStage.Property(vs => vs.DurationType);
                videoStage.Property(vs => vs.DeadLineInDays);
            });

            entity.Property(e => e.Stages)
                .HasConversion(
                    v => string.Join(',', v),
                    v => v.Split(',', StringSplitOptions.RemoveEmptyEntries).ToList()
                );
        });

        base.OnModelCreating(modelBuilder);
    }
}