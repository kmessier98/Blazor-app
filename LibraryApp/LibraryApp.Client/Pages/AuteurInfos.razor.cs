using LibraryApp.Client.Services.Interfaces;
using Microsoft.AspNetCore.Components;
using static LibraryApp.Shared.DTOs.AuteurDto;

namespace LibraryApp.Client.Pages
{
    public partial class AuteurInfos
    {
        [Inject]
        public IAuteurService AuteurService { get; set; }
        [Parameter]
        public int Id { get; set; }

        private GetAuteurInfosDto? _auteur;
        private bool _isLoading = true;

        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();

            _auteur = await AuteurService.GetAuteurInfos(Id);
            _isLoading = false;
        }
    }
}
