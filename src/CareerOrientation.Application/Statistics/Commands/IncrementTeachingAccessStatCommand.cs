namespace CareerOrientation.Application.Statistics.Commands;

public record IncrementTeachingAccessStatCommand(
    string UserId,
    int Semester);