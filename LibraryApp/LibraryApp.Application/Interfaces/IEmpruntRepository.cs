using LibraryApp.Domain.Entities;
using LibraryApp.Shared.Interfaces;

namespace LibraryApp.Application.Interfaces
{
    public interface IEmpruntRepository : IGenericInterface<Emprunt>
    {
        Task<IReadOnlyList<Emprunt>> GetAllActiveAsync();
        Task<Emprunt?> GetActiveAsync(int empruntId);
        Task<Emprunt> EmprunterExemplaire(Exemplaire entity, int membreId);
        Task RetournerExemplaire(Emprunt entity);
    }
}
