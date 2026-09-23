using LibraryApp.Client.Services.Interfaces;
using LibraryApp.Shared.DTOs;
using Microsoft.AspNetCore.Components;

namespace LibraryApp.Client.Pages
{
    public partial class GestionEmprunts
    {
        [Inject]
        public IEmpruntService EmpruntService { get; set; }
        [Inject]
        public INotificationService NotificationService { get; set; }

        private List<EmpruntDto> _emprunts { get; set; } = new List<EmpruntDto>();
        private bool _isLoading = true;

        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();

            _emprunts = await EmpruntService.GetAllActiveAsync();
            _isLoading = false;
        }

        private async Task MarquerRetourne(int empruntId)
        {
            _isLoading = true;

            try
            {
                var success = await EmpruntService.RetournerExemplaire(empruntId);

                if (success)
                {
                    var empruntToRemove = _emprunts.Single(x => x.Id == empruntId);
                    _emprunts.Remove(empruntToRemove);

                    NotificationService.ShowSuccess("Le livre a été retourné avec succès");
                }
                else
                {
                    NotificationService.ShowError("Un problème est survenu");
                }
            }
            finally
            {
                _isLoading = false;
            }

        }
    }
}
