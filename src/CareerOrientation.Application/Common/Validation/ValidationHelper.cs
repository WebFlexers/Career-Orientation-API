namespace CareerOrientation.Application.Common.Validation;

public static class ValidationHelper
{
    public static bool BeValidSemester(int? semester)
    {
        return semester is >= 1 and <= 8;
    }

    public static bool BeValidSemesterForTrack(int? semester)
    {
        return semester is >= 5 and <= 8;
    }

    public static bool BeValidTrack(string? track)
    {
        if (track is null) return false;

        track = track.ToUpper();

        return track is "ΤΛΕΣ" or "ΔΥΣ" or "ΠΣΥ";
    }

    public static bool BeValidRevisionYear(int? revisionYear)
    {
        return revisionYear is >= 1 and <= 4;
    }
}