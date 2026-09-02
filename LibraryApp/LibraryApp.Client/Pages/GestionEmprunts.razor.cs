using LibraryApp.Client.Services.Interfaces;
using LibraryApp.Shared.DTOs;
using Microsoft.AspNetCore.Components;

namespace LibraryApp.Client.Pages
{
    public partial class GestionEmprunts
    {
        [Inject]
        public IEmpruntService EmpruntService { get; set; }

        private List<EmpruntDto> _emprunts { get; set; } = new List<EmpruntDto>();
        private bool _isLoading = true;

        protected override async Task OnInitializedAsync()
        {
             await base.OnInitializedAsync();

            _emprunts = await EmpruntService.GetAllActiveAsync();
            _isLoading = false;
        }

        private async Task MarquerRetourne(int empruntId, int userId)
        {
            _isLoading = true;

            try
            {
                var succes = await EmpruntService.RetournerLivre(empruntId, userId);

                if (succes)
                {
                    var empruntToRemove = _emprunts.Single(x => x.Id == empruntId && x.UserId == userId);
                    _emprunts.Remove(empruntToRemove);
                }
                else
                {
                    // afficher un message d'erreur à l'utilisateur
                }
            }
            finally
            {
                _isLoading = false;
            }
           
        }
    }
}
