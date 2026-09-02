using LibraryApp.Client.Services.Interfaces;
using Microsoft.AspNetCore.Components;
using static LibraryApp.Shared.DTOs.CategoryDto;
using static LibraryApp.Shared.DTOs.LivreDto;

namespace LibraryApp.Client.Pages
{
    public partial class Livres
    {
        [Inject]
        public ILivreService LivreService { get; set; }
        [Inject]
        public ICategoryService CategoryService { get; set; }

        private List<GetAllLivresDto> _livres = new List<GetAllLivresDto>();
        private List<GetAllCategoryDto> _categories = new List<GetAllCategoryDto>();
        private string _searchQuery = string.Empty;
        private int _selectedCategory = 0;
        private bool _isLoading = true;

        private IEnumerable<GetAllLivresDto> FilteredItems 
        {
            get
            {
                if (_livres == null) return Enumerable.Empty<GetAllLivresDto>();

                var resultat = _livres.AsEnumerable();

                if (_selectedCategory > 0)
                {
                    resultat = resultat.Where(x => x.CategoryIds.Any(x => x == _selectedCategory));
                }

                if (!string.IsNullOrWhiteSpace(_searchQuery))
                {
                    resultat = resultat.Where(x => x.Titre.Contains(_searchQuery, StringComparison.OrdinalIgnoreCase));
                }

                return resultat;
            }
        }

        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();

            var livresTask = LivreService.GetAllAsync();
            var categoriesTask = CategoryService.GetAllAsync();
            await Task.WhenAll(livresTask, categoriesTask);
            _livres = livresTask.Result;
            _categories = categoriesTask.Result;

            _isLoading = false;
        }
    }
}
