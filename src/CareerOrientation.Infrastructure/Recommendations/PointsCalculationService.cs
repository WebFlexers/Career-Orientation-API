using System.Runtime.InteropServices;

using CareerOrientation.Application.Common.Abstractions.Recommendations;
using CareerOrientation.Application.Recommendations.Queries.StudentRecommendation.Common;
using CareerOrientation.Application.Tests.Common;
using CareerOrientation.Domain.Common.Enums;
using CareerOrientation.Domain.Entities;
using CareerOrientation.Domain.Recommendations;

using MultipleChoiceAnswer = CareerOrientation.Application.Tests.Common.MultipleChoiceAnswer;
using TrueFalseAnswer = CareerOrientation.Application.Tests.Common.TrueFalseAnswer;

namespace CareerOrientation.Infrastructure.Recommendations;

public class PointsCalculationService : IPointsCalculationService
{
    public float CalculateGeneralTestMaxPoints(List<IQuestionAnswer> userAnswers)
    {
        var maxPoints = 0;
        
        foreach (var answer in CollectionsMarshal.AsSpan(userAnswers))    
        {
            switch (answer)
            {
                case TrueFalseAnswer trueFalseAnswer:
                    maxPoints += Scores.CorrectTrueFalseAnswer;
                    break;
                case MultipleChoiceAnswer multipleChoiceAnswer:
                    maxPoints += Scores.CorrectMultipleChoiceAnswer;
                    break;
                case LikertScaleAnswer likertScaleAnswer:
                    if (likertScaleAnswer.IsYesOrNoAnswer)
                    {
                        maxPoints += Scores.CorrectOnLikertScaleYesOrNo;
                    }
                    else
                    {
                        maxPoints += Scores.NormalLikertScaleAnswer5;
                    }
                    break;
            }
        }

        return maxPoints;
    }
    
    public float CalculateProspectiveStudentPoints(List<IQuestionAnswer> userAnswers, List<IQuestionAnswer> correctAnswers)
    {
        var userPoints = 0;

        foreach (IQuestionAnswer userAnswer in CollectionsMarshal.AsSpan(userAnswers))
        {
            switch (userAnswer)
            {
                case TrueFalseAnswer userTrueFalseAnswer:
                    var correctTrueFalseAnswer = (TrueFalseAnswer)correctAnswers.First(correctAnswer =>
                        correctAnswer.QuestionId == userTrueFalseAnswer.QuestionId);
                    
                    if (correctTrueFalseAnswer.Value == userTrueFalseAnswer.Value)
                    {
                        userPoints += Scores.CorrectTrueFalseAnswer;
                    }
                    else
                    {
                        userPoints += Scores.WrongTrueFalseAnswer;
                    }
                    
                    break;
                
                case MultipleChoiceAnswer userMultipleChoiceAnswer:
                    var correctMultipleChoiceAnswerId = ((MultipleChoiceAnswer)correctAnswers.First(correctAnswer =>
                        correctAnswer.QuestionId == userMultipleChoiceAnswer.QuestionId)).MultipleChoiceAnswerId;

                    if (correctMultipleChoiceAnswerId == userMultipleChoiceAnswer.MultipleChoiceAnswerId)
                    {
                        userPoints += Scores.CorrectMultipleChoiceAnswer;
                    }
                    else
                    {
                        userPoints += Scores.WrongMultipleChoiceAnswer;
                    }
                    
                    break;
                
                case LikertScaleAnswer userLikertScaleAnswer:
                    if (userLikertScaleAnswer.IsYesOrNoAnswer)
                    {
                        userPoints += userLikertScaleAnswer.Value == 1
                            ? Scores.CorrectOnLikertScaleYesOrNo
                            : Scores.WrongOnLikertScaleYesOrNo;
                    }
                    else
                    {
                        switch (userLikertScaleAnswer.Value)
                        {
                            case 1:
                                userPoints += Scores.NormalLikertScaleAnswer1;
                                break;
                            case 2:
                                userPoints += Scores.NormalLikertScaleAnswer2;
                                break;
                            case 3:
                                userPoints += Scores.NormalLikertScaleAnswer3;
                                break;
                            case 4:
                                userPoints += Scores.NormalLikertScaleAnswer4;
                                break;
                            case 5:
                                userPoints += Scores.NormalLikertScaleAnswer5;
                                break;
                        }
                    }
                    
                    break;
            }
        }

        return userPoints;
    }

    public List<RecommendationResult> CreateStudentRecommendations(List<IQuestionAnswer> userAnswers, 
        List<IQuestionAnswer> correctAnswers, List<QuestionRecommendationsLinks> questionRecommendationsLinks,
        int semester)
    {
        // First we create dictionaries to keep the total user points for tracks, masters degrees and professions
        Dictionary<Track, float> tracksPoints = new();
        Dictionary<MastersDegree, float> mastersDegreesPoints = new();
        Dictionary<Profession, float> professionsPoints = new();

        // And then another dictionary that will keep the max amount of points
        // for tracks, masters degrees and professions
        Dictionary<Track, float> tracksMaxPoints = new();
        Dictionary<MastersDegree, float> mastersDegreesMaxPoints = new();
        Dictionary<Profession, float> professionsMaxPoints = new();

        // Foreach question we determine whether the answer is correct and we add the appropriate score to each of the
        // linked tracks, masters degrees and professions
        foreach (IQuestionAnswer userAnswer in userAnswers)
        {
            switch (userAnswer)
            {
                case TrueFalseAnswer userTrueFalseAnswer:
                    var correctTrueFalseAnswer = (TrueFalseAnswer)correctAnswers.First(correctAnswer =>
                        correctAnswer.QuestionId == userTrueFalseAnswer.QuestionId);

                    int scoreToAdd1 = correctTrueFalseAnswer.Value == userTrueFalseAnswer.Value
                        ? Scores.CorrectTrueFalseAnswer
                        : Scores.WrongTrueFalseAnswer;
                    
                    // At the same time we are incrementing the max points and the user points to avoid using 2 loops
                    IncrementScore(tracksMaxPoints, mastersDegreesMaxPoints, professionsMaxPoints,
                        Scores.CorrectTrueFalseAnswer, userAnswer.QuestionId, questionRecommendationsLinks, semester);
                    IncrementScore(tracksPoints, mastersDegreesPoints, professionsPoints,
                        scoreToAdd1, userAnswer.QuestionId, questionRecommendationsLinks, semester);

                    break;
                case MultipleChoiceAnswer userMultipleChoiceAnswer:
                    var correctMultipleChoiceAnswer = (MultipleChoiceAnswer)correctAnswers.First(correctAnswer =>
                        correctAnswer.QuestionId == userMultipleChoiceAnswer.QuestionId);

                    int scoreToAdd2 = correctMultipleChoiceAnswer.MultipleChoiceAnswerId ==
                                      userMultipleChoiceAnswer.MultipleChoiceAnswerId
                        ? Scores.CorrectMultipleChoiceAnswer
                        : Scores.WrongMultipleChoiceAnswer;
                    
                    IncrementScore(tracksMaxPoints, mastersDegreesMaxPoints, professionsMaxPoints,
                        Scores.CorrectMultipleChoiceAnswer, userAnswer.QuestionId, questionRecommendationsLinks,
                        semester);
                    IncrementScore(tracksPoints, mastersDegreesPoints, professionsPoints,
                        scoreToAdd2, userAnswer.QuestionId, questionRecommendationsLinks, semester);

                    break;
                case LikertScaleAnswer userLikertScaleAnswer:
                    int scoreToAdd3 = 0;
                    
                    if (userLikertScaleAnswer.IsYesOrNoAnswer)
                    {
                        scoreToAdd3 = userLikertScaleAnswer.Value == 1
                            ? Scores.CorrectOnLikertScaleYesOrNo
                            : Scores.WrongOnLikertScaleYesOrNo;
                    }
                    else
                    {
                        scoreToAdd3 = userLikertScaleAnswer.Value switch
                        {
                            1 => Scores.NormalLikertScaleAnswer1,
                            2 => Scores.NormalLikertScaleAnswer2,
                            3 => Scores.NormalLikertScaleAnswer3,
                            4 => Scores.NormalLikertScaleAnswer4,
                            5 => Scores.NormalLikertScaleAnswer5,
                            _ => scoreToAdd3
                        };
                    }
                    
                    IncrementScore(tracksMaxPoints, mastersDegreesMaxPoints, professionsMaxPoints,
                        Scores.NormalLikertScaleAnswer5, userAnswer.QuestionId, questionRecommendationsLinks, semester);
                    IncrementScore(tracksPoints, mastersDegreesPoints, professionsPoints,
                        scoreToAdd3, userAnswer.QuestionId, questionRecommendationsLinks, semester);
                    
                    break;
                default:
                    throw new ArgumentException("The user answers type was wrong", nameof(userAnswer));
            }
        }

        var tracksRecommendationResults = CalculateRecommendations(tracksPoints, 
            mastersDegreesPoints, professionsPoints, tracksMaxPoints, mastersDegreesMaxPoints, professionsMaxPoints,
            semester);

        return tracksRecommendationResults;
    }

    private void IncrementScore(IDictionary<Track, float> tracksPoints, IDictionary<MastersDegree, float> mastersDegreesPoints,
        IDictionary<Profession, float> professionsPoints, float scoreToAdd, int questionId,
        IEnumerable<QuestionRecommendationsLinks> questionRecommendationsLinks, int semester)
    {
        // We get the question recommendation links
        var questionRecommendationsLink = questionRecommendationsLinks
            .First(x => x.QuestionId == questionId);

        // We should only recommend tracks to students below the 5th semester
        if (semester <= 4)
        {
            questionRecommendationsLink.Tracks.ForEach(track =>
            {
                if (tracksPoints.ContainsKey(track))
                {
                    tracksPoints[track] += scoreToAdd;
                }
                else
                {
                    tracksPoints.Add(track, scoreToAdd);
                }
            });
        }

        questionRecommendationsLink.MastersDegrees.ForEach(mastersDegree =>
        {
            if (mastersDegreesPoints.ContainsKey(mastersDegree))
            {
                mastersDegreesPoints[mastersDegree] += scoreToAdd;
            }
            else
            {
                mastersDegreesPoints.Add(mastersDegree, scoreToAdd);
            }
        });
        
        questionRecommendationsLink.Professions.ForEach(profession =>
        {
            if (professionsPoints.ContainsKey(profession))
            {
                professionsPoints[profession] += scoreToAdd;
            }
            else
            {
                professionsPoints.Add(profession, scoreToAdd);
            }
        });
    }

    private List<RecommendationResult> CalculateRecommendations(
        IDictionary<Track, float> tracksPoints, IDictionary<MastersDegree, float> mastersDegreesPoints,
        IDictionary<Profession, float> professionsPoints,
        IDictionary<Track, float> tracksMaxPoints, IDictionary<MastersDegree, float> mastersDegreesMaxPoints,
        IDictionary<Profession, float> professionsMaxPoints, int semester)
    {
        List<RecommendationResult> recommendationResults = new();

        // We should only recommend tracks to students below the 5th semester
        if (semester <= 4)
        {
            foreach (var trackPoints in tracksPoints)
            {
                var trackPercentageScore = (int)Math.Round((trackPoints.Value / tracksMaxPoints[trackPoints.Key]) * 100);
            
                recommendationResults.Add(new RecommendationResult(
                    RecommendationType.Track,
                    GetRecommendationLevel(trackPercentageScore),
                    trackPoints.Key.Name,
                    trackPercentageScore));
            }
        }

        foreach (var mastersDegreePoints in mastersDegreesPoints)
        {
            var mastersDegreePercentageScore = 
                (int)Math.Round((mastersDegreePoints.Value / mastersDegreesMaxPoints[mastersDegreePoints.Key]) * 100);
            
            recommendationResults.Add(new RecommendationResult(
                RecommendationType.MastersDegree,
                GetRecommendationLevel(mastersDegreePercentageScore),
                mastersDegreePoints.Key.Name,
                mastersDegreePercentageScore));
        }
        
        foreach (var professionPoints in professionsPoints)
        {
            var professionPercentageScore = 
                (int)Math.Round((professionPoints.Value / professionsMaxPoints[professionPoints.Key]) * 100);
            
            recommendationResults.Add(new RecommendationResult(
                RecommendationType.Profession,
                GetRecommendationLevel(professionPercentageScore),
                professionPoints.Key.Name,
                professionPercentageScore));
        }

        return recommendationResults;
    }
    
    public RecommendationLevel GetRecommendationLevel(int userPointsPercentage)
    {
        switch (userPointsPercentage)
        {
            case <= 25:
                return RecommendationLevel.VeryPoorFit;
            case <= 40:
                return RecommendationLevel.PoorFit;
            case <= 60:
                return RecommendationLevel.ModerateFit;
            case <= 80:
                return RecommendationLevel.GoodFit;
            case <= 100:
                return RecommendationLevel.ExcellentFit;
            default:
                throw new ArgumentOutOfRangeException(nameof(userPointsPercentage), 
                    "The user points percentage was not an integer between 0 and 100");
        }
    }
}