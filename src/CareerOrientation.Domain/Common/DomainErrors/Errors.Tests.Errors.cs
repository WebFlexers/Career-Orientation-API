using ErrorOr;

namespace CareerOrientation.Domain.Common.DomainErrors;

public static partial class Errors
{
    public static class Tests
    {
        public static Error UniversityTestIdNotFound => Error.NotFound(
            code: nameof(UniversityTestIdNotFound),
            description: "Δεν βρέθηκε τεστ με το δεδομένο UniversityTestId");

        public static Error StudentAlreadyTookTest => Error.Conflict(
            code: nameof(StudentAlreadyTookTest),
            description: "Ο φοιτητής που δόθηκε έχει ήδη συμπληρώσει το δεδομένο τεστ");
        public static Error ProspectiveStudentAlreadyTookTest => Error.Conflict(
            code: nameof(ProspectiveStudentAlreadyTookTest),
            description: "Ο χρήστης που δόθηκε έχει ήδη συμπληρώσει το δεδομένο τεστ");
        public static Error NoQuestionsFound => Error.NotFound(
            code: nameof(NoQuestionsFound),
            description: "Δεν βρέθηκαν ερωτήσεις");

        public static Error NotAllQuestionsWereAnswered => Error.Validation(
            code: nameof(NotAllQuestionsWereAnswered),
            description: "Δεν απαντήθηκαν όλες οι ερωτήσεις");
        
        public static Error QuestionNotPartOfTest(int questionId, int testId)
        {
            return Error.Validation(
                code: nameof(QuestionNotPartOfTest),
                description: $"H ερώτηση με id {questionId} δεν υπάρχει στο τεστ με id {testId}");
        }

        public static Error AnswerTypeNotCompatible(int questionId, string answerType, string questionType)
        {
            return Error.Validation(
                code: nameof(AnswerTypeNotCompatible),
                description: $"Η απάντηση που δόθηκε για την ερώτηση με id {questionId} είναι τύπου {answerType}, " +
                             $"ενώ η ερώτηση είναι τύπου {questionType}");
        }

        public static Error MultipleChoiceAnswerDoesntMatch(int questionId)
        {
            return Error.Validation(
                code: nameof(MultipleChoiceAnswerDoesntMatch),
                description: $"Το multipleChoiceAnswerId που δόθηκε για την ερώτηση με id {questionId} δεν αντιστοιχεί " +
                             $"σε αυτή την ερώτηση");
        }
    }
}