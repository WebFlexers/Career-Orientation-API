namespace CareerOrientation.Application.Common.Validation;

public static class ValidationMessages
{
    public static string InvalidSemester => "Τα διαθέσιμα εξάμηνα είναι από 1 έως 8";
    public static string InvalidTrack => "Οι διαθέσιμες κατευθύνσεις είναι: ΤΛΕΣ, ΔΥΣ, ΠΣΥ";
    public static string MustSupplyTrackAboveSemester4 =>
        "Όταν το εξάμηνο είναι από 5 και πάνω πρέπει να οριστεί και η κατεύθυνση";
    public static string MustSupplyTrackAboveYear2 =>
        "Όταν το έτος είναι από 3 και πάνω πρέπει να οριστεί και η κατεύθυνση";
    public static string InvalidRevisionYear => "Τα έτη είναι από 1 έως 4";
    public static string InvalidLikertScaleAnswer => "Οι απαντήσεις τύπου Likert Scale πρέπει να είναι ένας ακέραιος " +
                                                     "από 1 έως 5";
}