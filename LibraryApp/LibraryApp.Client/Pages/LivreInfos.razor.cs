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

        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();

            _livre = await LivreService.GetLivreInfos(Id);
        }
    }
}
