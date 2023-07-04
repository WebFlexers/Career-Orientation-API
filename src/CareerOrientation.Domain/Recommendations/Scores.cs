namespace CareerOrientation.Domain.Recommendations;

public static class Scores
{
    public static int CorrectTrueFalseAnswer => 3;
    public static int WrongTrueFalseAnswer => 1;
    
    public static int CorrectMultipleChoiceAnswer => 4;
    public static int WrongMultipleChoiceAnswer => 1;
    
    public static int CorrectOnLikertScaleYesOrNo => 4;
    public static int WrongOnLikertScaleYesOrNo => 2;
    public static int NormalLikertScaleAnswer1 => 1;
    public static int NormalLikertScaleAnswer2 => 2;
    public static int NormalLikertScaleAnswer3 => 3;
    public static int NormalLikertScaleAnswer4 => 4;
    public static int NormalLikertScaleAnswer5 => 5;
}