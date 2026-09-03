using LibraryApp.Client.Services.Interfaces;
using Microsoft.AspNetCore.Components;

namespace LibraryApp.Client.Components.Shared
{
    public partial class NotificationBanner
    {
        [Inject]
        public INotificationService NotificationService { get; set; }

        private string? errorMessage;
        private string? successMessage;
        private CancellationTokenSource? cts;

        protected override void OnInitialized()
        {
            NotificationService.OnError += HandleError;
            NotificationService.OnSuccess += HandleSuccess;
        }

        private void HandleError(string message)
        {
            errorMessage = message;
            successMessage = null;
            InvokeAsync(StateHasChanged);
            StartAutoDismiss();
        }

        private void HandleSuccess(string message)
        {
            successMessage = message;
            errorMessage = null;
            InvokeAsync(StateHasChanged);
            StartAutoDismiss();
        }

        private void StartAutoDismiss()
        {
            // Annule le timer précédent s'il y en a un
            cts?.Cancel();
            cts = new CancellationTokenSource();
            var token = cts.Token;

            _ = DismissAfterDelay(token);
        }

        private async Task DismissAfterDelay(CancellationToken token)
        {
            try
            {
                await Task.Delay(5000, token); // 5 secondes, ajuste selon ton goût

                if (!token.IsCancellationRequested)
                {
                    errorMessage = null;
                    successMessage = null;
                    await InvokeAsync(StateHasChanged);
                }
            }
            catch (TaskCanceledException)
            {
                // Normal si un nouveau message arrive avant le délai
            }
        }

        public void Dispose()
        {
            NotificationService.OnError -= HandleError;
            NotificationService.OnSuccess -= HandleSuccess;
        }
    }
}
