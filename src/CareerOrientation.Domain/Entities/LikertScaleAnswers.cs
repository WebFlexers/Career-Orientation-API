namespace CareerOrientation.Domain.Entities;

public class LikertScaleAnswers
{
    public int LikertScaleAnswerId { get; set; }
    public string Option1 { get; set; }
    public string Option2 { get; set; }
    public string Option3 { get; set; }
    public string Option4 { get; set; }
    public string Option5 { get; set; }
    
    public HashSet<Question> Questions { get; set; }
}