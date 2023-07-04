using System.ComponentModel;
using System.Runtime.InteropServices;

using CareerOrientation.Application.Common.Abstractions.Recommendations;
using CareerOrientation.Application.Tests.Common;
using CareerOrientation.Domain.Common.Enums;
using CareerOrientation.Domain.Recommendations;

namespace CareerOrientation.Infrastructure.Recommendations;

public class PointsCalculationService : IPointsCalculationService
{
    public float CalculateMaxPoints(List<IQuestionAnswer> userAnswers)
    {
        var maxPoints = 0;
        
        foreach (var answer in CollectionsMarshal.AsSpan(userAnswers))    
        {
            switch (answer)
            {
                case CareerOrientation.Application.Tests.Common.TrueFalseAnswer trueFalseAnswer:
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
    
    public float CalculateUserPoints(List<IQuestionAnswer> userAnswers, List<IQuestionAnswer> correctAnswers)
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