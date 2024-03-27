using System;

namespace WebApi
{
    public class Result<T>
    {
        public bool Success { get; private set; }
        public string ErrorMessage { get; private set; }
        public T Data { get; private set; }
        public TimeSpan ElapsedTime { get; private set; }

        private Result(bool success, string errorMessage, T data, TimeSpan elapsedTime)
        {
            Success = success;
            ErrorMessage = errorMessage;
            Data = data;
            ElapsedTime = elapsedTime;
        }

        public static Result<T> SuccessResult(T data, TimeSpan elapsedTime)
        {
            return new Result<T>(true, null, data, elapsedTime);
        }

        public static Result<T> FailureResult(string errorMessage, TimeSpan elapsedTime)
        {
            return new Result<T>(false, errorMessage, default, elapsedTime);
        }
    }
}
