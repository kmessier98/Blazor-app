namespace LibraryApp.Client.Services.Interfaces
{
    public interface INotificationService
    {
        event Action<string>? OnError;
        event Action<string>? OnSuccess;
        void ShowError(string message);
        void ShowSuccess(string message);
    }
}
