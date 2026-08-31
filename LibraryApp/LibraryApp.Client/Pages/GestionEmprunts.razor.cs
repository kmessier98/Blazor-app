using LibraryApp.Client.Services.Interfaces;
using LibraryApp.Shared.DTOs;
using Microsoft.AspNetCore.Components;

namespace LibraryApp.Client.Pages
{
    public partial class GestionEmprunts
    {
        [Inject]
        public IEmpruntService EmpruntService { get; set; }

        private List<EmpruntDto>? _emprunts {  get; set; }

        protected override async Task OnInitializedAsync()
        {
             await base.OnInitializedAsync();

            _emprunts = await EmpruntService.GetAllActiveAsync();
        }
    }
}
