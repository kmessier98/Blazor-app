using LibraryApp.Client.Services.Interfaces;
using Microsoft.AspNetCore.Components;
using static LibraryApp.Shared.DTOs.LivreDto;

namespace LibraryApp.Client.Pages
{
    public partial class LivreInfos
    {
        [Inject]
        public ILivreService LivreService { get; set; }
        [Parameter]
        public int Id { get; set; }

        private GetLivreInfosDto? _livre;
        private bool _isModalOpen = false;

        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();

            _livre = await LivreService.GetLivreInfos(Id);
        }

        private async Task Emprunter(int userId)
        {
            var success = await LivreService.EmprunterLivre(Id, userId);

            if (success)
            {
                _livre = await LivreService.GetLivreInfos(Id);
                _isModalOpen = false;
            } 
            else
            {
                // afficher un message d'erreur à l'utilisateur
            }
        }
    }
}
