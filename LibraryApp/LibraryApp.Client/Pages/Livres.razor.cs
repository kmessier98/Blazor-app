using LibraryApp.Client.Services.Interfaces;
using Microsoft.AspNetCore.Components;
using static LibraryApp.Shared.DTOs.LivreDto;

namespace LibraryApp.Client.Pages
{
    public partial class Livres
    {
        [Inject]
        public ILivreService LivreService { get; set; }

        private List<GetAllLivresDto>? livres;
        private string SearchQuery { get; set; } = string.Empty;
        private IEnumerable<GetAllLivresDto>? FilteredItems => string.IsNullOrWhiteSpace(SearchQuery)
            ? livres
            : livres.Where(x => x.Titre.Contains(SearchQuery, StringComparison.OrdinalIgnoreCase));


        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();

            livres = await LivreService.GetAllAsync();
        }
    }
}
