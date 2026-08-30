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

        protected override async Task OnInitializedAsync()
        {
            livres = await LivreService.GetAllAsync();

            await base.OnInitializedAsync();
        }
    }
}
