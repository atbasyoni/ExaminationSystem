namespace ExaminationSystem.Exceptions
{
    public enum ErrorCode
    {
        None = 0,
        UnKnown = 1,

        ExamNotFound = 1000,
        NotValidExamDate,

        NotValidInstructorBirthDate = 2000,
    }
}
