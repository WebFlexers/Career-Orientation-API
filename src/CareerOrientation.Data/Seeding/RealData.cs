using CareerOrientation.Data.Entities.Specialties;
using CareerOrientation.Data.Entities.Tests;
using CareerOrientation.Data.Entities.TestsSpecialtiesRelations;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Reflection;

namespace CareerOrientation.Data.Seeding;

public class RealData
{
    public void Seed(ModelBuilder builder)
    {
        //if (System.Diagnostics.Debugger.IsAttached == false)
        //{
        //    System.Diagnostics.Debugger.Launch();
        //}

        // Deserialize the JSON into dynamic objects
        JsonDataDTO data = GetJsonContentFromAssembly("RealData.json");

        builder.Entity<Question>().HasData(data.Questions);
        builder.Entity<TrueFalseAnswer>().HasData(data.TrueFalseAnswers);
        builder.Entity<MultipleChoiceAnswer>().HasData(data.MultipleChoiceAnswers);
        builder.Entity<Track>().HasData(data.Tracks);
        builder.Entity<MastersDegree>().HasData(data.MastersDegrees);
        builder.Entity<Profession>().HasData(data.Professions);
        builder.Entity<QuestionMastersDegree>().HasData(data.QuestionMastersDegrees);
        builder.Entity<QuestionProfession>().HasData(data.QuestionProfessions);
        builder.Entity<QuestionTrack>().HasData(data.QuestionTracks);
        builder.Entity<GeneralTest>().HasData(data.GeneralTests);
        builder.Entity<UniversityTest>().HasData(data.UniversityTests);
    }

    private JsonDataDTO GetJsonContentFromAssembly(string jsonFileName)
    {
        var assembly = Assembly.GetExecutingAssembly();
        var resourceName = assembly.GetManifestResourceNames()
            .First(name => name.Contains(jsonFileName));

        using Stream stream = assembly.GetManifestResourceStream(resourceName)!;
        using StreamReader reader = new StreamReader(stream);

        return JsonConvert.DeserializeObject<JsonDataDTO>(reader.ReadToEnd())!;
    }
}
