using LibraryApp.Client.Services.Interfaces;

namespace LibraryApp.Client.Services
{
    public class NotificationService : INotificationService
    {
        public event Action<string>? OnError;
        public event Action<string>? OnSuccess;

        public void ShowError(string message) => OnError?.Invoke(message);
        public void ShowSuccess(string message) => OnSuccess?.Invoke(message);
    }
}
