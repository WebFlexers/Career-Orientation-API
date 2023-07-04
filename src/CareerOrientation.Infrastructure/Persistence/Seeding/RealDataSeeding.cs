using CareerOrientation.Domain.Common;
using CareerOrientation.Domain.Entities;
using CareerOrientation.Domain.JunctionEntities;
using CareerOrientation.Infrastructure.Persistence.Seeding.JsonDTOs;

using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

using static CareerOrientation.Infrastructure.Persistence.Seeding.JsonParser;

namespace CareerOrientation.Infrastructure.Persistence.Seeding;

public class RealDataSeeding : IDataSeeding
{
    private readonly ILookupNormalizer _lookupNormalizer;

    public RealDataSeeding(ILookupNormalizer lookupNormalizer)
    {
        _lookupNormalizer = lookupNormalizer;
    }
    
    public async Task Seed(ModelBuilder builder)
    {
        /*if (Debugger.IsAttached == false)
        {
            Debugger.Launch();
        }*/

        builder.Entity<IdentityRole>().HasData(AppRoles.GetAllRoles()
            .Select(role => new IdentityRole()
            {
                Id = Guid.NewGuid().ToString(),
                Name = role,
                NormalizedName = _lookupNormalizer.NormalizeName(role),
                ConcurrencyStamp = Guid.NewGuid().ToString()
            }));
        
        var coursesDTO = await GetJsonContentFromAssemblyAsync<CourseDTO>("courses.json");
        var courseSkillsDTO = await GetJsonContentFromAssemblyAsync<CourseSkillDTO>("courseSkills.json");
        var generalTestsDTO = await GetJsonContentFromAssemblyAsync<GeneralTestDTO>("generalTests.json");
        var likertScaleAnswersDTO = await GetJsonContentFromAssemblyAsync<LikertScaleAnswerDTO>("likertScaleAnswers.json");
        var mastersDegreesDTO = await GetJsonContentFromAssemblyAsync<MastersDegreesDTO>("mastersDegrees.json");
        var multipleChoiceAnswersDTO = await GetJsonContentFromAssemblyAsync<MultipleChoiceAnswerDTO>("multipleChoiceAnswers.json");
        var professionsDTO = await GetJsonContentFromAssemblyAsync<ProfessionDTO>("professions.json");
        var questionLikertScaleAnswersDTO = await GetJsonContentFromAssemblyAsync<QuestionLikertScaleAnswerDTO>("questionLikertScaleAnswers.json");
        var questionMastersDegreesDTO = await GetJsonContentFromAssemblyAsync<QuestionMastersDegreesDTO>("questionMastersDegrees.json");
        var questionProfessionsDTO = await GetJsonContentFromAssemblyAsync<QuestionProfessionDTO>("questionProfessions.json");
        var questionsDTO = await GetJsonContentFromAssemblyAsync<QuestionsDTO>("questions.json");
        var questionTracksDTO = await GetJsonContentFromAssemblyAsync<QuestionTrackDTO>("questionTracks.json");
        var skillsDTO = await GetJsonContentFromAssemblyAsync<SkillDTO>("skills.json");
        var trackMastersDegreesDTO = await GetJsonContentFromAssemblyAsync<TrackMastersDegreeDTO>("trackMastersDegrees.json");
        var trackProfessionsDTO = await GetJsonContentFromAssemblyAsync<TrackProfessionDTO>("trackProfessions.json");
        var tracksDTO = await GetJsonContentFromAssemblyAsync<TrackDTO>("tracks.json");
        var trueFalseAnswersDTO = await GetJsonContentFromAssemblyAsync<TrueFalseAnswerDTO>("trueFalseAnswers.json");
        var universityTestsDTO = await GetJsonContentFromAssemblyAsync<UniversityTestDTO>("universityTests.json");
        

        builder.Entity<Course>().HasData(coursesDTO!.Courses);
        builder.Entity<Skill>().HasData(skillsDTO!.Skills);
        builder.Entity<CourseSkill>().HasData(courseSkillsDTO!.CourseSkills);
        
        builder.Entity<GeneralTest>().HasData(generalTestsDTO!.GeneralTests);
        builder.Entity<UniversityTest>().HasData(universityTestsDTO!.UniversityTests);
        
        builder.Entity<Question>().HasData(questionsDTO!.Questions);
        
        builder.Entity<LikertScaleAnswers>().HasData(likertScaleAnswersDTO!.LikertScaleAnswers);
        builder.Entity<MultipleChoiceAnswer>().HasData(multipleChoiceAnswersDTO!.MultipleChoiceAnswers);
        builder.Entity<TrueFalseAnswer>().HasData(trueFalseAnswersDTO!.TrueFalseAnswers);

        builder.Entity<QuestionLikertScaleAnswers>().HasData(questionLikertScaleAnswersDTO!.QuestionLikertScaleAnswers);
        
        builder.Entity<Track>().HasData(tracksDTO!.Tracks);
        builder.Entity<MastersDegree>().HasData(mastersDegreesDTO!.MastersDegrees);
        builder.Entity<Profession>().HasData(professionsDTO!.Professions);
        
        builder.Entity<TrackMastersDegree>().HasData(trackMastersDegreesDTO!.TrackMastersDegrees);
        builder.Entity<TrackProfession>().HasData(trackProfessionsDTO!.TrackProfessions);
        
        builder.Entity<QuestionTrack>().HasData(questionTracksDTO!.QuestionTracks);
        builder.Entity<QuestionMastersDegree>().HasData(questionMastersDegreesDTO!.QuestionMastersDegrees);
        builder.Entity<QuestionProfession>().HasData(questionProfessionsDTO!.QuestionProfessions);
    }
}
