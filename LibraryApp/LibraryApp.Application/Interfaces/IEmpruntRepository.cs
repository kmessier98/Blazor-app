using LibraryApp.Domain.Entities;
using LibraryApp.Shared.Interfaces;

namespace LibraryApp.Application.Interfaces
{
    public interface IEmpruntRepository : IGenericInterface<Emprunt>
    {
        Task<IReadOnlyList<Emprunt>> GetAllActiveAsync();
    }
}
