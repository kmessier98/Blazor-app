using LibraryApp.Client.Services.Interfaces;
using LibraryApp.Shared.DTOs;
using Microsoft.AspNetCore.Components;
using static LibraryApp.Shared.DTOs.LivreDto;

namespace LibraryApp.Client.Pages
{
    public partial class LivreInfos
    {
        [Inject]
        public ILivreService LivreService { get; set; }
        [Inject]
        public IUtilisateurService UtilisateurService { get; set; }
        [Parameter]
        public int Id { get; set; }

        private GetLivreInfosDto? _livre;
        private List<UtilisateurDto> _utilisateurs = new List<UtilisateurDto>(); 
        private bool _isModalOpen = false;
        private int _selectedUserId = 1;
        private bool _isLoading = true;

        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();

            var livreTask =  LivreService.GetLivreInfos(Id);
            var utilisateursTask = UtilisateurService.GetAll();
            await Task.WhenAll(livreTask, utilisateursTask);
            _livre = livreTask.Result;
            _utilisateurs = utilisateursTask.Result;

            _isLoading = false;
        }

        private async Task Emprunter()
        {
            _isLoading = true;

            try
            {
                var success = await LivreService.EmprunterLivre(Id, _selectedUserId);

                if (success)
                {
                    _livre = await LivreService.GetLivreInfos(Id);
                    _isModalOpen = false;
                    _selectedUserId = 1;
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
