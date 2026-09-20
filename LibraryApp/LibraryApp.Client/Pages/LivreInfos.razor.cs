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
        public IMembreService UtilisateurService { get; set; }
        [Inject]
        public INotificationService NotificationService { get; set; }
        [Parameter]
        public int Id { get; set; }

        private GetLivreInfosDto? _livre;
        private List<MembreDto> _membres = new List<MembreDto>();
        private bool _isModalOpen = false;
        private int _selectedMembreId = 1;
        private int _modalSelectedMembreId = 1;
        private bool _isLoading = true;
        private bool _selectedUserCanEmprunte = true;
        private ExemplaireDto? _selectedUserExemplaireEmprunte = null;

        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();

            var livreTask = LivreService.GetLivreInfos(Id);
            var utilisateursTask = UtilisateurService.GetAll();
            await Task.WhenAll(livreTask, utilisateursTask);
            _livre = livreTask.Result;
            _membres = utilisateursTask.Result;

            VerifySelectedUserCanEmprunte();

            _isLoading = false;
        }

        private void OnUserSelectedChanged(ChangeEventArgs e)
        {
            if (_livre == null) return;

            if (int.TryParse(e.Value?.ToString(), out int membreId))
            {
                _selectedMembreId = membreId;
            }
            else
            {
                _selectedMembreId = 0;
            }

            VerifySelectedUserCanEmprunte();

        }

        private void VerifySelectedUserCanEmprunte()
        {
            bool userHasEmpruntEnCours = _livre.Exemplaires.Any(x => x.Emprunts.Any(x => x.MembreId == _selectedMembreId && x.DateRetour == null));

            if (userHasEmpruntEnCours)
            {
                _selectedUserCanEmprunte = false;
                _selectedUserExemplaireEmprunte = _livre.Exemplaires.SingleOrDefault(x => x.Emprunts.Any(x => x.MembreId == _selectedMembreId && x.DateRetour == null));
            }
            else
            {
                _selectedUserCanEmprunte = true;
                _selectedUserExemplaireEmprunte = null;
            }
        }

        private async Task Emprunter()
        {
            _isLoading = true;

            try
            {
                var success = await LivreService.EmprunterLivre(Id, _modalSelectedMembreId);

                if (success)
                {
                    _livre = await LivreService.GetLivreInfos(Id);
                    _isModalOpen = false;
                    _modalSelectedMembreId = 1;

                    NotificationService.ShowSuccess("Livre emprunté avec succès");
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
