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

        private async Task MarquerRetourne(int empruntId, int membreId)
        {
            _isLoading = true;

            try
            {
                var succes = await EmpruntService.RetournerLivre(empruntId, membreId);

                if (succes)
                {
                    var empruntToRemove = _emprunts.Single(x => x.Id == empruntId && x.MembreId == membreId);
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
