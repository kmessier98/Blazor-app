namespace LibraryApp.Client.Models
{
    public class ServiceResult<T>
    {
        public bool IsSuccess { get; init; }
        public T? Data { get; init; }
        public List<string> Errors { get; init; } = new();

        public static ServiceResult<T> Success(T data) =>
            new() { IsSuccess = true, Data = data };

        public static ServiceResult<T> Failure(List<string> errors) =>
            new() { IsSuccess = false, Errors = errors };
    }
}
