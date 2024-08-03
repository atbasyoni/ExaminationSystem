using ExaminationSystem.Exceptions;

namespace ExaminationSystem.ViewModels
{
    public class ResultViewModel<T>
    {
        public bool IsSuccess { get; set; }
        public T Data { get; set; }
        public string Message { get; set; }

        public ErrorCode ErrorCode { get; set; }


        public static ResultViewModel<T> Sucess<T>(T data, string message = "")
        {
            return new ResultViewModel<T>
            {
                IsSuccess = true,
                Data = data,
                Message = message,
                ErrorCode = ErrorCode.None,
            };
        }

        public static ResultViewModel<T> Faliure(ErrorCode errorCode, string message)
        {
            return new ResultViewModel<T>
            {
                IsSuccess = false,
                Data = default,
                Message = message,
                ErrorCode = errorCode,
            };
        }
    }

    public class SuccessResultViewModel<T> : ResultViewModel<T>
    {
        public SuccessResultViewModel(T data, string message = "")
        {
            Data = data;
            IsSuccess = true;
            Message = message;
            ErrorCode = ErrorCode.None;
        }
    }
}
