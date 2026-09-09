using LibraryApp.Client.Services.Interfaces;
using LibraryApp.Shared.DTOs;
using Microsoft.AspNetCore.Components;

namespace LibraryApp.Client.Pages
{
    public partial class Membres
    {
        [Inject]
        public IMembreService MembreService { get; set; }

        private bool _isLoading = true;
        private List<MembreDto> _membres = new List<MembreDto>();
        private string _searchQuery = string.Empty;

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
    }
}
