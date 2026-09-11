using LibraryApp.Client.Services.Interfaces;
using LibraryApp.Shared.DTOs;
using Microsoft.AspNetCore.Components;

namespace LibraryApp.Client.Pages
{
    public partial class Membres
    {
        [Inject]
        public IMembreService MembreService { get; set; }
        [Inject]
        public INotificationService NotificationService { get; set; }

        private bool _isLoading = true;
        private List<MembreDto> _membres = new List<MembreDto>();
        private string _searchQuery = string.Empty;
        private bool _isModalOpen = false;
        private bool _isDeleteConfirmationOpen = false;
        private CreateMembreDto? _newMembre = null;
        private List<string> _validationErrors = new();
        private MembreDto? _membreToDelete = null;

        private IEnumerable<MembreDto> FilteredItems
        {
            get
            {
                if (_membres == null) return Enumerable.Empty<MembreDto>();

                var resultat = _membres.AsEnumerable();

                if (!string.IsNullOrWhiteSpace(_searchQuery))
                {
                    resultat = resultat.Where(x => x.Nom.Contains(_searchQuery, StringComparison.OrdinalIgnoreCase));
                }

                return resultat;
            }
        }
        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();

            _membres = await MembreService.GetAll();
            _isLoading = false;
        }

        private async Task CreateNewMembre()
        {
            if (_newMembre is null) return;

            _isLoading = true;

            _validationErrors.Clear();
            var result = await MembreService.Create(_newMembre);

            if (result.IsSuccess)
            {
                ClearModal();
                _membres.Add(result.Data!);
            }
            else
            {
                _validationErrors = result.Errors;
            }

            _isLoading = false;
        }

        private async Task DeleteMembre()
        {
            if (_membreToDelete is null) return;

            _isLoading = true;

            bool success = await MembreService.Delete(_membreToDelete.Id);

            if (success)
            {
                _isDeleteConfirmationOpen = false;
                _membres.Remove(_membreToDelete);
                _membreToDelete = null;
                NotificationService.ShowSuccess("Le membre a été supprimé avec succès!");
            }
            else
            {
                NotificationService.ShowSuccess("Un problème est survenu.");
            }

            _isLoading = false;
        }


        private void ClearModal()
        {
            _isModalOpen = false;
            _newMembre = null;
            _validationErrors.Clear();
        }

        private void ClearDeleteConfirmationModal()
        {
            _isDeleteConfirmationOpen = false;
            _membreToDelete = null;
        }
    }
}
